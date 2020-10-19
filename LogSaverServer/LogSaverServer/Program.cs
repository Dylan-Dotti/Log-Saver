using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LogSaverServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetLocalIPAddress());
            IPAddress ip = IPAddress.Parse(GetLocalIPAddress());
            new LogSaverServer().StartServer(ip, 1337);
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
