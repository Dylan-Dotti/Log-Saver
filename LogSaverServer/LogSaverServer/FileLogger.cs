using System.Configuration;
using System.IO;

namespace LogSaverServer
{
    static class FileLogger
    {
        private static readonly string logsDirectory = 
            ConfigurationManager.AppSettings.Get("LSLogsPath");

        static FileLogger()
        {
            ClearLog();
        }

        public static void Log(string data)
        {
            string logsPath = Path.Combine(logsDirectory, "ls_logs.txt");
            using (var fileWriter = new StreamWriter(logsPath, true))
            {
                fileWriter.WriteLine(data);
            }
        }

        public static void ClearLog()
        {
            string logsPath = Path.Combine(logsDirectory, "ls_logs.txt");
            File.WriteAllText(logsPath, "");
        }
    }
}
