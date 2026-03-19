using RPM_Lab5.Adapter;
using RPM_Lab5.Composite;
using RPM_Lab5.Facade;
using System;

namespace FileManagerApp
{
    class Program
    {
        static void Main()
        {
            // Демонстрация паттерна COMPOSITE
            Console.WriteLine("============= 1. Тест паттерна COMPOSITE =============");
            FolderItem rootFolder = new FolderItem("Root");
            FolderItem docsFolder = new FolderItem("Documents");

            FileItem textFile = new FileItem("readme.txt", 150);
            FileItem imgFile = new FileItem("photo.png", 2048);
            FileItem config = new FileItem("config.json", 1024);

            docsFolder.Add(textFile);
            docsFolder.Add(imgFile);

            rootFolder.Add(docsFolder);
            rootFolder.Add(config);

            Console.WriteLine($"Общий размер папки 'Root' и всех вложений: {rootFolder.GetSize()} байт");

            // Проверка рекурсивного копирования
            rootFolder.Copy("D:/BackupDrive");

            // Проверка рекурсивного удаления
            rootFolder.Delete();


            // Демонстрация паттерна ADAPTER
            Console.WriteLine("\n============= 2. Тест паттерна ADAPTER =============");

            IFileSystem ntfs = new NtfsAdapter();
            IFileSystem ftp = new FtpAdapter();
            IFileSystem cloud = new GoogleDriveAdapter();

            Console.WriteLine("--- Тест записи на разные ФС через единый интерфейс ---");
            ntfs.WriteFile("C:/Projects/test.txt", "Local Data");
            ftp.WriteFile("ftp://server/test.txt", "FTP Data");
            cloud.WriteFile("drive_folder_id/test.txt", "Cloud Data");


            // Демонстрация паттерна FACADE
            Console.WriteLine("\n============= 3. Тест паттерна FACADE =============");

            // Сценарий 1: Бэкап с локального диска (NTFS) на удаленный FTP сервер
            FileManagerFacade backupFacade = new FileManagerFacade(ntfs, ftp);
            backupFacade.Backup("C:/Projects/App", "ftp://server/backups/App");

            // Сценарий 2: Синхронизация локальной папки (NTFS) с Облаком (Google Drive)
            FileManagerFacade syncFacade = new FileManagerFacade(ntfs, cloud);
            syncFacade.SyncFolder("C:/Users/Documents", "drive_folder_id/SyncDocs");

            Console.ReadLine();
        }
    }
}