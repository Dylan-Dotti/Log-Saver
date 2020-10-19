using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LogSaverClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IPAddress ip;
                while (true)
                {
                    Console.Write("Enter an ip to connect to: ");
                    string ipInput = Console.ReadLine();
                    if (ipInput.IsIPv4Format() && IPAddress.TryParse(ipInput, out ip)) break;
                    else Console.WriteLine("Invalid ip entered.");
                }
                try
                {
                    new LogSaverClient().Start(ip, 1337);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Connection to {ip} failed.");
                }
            }
        }
    }
}
