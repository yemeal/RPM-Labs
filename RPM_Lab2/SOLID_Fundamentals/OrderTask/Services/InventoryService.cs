using SOLID_Fundamentals.OrderTask.Domain;
using SOLID_Fundamentals.OrderTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.OrderTask.Services
{
    public class InventoryService : IInventoryService
    {
        public void UpdateInventory(Order order)
        {
            // Здесь могла бы быть работа с БД или складской системой
            Console.WriteLine($"Inventory updated for order {order.Id}");
        }
    }
}
