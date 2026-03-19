using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Adapter
{
    public class GoogleDriveAdapter : IFileSystem
    {
        private GoogleDriveApi _drive = new GoogleDriveApi();

        public List<string> ListItems(string path) => _drive.GetCloudFiles(path);
        public void ReadFile(string path) => _drive.FetchDocument(path);
        public void WriteFile(string path, string content) => _drive.SaveDocument(path, content);
        public void Delete(string path) => _drive.TrashDocument(path);
    }
}
