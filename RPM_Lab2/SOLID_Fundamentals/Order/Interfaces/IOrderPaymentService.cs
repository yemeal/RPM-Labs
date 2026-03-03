using SOLID_Fundamentals.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Order.Interfaces
{
    public interface IOrderPaymentService
    {
        void ProcessPayment(Order order);
        void GenerateInvoice(Order order);
        void GenerateReceipt(Order order);
    }
}
