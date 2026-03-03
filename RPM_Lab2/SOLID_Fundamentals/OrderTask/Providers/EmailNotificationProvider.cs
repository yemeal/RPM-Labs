using SOLID_Fundamentals.OrderTask.Domain;
using SOLID_Fundamentals.OrderTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.OrderTask.Providers
{
    public class EmailNotificationProvider : INotificationProvider
    {
        public NotificationChannel Channel => NotificationChannel.Email;

        public void Send(Order order, string subject, string body)
        {
            Console.WriteLine($"Sending email to {order.CustomerEmail}: {subject}");
        }
    }
}
