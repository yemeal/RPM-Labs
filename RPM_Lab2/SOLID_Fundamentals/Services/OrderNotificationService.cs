using SOLID_Fundamentals.Domain;
using SOLID_Fundamentals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Services
{
    public class OrderNotificationService
    {
        private readonly INotificationService _notificationService;

        public OrderNotificationService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void SendOrderPlacedNotification(Order order)
        {
            var subject = "Order Confirmation";
            var body = $"Your order {order.Id} has been placed. Total: {order.TotalAmount}";

            _notificationService.SendNotificationToAll(order, subject, body);
        }

        public void SendOrderUpdatedNotification(Order order)
        {
            var subject = "Order Updated";
            var body = $"Your order {order.Id} has been updated. New total: {order.TotalAmount}";

            _notificationService.SendNotificationToAll(order, subject, body);
        }

        public void SendOrderDeletedNotification(Order order)
        {
            var subject = "Order Cancelled";
            var body = $"Your order {order.Id} has been deleted.";

            _notificationService.SendNotificationToAll(order, subject, body);
        }
    }
}
