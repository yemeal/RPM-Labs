using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.Interfaces
{
    public interface IDatabaseService
    {
        void ExportToExcel(string filePath);
        void BackupDatabase();
        void RestoreDatabase();
    }
}
