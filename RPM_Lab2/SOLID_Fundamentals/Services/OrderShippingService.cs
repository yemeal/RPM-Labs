using SOLID_Fundamentals.Domain;
using SOLID_Fundamentals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Services
{
    public class OrderShippingService : IOrderShippingService
    {
        public void ShipOrder(Order order)
        {
            Console.WriteLine("Order shipped");
        }
    }
}
