using SOLID_Fundamentals.OrderTask.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.OrderTask.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        Order GetById(int orderId);
        IEnumerable<Order> GetAll();
    }
}
