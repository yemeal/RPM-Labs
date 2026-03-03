using SOLID_Fundamentals.Domain;
using SOLID_Fundamentals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderNotificationService _orderNotificationService;

        public OrderService(IOrderNotificationService orderNotificationService)
        {
            _orderNotificationService = orderNotificationService;
        }

        public void CreateOrder(Order order)
        {
            _orderNotificationService.SendOrderPlacedNotification(order);
            Console.WriteLine("Order created");
        }

        public void UpdateOrder(Order order)
        {
            _orderNotificationService.SendOrderUpdatedNotification(order);
            Console.WriteLine("Order updated");
        }

        public void DeleteOrder(Order order)
        {
            Console.WriteLine("Order deleted");
            _orderNotificationService.SendOrderDeletedNotification(order);
        }
    }
}
