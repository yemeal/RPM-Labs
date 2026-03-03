using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Order.Interfaces
{
    public interface IDatabaseMaintenanceService
    {
        void ExportToExcel(string filePath);
        void BackupDatabase();
        void RestoreDatabase();
    }
}
