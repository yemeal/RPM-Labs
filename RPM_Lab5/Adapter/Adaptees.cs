using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Adapter
{
    // Имитация API локальной файловой системы NTFS
    public class NtfsFileSystem
    {
        public List<string> GetDirectoryFiles(string path) => new List<string> { "local_doc.txt", "local_photo.jpg" };
        public void ReadByteStream(string path) => Console.WriteLine($"[NTFS] Чтение байтов из {path}");
        public void WriteByteStream(string path, string data) => Console.WriteLine($"[NTFS] Запись байтов в {path}");
        public void RemoveFile(string path) => Console.WriteLine($"[NTFS] Удаление файла {path}");
    }

    // Имитация API FTP-сервера
    public class FtpServerApi
    {
        public List<string> FetchDirectoryContent(string ftpPath) => new List<string> { "ftp_backup.zip" };
        public void DownloadFile(string ftpPath) => Console.WriteLine($"[FTP] Скачивание файла с {ftpPath}");
        public void UploadFile(string ftpPath, string content) => Console.WriteLine($"[FTP] Загрузка файла на {ftpPath}");
        public void DeleteFtpFile(string ftpPath) => Console.WriteLine($"[FTP] Удаление с сервера {ftpPath}");
    }

    // Имитация API Облачного хранилища (Google Drive)
    public class GoogleDriveApi
    {
        public List<string> GetCloudFiles(string folderId) => new List<string> { "cloud_presentation.pptx" };
        public void FetchDocument(string docId) => Console.WriteLine($"[Google Drive] Получение документа {docId}");
        public void SaveDocument(string docId, string data) => Console.WriteLine($"[Google Drive] Сохранение документа {docId}");
        public void TrashDocument(string docId) => Console.WriteLine($"[Google Drive] Перемещение в корзину {docId}");
    }
}
