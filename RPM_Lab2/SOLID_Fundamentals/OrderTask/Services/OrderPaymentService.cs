using SOLID_Fundamentals.OrderTask.Domain;
using SOLID_Fundamentals.OrderTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.OrderTask.Services
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
        public void GenerateReceipt(Order order) 
        {
            Console.WriteLine("Receipt generated");
        }
    }
}
