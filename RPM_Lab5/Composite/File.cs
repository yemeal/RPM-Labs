using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Composite
{
    public class File(string name, long size) : FileSystemItem(name)
    {
        private long _size = size;

        public override long GetSize()
        {
            return _size;
        }
    }
}
