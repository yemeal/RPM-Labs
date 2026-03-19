using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab5.Adapter
{
    public class NtfsAdapter : IFileSystem
    {
        private NtfsFileSystem _ntfs = new NtfsFileSystem();

        public List<string> ListItems(string path) => _ntfs.GetDirectoryFiles(path);
        public void ReadFile(string path) => _ntfs.ReadByteStream(path);
        public void WriteFile(string path, string content) => _ntfs.WriteByteStream(path, content);
        public void Delete(string path) => _ntfs.RemoveFile(path);
    }
}
