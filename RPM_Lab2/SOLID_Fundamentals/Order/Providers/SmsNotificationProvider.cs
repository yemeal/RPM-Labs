using SOLID_Fundamentals.Order.Domain;
using SOLID_Fundamentals.Order.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Order.Providers
{
    public class SmsNotificationProvider : INotificationProvider
    {
        public NotificationChannel Channel => NotificationChannel.Sms;

        public void Send(Order order, string subject, string body)
        {
            Console.WriteLine($"Sending SMS to {order.CustomerPhone}: {body}");
        }
    }
}
