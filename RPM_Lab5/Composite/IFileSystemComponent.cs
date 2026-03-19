using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Composite
{
    public interface IFileSystemComponent
    {
        string Name { get; }
        int GetSize();
        void Delete();
        void Copy(string destinationPath);
    }
}
