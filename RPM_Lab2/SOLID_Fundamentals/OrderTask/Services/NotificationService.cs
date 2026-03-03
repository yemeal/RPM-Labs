using SOLID_Fundamentals.OrderTask.Domain;
using SOLID_Fundamentals.OrderTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.OrderTask.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEnumerable<INotificationProvider> _providers;

        public NotificationService(IEnumerable<INotificationProvider> providers)
        {
            _providers = providers;
        }

        public void SendNotificationToAll(Order order, string subject, string body)
        {
            foreach (var provider in _providers)
                provider.Send(order, subject, body);
        }

        public void SendNotification(Order order, NotificationChannel channel, string subject, string body)
        {
            var provider = _providers.FirstOrDefault(p => p.Channel == channel);
            if (provider == null)
                throw new InvalidOperationException($"No provider for channel {channel}");
            provider.Send(order, subject, body);
        }
    }
}
