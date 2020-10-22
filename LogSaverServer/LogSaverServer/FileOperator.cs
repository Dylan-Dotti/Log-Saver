using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSaverServer
{
    class FileOperator
    {
        public void CopyFile(string sourcePath, string destPath, bool overwrite)
        {
            string fileName = Path.GetFileName(sourcePath);
            string destFile = Path.Combine(destPath, fileName);
            File.Copy(sourcePath, destFile, overwrite);
        }

        public void CopyDirectory(string sourcePath, string destPath)
        {
            if (!Directory.Exists(sourcePath)) throw new DirectoryNotFoundException("Could not find directory: " + sourcePath);
            Directory.CreateDirectory(destPath);
            string[] files = Directory.GetFiles(sourcePath);
            foreach (string file in files) CopyFile(file, destPath, true);
        }

        public void ZipDirectory(string sourcePath, string zipPath)
        {
            //foreach (var f in GetFilesInDirectory(sourcePath))
              //  Console.WriteLine(f);
            ZipFile.CreateFromDirectory(sourcePath, zipPath);
        }

        public string[] GetFilesInDirectory(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}
