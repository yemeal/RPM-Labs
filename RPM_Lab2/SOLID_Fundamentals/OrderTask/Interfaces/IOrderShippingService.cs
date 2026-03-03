using SOLID_Fundamentals.OrderTask.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.OrderTask.Interfaces
{
    public interface IOrderShippingService
    {
        void ShipOrder(Order order);
    }
}
