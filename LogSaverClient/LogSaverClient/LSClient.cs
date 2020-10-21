using Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogSaverClient
{
    public class LSClient : TcpClient
    {
        private readonly BinaryWriter writer;
        private readonly BinaryReader reader;

        public LSClient() : base()
        {
            writer = new BinaryWriter(GetStream());
            reader = new BinaryReader(GetStream());
        }

        public async Task<string> SendMessage(LogSaverMessage message)
        {
            writer.Write(message.ToJsonString());
            return await Task.Run(() => 
            {
                string response = reader.ReadString();
                return response;
            });
        }
        /*public void Start(IPAddress ip, int port)
        {
            TcpClient client = new TcpClient();
            Console.WriteLine("Connecting...");
            client.Connect(ip, port);
            Console.WriteLine($"Connected to {ip}:{port}");
            /*BinaryWriter writer = new BinaryWriter(client.GetStream());
            BinaryReader reader = new BinaryReader(client.GetStream());
            try
            {
                while (true)
                {
                    string json = "{ 'MessageType' : 'SaveRequest' }";
                    Console.WriteLine("Enter a message to send: " + json);
                    string request = json; //Console.ReadLine();
                    writer.Write(request);
                    Thread.Sleep(2000);
                    string response = reader.ReadString();
                    Console.WriteLine("Response: " + response);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Console.WriteLine("Connection ended.");
        }*/
    }
}
