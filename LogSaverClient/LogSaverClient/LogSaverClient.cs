using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LogSaverClient
{
    class LogSaverClient
    {
        public void Start(IPAddress ip, int port)
        {
            TcpClient client = new TcpClient();
            Console.WriteLine("Connecting...");
            client.Connect(ip, port);
            Console.WriteLine($"Connected to {ip}:{port}");
            BinaryWriter writer = new BinaryWriter(client.GetStream());
            BinaryReader reader = new BinaryReader(client.GetStream());
            while (true)
            {
                Console.Write("Enter a message to send: ");
                string request = Console.ReadLine();
                writer.Write(request);
                string response = reader.ReadString();
                Console.WriteLine("Response: " + response);
            }
        }
    }
}
