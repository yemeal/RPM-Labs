using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Composite
{
    public class FileItem(string name, int size) : IFileSystemComponent
    {
        public string Name { get; } = name;
        private readonly int _size = size;

        public int GetSize() => _size;
        public void Delete() => Console.WriteLine($"Удаление файла: {Name}");
        public void Copy(string destinationPath) => Console.WriteLine($"Копирование файла {Name} в {destinationPath}");
    }
}
