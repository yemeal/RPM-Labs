using SOLID_Fundamentals.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Order.Interfaces
{
    public interface INotificationProvider
    {
        /// <summary>
        /// Отправить уведомление.
        /// </summary>
        void Send(Order order, string subject, string body);

        /// <summary>
        /// Канал/тип, который поддерживает провайдер (email, sms)
        /// </summary>
        NotificationChannel Channel { get; }
    }
}
