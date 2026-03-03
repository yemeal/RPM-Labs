using SOLID_Fundamentals.Domain;
using SOLID_Fundamentals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Services
{
    public class DatabaseOrderRepository : IOrderRepository
    {
        public void Add(Order order)
        {
            // работа с БД
        }

        public void Update(Order order)
        {
            // работа с БД
        }

        public void Delete(Order order)
        {
            // работа с БД
        }

        public Order GetById(int orderId)
        {
            // SELECT ...
            Order order = new Order();
            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            // SELECT *
            List<Order> orders = new List<Order>();
            return orders;
        }
    }
}
