using System;
using LoggingLibrary;
using System.Net;
using System.Net.Sockets;
using TopshelfBoilerplate;
using System.IO;

namespace LogSaverServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string lsLogsPath = Path.Combine(AppSettings.LSLogsPath, "ls_logs.txt");
            string src = AppSettings.LogsSourcePath;
            string dst = AppSettings.LogsDestPath;
            IPAddress ip = IPAddress.Parse(GetLocalIPAddress());
            using (ILogger logger = new FileLogger(lsLogsPath, true))
            {
                IServiceWorker lsServer = new LogSaverServer(
                    ip, 1337, src, dst, logger);
                new TopshelfService(
                    "SWISSLOG_LOG_SAVER", "SWISSLOG_LOG_SAVER",
                    "App for archiving logs on the server")
                    .Run(lsServer);
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
