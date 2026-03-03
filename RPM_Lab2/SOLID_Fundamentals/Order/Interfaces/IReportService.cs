using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID_Fundamentals.Domain;

namespace SOLID_Fundamentals.Interfaces
{
    public interface IReportService
    {
        Report GenerateReport(DateTime from, DateTime to);
    }
}
