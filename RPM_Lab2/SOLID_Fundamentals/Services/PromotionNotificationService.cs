using SOLID_Fundamentals.Domain;
using SOLID_Fundamentals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Services
{
    public class PromotionNotificationService
    {
        private readonly INotificationService _notificationService;

        public PromotionNotificationService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void SendPromotion(Order order)
        {
            var subject = "Special Promotion";
            var body = "You can have 20% off for your next order";

            _notificationService.SendNotification(order, NotificationChannel.Email, subject, body);
        }
    }
}
