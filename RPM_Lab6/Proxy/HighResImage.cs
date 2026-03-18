using RPM_Lab6.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Proxy
{
    public class HighResImage : IGraphic
    {
        private string _filePath;

        public HighResImage(string filePath)
        {
            _filePath = filePath;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Console.WriteLine($"[Proxy - Загрузка] Чтение тяжелого изображения с диска: {_filePath}...");
            Thread.Sleep(1000); // Имитация долгой загрузки
            Console.WriteLine($"[Proxy - Завершено] Изображение {_filePath} загружено в память.");
        }

        public void Draw()
        {
            Console.WriteLine($"Отрисовка изображения высокого разрешения: {_filePath}");
        }
    }
}
