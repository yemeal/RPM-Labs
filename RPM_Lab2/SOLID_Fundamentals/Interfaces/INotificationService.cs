using SOLID_Fundamentals.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Interfaces
{
    public interface INotificationService
    {
        void SendNotificationToAll(Order order, string subject, string body);
        void SendNotification(Order order, NotificationChannel channel, string subject, string body);
    }
}
