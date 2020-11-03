using Messages;
using System;
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
                FileLogger.Log("Creating zip archive: " + zipPath);
                using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                {
                    FileLogger.Log("Beginning zip operation...");
                    // Loop through the input files and zip one by one. Report progress to client through writer.
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        string path = filePaths[i];
                        try
                        {
                            FileLogger.Log("Zipping file: " + path);
                            archive.CreateEntryFromFile(path, Path.GetFileName(path));
                            // report progress to the client
                            writer.Write(new ZipOperationMessage(i + 1, filePaths.Length));
                        }
                        catch (Exception e)
                        {
                            FileLogger.Log($"Error while zipping {path}. Zip operation aborted");
                            FileLogger.Log(e.Message);
                            File.Delete(zipPath); 
                            break;
                        }
                    }
                    FileLogger.Log("Zip operation complete");
                }
            }
            catch (Exception e)
            {
                FileLogger.Log("Error creating zip archive:");
                FileLogger.Log(e.Message);
            }
        }

        public void TransferFiles(string[] filePaths, BinaryWriter writer)
        {
            FileLogger.Log("Transferring files...");
            for (int i = 0; i < filePaths.Length; i++)
            {
                string path = filePaths[i];
                FileLogger.Log("Transferring: " + path);
                string fileName = Path.GetFileName(path);
                byte[] fileBytes = File.ReadAllBytes(path);
                var message = new TransferOperationMessage(
                    i + 1, filePaths.Length, fileName, fileBytes);
                writer.Write(message);
            }
            FileLogger.Log("Transfer operation complete");
        }

        public string[] GetFileNamesInDirectory(string path)
        {
            return Directory.GetFiles(path).Select(p => Path.GetFileName(p)).ToArray();
        }

        public string[] GetFilePathsInDirectory(string directory)
        {
            return GetFileNamesInDirectory(directory)
                .Select(f => Path.Combine(directory, f)).ToArray();
        }

        public string[] GetLogCategories(string directory)
        {
            var files = GetFileNamesInDirectory(directory);
            return new FileCategoryTree(files).MainCategories.ToArray();
        }

        public DateTime GetLastUpdateTime(string filePath)
        {
            return File.GetLastWriteTime(filePath);
        }
    }
}
