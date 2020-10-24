using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Topshelf;

namespace LogSaverServer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var exitCode = HostFactory.Run(x =>
            {
                x.Service
            });*/
            IPAddress ip = IPAddress.Parse(GetLocalIPAddress());
            new LogSaverServer(ip, 1337,
                @"C:\Users\Dylan\Desktop\Logs\",
                @"C:\Users\Dylan\Desktop\LogsBackup\59972.zip")
                .Start();
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
