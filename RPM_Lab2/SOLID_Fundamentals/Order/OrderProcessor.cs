using SOLID_Fundamentals.Domain;
using SOLID_Fundamentals.Interfaces;

public class OrderProcessor
{
    private readonly IOrderPaymentService _orderPaymentService;
    private readonly IInventoryService _inventoryService;
    private readonly IOrderNotificationService _orderNotificationService;
    private readonly ILoggingService _loggingService;

    public OrderProcessor(
        IOrderPaymentService orderPaymentService,
        IInventoryService inventoryService,
        IOrderNotificationService orderNotificationService,
        ILoggingService loggingService)
    {
        _orderPaymentService = orderPaymentService;
        _inventoryService = inventoryService;
        _orderNotificationService = orderNotificationService;
        _loggingService = loggingService;
    }

    public void ProcessOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        if (order.TotalAmount <= 0)
            throw new InvalidOperationException("Invalid order amount");

        _orderPaymentService.ProcessPayment(order);
        _inventoryService.UpdateInventory(order);
        _orderNotificationService.SendOrderPlacedNotification(order);
        _orderPaymentService.GenerateReceipt(order);

        _loggingService.Log($"Order {order.Id} processed at {DateTime.Now}");
    }
}