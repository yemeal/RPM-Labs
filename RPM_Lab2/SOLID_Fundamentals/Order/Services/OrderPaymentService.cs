using SOLID_Fundamentals.Domain;
using SOLID_Fundamentals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Services
{
    public class OrderPaymentService : IOrderPaymentService
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Payment processed");
        }
        public void GenerateInvoice(Order order)
        {
            Console.WriteLine("Invoice generated");
        }
        private void GenerateReceipt(Order order) 
        {
            Console.WriteLine("Receipt generated");
        }
    }
}
