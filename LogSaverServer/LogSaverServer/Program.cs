using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Topshelf;

namespace LogSaverServer
{
    class Program
    {
        static void Main(string[] args)
        {
            FileOperator op = new FileOperator();
            foreach (var category in op.GetLogCategories(
                ConfigurationManager.AppSettings.Get("LogsSourcePath")))
            {
                Console.WriteLine(category);
            }
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<LogSaverServer>(s =>
                {
                    s.ConstructUsing(server =>
                    {
                        string src = ConfigurationManager.AppSettings.Get("LogsSourcePath");
                        string dst = ConfigurationManager.AppSettings.Get("LogsDestPath");
                        IPAddress ip = IPAddress.Parse(GetLocalIPAddress());
                        return new LogSaverServer(ip, 1337, src, dst);
                    });
                    s.WhenStarted(server => server.Start());
                    s.WhenStopped(server => server.Stop());
                });

                x.SetServiceName("SWISSLOG_LOG_SAVER");
                x.SetDisplayName("SWISSLOG_LOG_SAVER");
                x.SetDescription("App for archiving logs on the server");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
            Console.ReadKey();
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
