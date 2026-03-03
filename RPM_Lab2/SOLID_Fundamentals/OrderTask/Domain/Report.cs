using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.OrderTask.Domain
{
    public class Report
    {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
