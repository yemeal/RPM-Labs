using SOLID_Fundamentals.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Interfaces
{
    public interface IOrderNotificationService
    {
        void SendOrderPlacedNotification(Order order);
        void SendOrderUpdatedNotification(Order order);
        void SendOrderDeletedNotification(Order order);
    }
}
