using SOLID_Fundamentals.Domain;
using SOLID_Fundamentals.Order.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Order.Services
{
    public class OrderShippingService : IOrderShippingService
    {
        public void ShipOrder(Order order)
        {
            Console.WriteLine("Order shipped");
        }
    }
}
