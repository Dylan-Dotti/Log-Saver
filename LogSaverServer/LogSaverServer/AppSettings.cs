using System.Configuration;

namespace LogSaverServer
{
    static class AppSettings
    {
        public static string LSLogsPath { get; private set; }
        public static string LogsSourcePath { get; private set; }
        public static string LogsDestPath { get; private set; }
        public static string CategorizationStrategy { get; private set; }

        static AppSettings()
        {
            LSLogsPath = ConfigurationManager.AppSettings.Get("LSLogsPath");
            LogsSourcePath = ConfigurationManager.AppSettings.Get("LogsSourcePath");
            LogsDestPath = ConfigurationManager.AppSettings.Get("LogsDestPath");
            CategorizationStrategy = ConfigurationManager.AppSettings.Get("CategorizationStrategy");
        }
    }
}
