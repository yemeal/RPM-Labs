using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Adapter
{
    public class FtpAdapter : IFileSystem
    {
        private FtpServerApi _ftp = new FtpServerApi();

        public List<string> ListItems(string path) => _ftp.FetchDirectoryContent(path);
        public void ReadFile(string path) => _ftp.DownloadFile(path);
        public void WriteFile(string path, string content) => _ftp.UploadFile(path, content);
        public void Delete(string path) => _ftp.DeleteFtpFile(path);
    }
}
