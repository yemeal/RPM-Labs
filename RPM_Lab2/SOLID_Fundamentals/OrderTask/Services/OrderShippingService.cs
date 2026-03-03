using SOLID_Fundamentals.OrderTask.Domain;
using SOLID_Fundamentals.OrderTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.OrderTask.Services
{
    public class OrderShippingService : IOrderShippingService
    {
        public void ShipOrder(Order order)
        {
            Console.WriteLine("Order shipped");
        }
    }
}
