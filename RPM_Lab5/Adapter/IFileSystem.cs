using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Adapter
{
    public interface IFileSystem
    {
        List<string> ListItems(string path);
        byte[] ReadFile(string path);
        void WriteFile(string path, byte[] data);
        void DeleteItem(string path);
    }
}
