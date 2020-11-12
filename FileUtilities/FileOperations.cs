using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using TimeUtilities;

namespace FileUtilities
{
    public static class FileOperations
    {
        public static void CopyFile(string sourcePath, string destPath, bool overwrite)
        {
            string fileName = Path.GetFileName(sourcePath);
            string destFile = Path.Combine(destPath, fileName);
            File.Copy(sourcePath, destFile, overwrite);
        }

        public static void CopyDirectory(string sourcePath, string destPath)
        {
            if (!Directory.Exists(sourcePath))
                throw new DirectoryNotFoundException("Could not find directory: " + sourcePath);
            Directory.CreateDirectory(destPath);
            string[] files = Directory.GetFiles(sourcePath);
            foreach (string file in files) CopyFile(file, destPath, true);
        }

        public static ZipArchive CreateZipArchive(string path)
        {
            return ZipFile.Open(path, ZipArchiveMode.Create);
        }

        public static string[] GetFileNamesInDirectory(string path)
        {
            return Directory.GetFiles(path).Select(p => Path.GetFileName(p)).ToArray();
        }

        public static string[] GetFilePathsInDirectory(string directory)
        {
            return GetFileNamesInDirectory(directory)
                .Select(f => Path.Combine(directory, f)).ToArray();
        }

        public static string[] GetFilteredFilePaths(string directory,
            DateTimeRange timeRangeLocal, string[] categories)
        {
            IEnumerable<string> filePaths = GetFilePathsInDirectory(directory);
            var nameToPathsGrouping = filePaths
                .GroupBy(p => Path.GetFileNameWithoutExtension(p))
                .Where(grp => categories.Any(c => grp.Key.StartsWith(c)));
            List<string> filePathsFiltered = new List<string>();
            foreach (var grouping in nameToPathsGrouping)
            {
                foreach (string path in grouping)
                {
                    filePathsFiltered.Add(path);
                }
            }
            return filePathsFiltered.ToArray();
        }

        public static FileCategory[] GetLogCategories(string directory)
        {
            var files = GetFileNamesInDirectory(directory);
            return new FileCategorizer().Categorize(files).ToArray();
        }

        public static DateTime GetLastUpdateTime(string filePath)
        {
            return File.GetLastWriteTime(filePath);
        }
    }
}
