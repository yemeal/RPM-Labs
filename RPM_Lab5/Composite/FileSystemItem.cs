using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Composite
{
    public abstract class FileSystemItem(string name)
    {
        public string Name { get; set; } = name;

        public abstract long GetSize();

        public virtual void Add(FileSystemItem item)
        {
            throw new InvalidOperationException();
        }

        public virtual void Remove(FileSystemItem item)
        {
            throw new InvalidOperationException();
        }

        public virtual FileSystemItem GetChild(int index)
        {
            throw new InvalidOperationException();
        }
    }
}
