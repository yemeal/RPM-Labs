using RPM_Lab5.Composite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Adapter
{
    public class FileSystemAdapter(FileSystemItem root) : IFileSystem
    {
        private readonly FileSystemItem _root = root;

        public List<string> ListItems(string path)
        {
            Console.WriteLine($"[Adapter] Получение списка элементов по пути: {path}");
            // Упрощенная имитация возврата списка файлов
            return ["file1.txt", "file2.txt"];
        }

        public byte[] ReadFile(string path)
        {
            Console.WriteLine($"[Adapter] Чтение файла: {path}");
            return [];
        }

        public void WriteFile(string path, byte[] data)
        {
            Console.WriteLine($"[Adapter] Запись в файл: {path}");
        }

        public void DeleteItem(string path)
        {
            Console.WriteLine($"[Adapter] Удаление: {path}");
        }
    }
}
