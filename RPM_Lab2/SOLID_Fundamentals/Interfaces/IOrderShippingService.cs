using SOLID_Fundamentals.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Interfaces
{
    public interface IOrderShippingService
    {
        void ShipOrder(Order order);
    }
}
