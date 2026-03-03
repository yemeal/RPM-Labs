using SOLID_Fundamentals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Services
{
    public class OrderReportService : IOrderReportService
    {
        public void GenerateReport(DateTime from, DateTime to)
        {
            Console.WriteLine("Report generated");
        }
    }
}
