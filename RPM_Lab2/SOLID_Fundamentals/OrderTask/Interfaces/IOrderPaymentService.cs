using SOLID_Fundamentals.OrderTask.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.OrderTask.Interfaces
{
    public interface IOrderPaymentService
    {
        void ProcessPayment(Order order);
        void GenerateInvoice(Order order);
        void GenerateReceipt(Order order);
    }
}
