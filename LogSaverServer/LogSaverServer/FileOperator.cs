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
            if (!Directory.Exists(sourcePath))
                throw new DirectoryNotFoundException("Could not find directory: " + sourcePath);
            Directory.CreateDirectory(destPath);
            string[] files = Directory.GetFiles(sourcePath);
            foreach (string file in files) CopyFile(file, destPath, true);
        }

        public void ZipFiles(string[] filePaths, string zipPath)
        {
            try
            {
                // Open zip archive if it does not already exist
                using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                {
                    // Loop through the input files and zip one by one. Report progress to client through writer.
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        string path = filePaths[i];
                        try
                        {
                            Console.WriteLine("Zipping file: " + path);
                            archive.CreateEntryFromFile(path, Path.GetFileName(path));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error while zipping {path}. Zip operation aborted");
                            Console.WriteLine(e.Message);
                            File.Delete(zipPath);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error creating zip archive:");
                Console.WriteLine(e.Message);
            }
        }

        public string[] GetFileNamesInDirectory(string path)
        {
            return Directory.GetFiles(path);
        }

        public string[] GetFilePathsInDirectory(string path)
        {
            return GetFileNamesInDirectory(path).Select(f => Path.Combine(path, f)).ToArray();
        }

        public string[] GetLogCategories(string path)
        {
            var files = GetFileNamesInDirectory(path);
            List<string> logCategories = new List<string>();
            return logCategories.ToArray();
        }

        public DateTime GetLastUpdateTime(string filePath)
        {
            return File.GetLastWriteTime(filePath);
        }
    }
}
