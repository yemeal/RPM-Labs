using SOLID_Fundamentals.OrderTask.Domain;
using SOLID_Fundamentals.OrderTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.OrderTask.Services
{
    public class ReportService : IReportService
    {
        private readonly IOrderRepository _orderRepository;
        public ReportService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Report GenerateReport(DateTime from, DateTime to)
        {
            var orders = _orderRepository.GetAll()
                .Where(o => o.CreatedAt >= from && o.CreatedAt <= to);

            return new Report
            {
                From = from,
                To = to,
                TotalOrders = orders.Count(),
                TotalRevenue = orders.Sum(o => o.TotalAmount)
            };
        }

    }
}

