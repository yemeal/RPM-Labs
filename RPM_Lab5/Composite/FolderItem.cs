using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Composite
{
    public class FolderItem(string name) : IFileSystemComponent
    {
        public string Name { get; } = name;
        private readonly List<IFileSystemComponent> _children = [];

        public void Add(IFileSystemComponent component) => _children.Add(component);
        public void Remove(IFileSystemComponent component) => _children.Remove(component);

        public int GetSize()
        {
            int total = 0;
            foreach (var child in _children) total += child.GetSize(); // Рекурсивный подсчет
            return total;
        }

        public void Delete()
        {
            Console.WriteLine($"Удаление папки: {Name}");
            foreach (var child in _children) child.Delete(); // Рекурсивное удаление
            _children.Clear();
        }

        public void Copy(string destinationPath)
        {
            Console.WriteLine($"Копирование папки {Name} в {destinationPath}");
            foreach (var child in _children) child.Copy($"{destinationPath}/{Name}"); // Рекурсивное копирование
        }
    }
}
