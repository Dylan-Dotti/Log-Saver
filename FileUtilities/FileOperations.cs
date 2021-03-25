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

        public static ZipArchive OpenZipArchive(string path)
        {
            return ZipFile.Open(path, ZipArchiveMode.Create);
        }

        public static string GetDriveFromPath(string path)
        {
            return Path.GetPathRoot(path);
        }

        public static long GetDriveAvailableBytes(string drive)
        {
            return new DriveInfo(drive).AvailableFreeSpace;
        }

        public static long GetDriveTotalBytes(string drive)
        {
            return new DriveInfo(drive).TotalSize;
        }

        public static string[] GetFileNamesInDirectory(string path)
        {
            return Directory.GetFiles(path).Select(p => Path.GetFileName(p)).ToArray();
        }

        public static string[] GetFileNamesInDirectory(string path, string extension)
        {
            return GetFileNamesInDirectory(path)
                .Where(f => Path.GetExtension(f).ToLower() == extension.ToLower())
                .ToArray();
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
                    // filter by time range
                    if (timeRangeLocal.IsWithinRange(File.GetLastWriteTime(path)) ||
                        timeRangeLocal.IsWithinRange(File.GetCreationTime(path)))
                    {
                        filePathsFiltered.Add(path);
                    }
                }
            }
            return filePathsFiltered.ToArray();
        }

        public static FileCategory[] GetLogCategories(
            string directory, IFileCategorizationStrategy cStrategy)
        {
            var files = GetFileNamesInDirectory(directory);
            return new FileCategorizer().Categorize(files, cStrategy).ToArray();
        }

        public static long GetFileSizeInBytes(string filePath)
        {
            return File.ReadAllBytes(filePath).LongLength;
        }

        public static DateTime GetLastUpdateTime(string filePath)
        {
            return File.GetLastWriteTime(filePath);
        }
    }
}
