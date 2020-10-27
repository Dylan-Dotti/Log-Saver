using Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

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

        public void ZipFiles(string[] filePaths, string zipPath, BinaryWriter writer)
        {
            try
            {
                // Open zip archive if it does not already exist
                Console.WriteLine("Creating zip archive: " + zipPath);
                using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                {
                    Console.WriteLine("Beginning zip operation...");
                    // Loop through the input files and zip one by one. Report progress to client through writer.
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        string path = filePaths[i];
                        try
                        {
                            Console.WriteLine("Zipping file: " + path);
                            archive.CreateEntryFromFile(path, Path.GetFileName(path));
                            // report progress to the client
                            writer.Write(new ZipStatusMessage(i + 1, filePaths.Length).ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error while zipping {path}. Zip operation aborted");
                            Console.WriteLine(e.Message);
                            File.Delete(zipPath); 
                            break;
                        }
                    }
                    Console.WriteLine("Zip operation complete");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error creating zip archive:");
                Console.WriteLine(e.Message);
            }
        }

        public void TransferFiles(string[] filePaths, BinaryWriter writer)
        {

        }

        public string[] GetFileNamesInDirectory(string path)
        {
            return Directory.GetFiles(path).Select(p => Path.GetFileName(p)).ToArray();
        }

        public string[] GetFilePathsInDirectory(string path)
        {
            return GetFileNamesInDirectory(path).Select(f => Path.Combine(path, f)).ToArray();
        }

        public string[] GetLogCategories(string path)
        {
            var files = GetFileNamesInDirectory(path);
            var logCategories = files.Select(f => f.Split('.').First()).Distinct();
            var mainCategories = logCategories.Select(c => c.Split('_').First()).Distinct();
            return mainCategories.ToArray();
        }

        public DateTime GetLastUpdateTime(string filePath)
        {
            return File.GetLastWriteTime(filePath);
        }
    }
}
