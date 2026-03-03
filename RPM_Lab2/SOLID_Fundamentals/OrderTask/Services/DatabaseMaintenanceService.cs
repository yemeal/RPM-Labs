using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID_Fundamentals.OrderTask.Interfaces;

namespace SOLID_Fundamentals.OrderTask.Services
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
