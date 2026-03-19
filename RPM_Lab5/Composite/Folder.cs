using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Composite
{
    public class Folder(string name) : FileSystemItem(name)
    {
        private readonly List<FileSystemItem> _children = [];

        public override long GetSize()
        {
            return _children.Sum(child => child.GetSize());
        }

        public override void Add(FileSystemItem item)
        {
            _children.Add(item);
        }

        public override void Remove(FileSystemItem item)
        {
            _children.Remove(item);
        }

        public override FileSystemItem GetChild(int index)
        {
            return _children[index];
        }
    }
}
