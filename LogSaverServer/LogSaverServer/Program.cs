using System;
using System.Collections.Generic;
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
            string src = @"C:\Users\Dylan\Desktop\test_m_logs\";
            string dst = @"C:\Users\Dylan\Desktop\LogsBackup\";
            /*FileOperator fOp = new FileOperator();
            foreach (string category in fOp.GetLogCategories(src))
            {
                Console.WriteLine(category);
            }*/
            IPAddress ip = IPAddress.Parse(GetLocalIPAddress());
            new LogSaverServer(ip, 1337, src, dst).Start();
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
