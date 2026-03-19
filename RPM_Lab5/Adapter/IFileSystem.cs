using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Adapter
{
    public interface IFileSystem
    {
        List<string> ListItems(string path);
        void ReadFile(string path);
        void WriteFile(string path, string content);
        void Delete(string path);
    }
}
