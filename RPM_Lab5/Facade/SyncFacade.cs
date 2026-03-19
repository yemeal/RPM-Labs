using RPM_Lab5.Adapter;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Facade
{
    public class SyncFacade(IFileSystem source, IFileSystem target)
    {
        private readonly IFileSystem _sourceFS = source;
        private readonly IFileSystem _targetFS = target;

        public void SyncFolder(string sourcePath, string targetPath)
        {
            Console.WriteLine($"\n--- Начинаем синхронизацию {sourcePath} -> {targetPath} ---");
            var items = _sourceFS.ListItems(sourcePath);

            foreach (var item in items)
            {
                var data = _sourceFS.ReadFile(item);
                _targetFS.WriteFile(item, data);
            }
            Console.WriteLine("Синхронизация завершена.");
        }

        public void Backup(string sourcePath, string backupPath)
        {
            Console.WriteLine($"\n--- Начинаем резервное копирование {sourcePath} -> {backupPath} ---");
            try
            {
                var items = _sourceFS.ListItems(sourcePath);
                foreach (var item in items)
                {
                    var data = _sourceFS.ReadFile(item);
                    _targetFS.WriteFile(item + ".bak", data);
                }
                Console.WriteLine("Резервное копирование успешно завершено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при резервном копировании: {ex.Message}");
            }
        }
    }
}
