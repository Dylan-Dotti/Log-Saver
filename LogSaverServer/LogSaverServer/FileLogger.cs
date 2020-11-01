using System;
using System.Configuration;
using System.IO;

namespace LogSaverServer
{
    static class FileLogger
    {
        private static readonly string logsDirectory = 
            ConfigurationManager.AppSettings.Get("LSLogsPath");
        private static readonly object logLockObject = new object();

        static FileLogger()
        {
            ClearLog();
        }

        public static void Log(string data)
        {
            string logsPath = Path.Combine(logsDirectory, "ls_logs.txt");
            lock (logLockObject)
            {
                File.AppendAllText(logsPath, data + Environment.NewLine);
            }
        }

        public static void ClearLog()
        {
            string logsPath = Path.Combine(logsDirectory, "ls_logs.txt");
            lock (logLockObject)
            {
                File.WriteAllText(logsPath, "");
            }
        }
    }
}
