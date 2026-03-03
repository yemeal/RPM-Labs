using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID_Fundamentals.Order.Interfaces;

namespace SOLID_Fundamentals.Order.Services
{
    public class DatabaseMaintenanceService : IDatabaseMaintenanceService
    {
        public void ExportToExcel(string filePath)
        {
            Console.WriteLine("Exported to Excel");
        }

        public void BackupDatabase()
        {
            Console.WriteLine("Database backed up");
        }

        public void RestoreDatabase()
        {
            Console.WriteLine("Database restored");
        }
    }
}
