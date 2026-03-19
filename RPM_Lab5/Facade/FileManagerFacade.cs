using RPM_Lab5.Adapter;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Facade
{
    public class FileManagerFacade(IFileSystem source, IFileSystem target)
    {
        private readonly IFileSystem _sourceFS = source;
        private readonly IFileSystem _targetFS = target;

        public void SyncFolder(string sourcePath, string targetPath)
        {
            Console.WriteLine($"\n[Facade] Запуск синхронизации папки '{sourcePath}' -> '{targetPath}'...");

            var items = _sourceFS.ListItems(sourcePath);
            foreach (var item in items)
            {
                _sourceFS.ReadFile($"{sourcePath}/{item}");
                _targetFS.WriteFile($"{targetPath}/{item}", "sync_data");
            }
            Console.WriteLine("[Facade] Синхронизация успешно завершена.");
        }

        public void Backup(string sourcePath, string backupPath)
        {
            Console.WriteLine($"\n[Facade] Запуск резервного копирования '{sourcePath}' -> '{backupPath}'...");
            try
            {
                var items = _sourceFS.ListItems(sourcePath);
                foreach (var item in items)
                {
                    _sourceFS.ReadFile($"{sourcePath}/{item}");
                    _targetFS.WriteFile($"{backupPath}/{item}.bak", "backup_data");
                }
                Console.WriteLine("[Facade] Резервное копирование завершено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Facade] Ошибка при резервном копировании: {ex.Message}");
            }
        }
    }
}
