using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID_Fundamentals.OrderTask.Domain;

namespace SOLID_Fundamentals.OrderTask.Interfaces
{
    public interface IReportService
    {
        Report GenerateReport(DateTime from, DateTime to);
    }
}
