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
    public class LSClient
    {
        private readonly TcpClient client;
        private BinaryWriter writer;
        private BinaryReader reader;

        public LSClient()
        {
            client = new TcpClient();
        }

        ~LSClient()
        {
            client.Close();
        }

        public async Task<bool> TryConnectAsync(IPAddress address, int port)
        {
            try
            {
                await client.ConnectAsync(address, port);
                writer = new BinaryWriter(client.GetStream());
                reader = new BinaryReader(client.GetStream());
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection failed:");
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public void Close()
        {
            client.Close();
        }

        public void SendMessage(LogSaverMessage message)
        {
            writer.Write(message.ToString());
        }

        public async Task<string> AwaitMessageAsync()
        {
            return await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        string response = reader.ReadString();
                        return response;
                    }
                    catch (EndOfStreamException)
                    {
                        Console.WriteLine("No data read from stream. Waiting...");
                        Thread.Sleep(1000);
                    }
                }
                throw new TimeoutException("Operation timed out after 10 attempts");
            });
        }
    }
}
