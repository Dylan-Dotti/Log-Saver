using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LogSaverServer
{
    class ClientHandler
    {
        private readonly TcpClient client;
        private readonly string logsSourcePath;
        private readonly string logsDestPath;

        public ClientHandler(TcpClient client, string logsSourcePath, string logsDestPath)
        {
            string src = @"C:\Users\Dylan\Desktop\test_m_logs";
            string dst = @"C:\Users\Dylan\Desktop\59972.zip";
            FileOperator fileOperator = new FileOperator();
            BinaryReader reader = new BinaryReader(client.GetStream());
            BinaryWriter writer = new BinaryWriter(client.GetStream());
            while (true)
            {
                try
                {
                    string request = reader.ReadString();
                    Console.WriteLine("Request: " + request);
                    JObject requestJson = JObject.Parse(request);
                    MessageType msgType = requestJson.Value<string>("MessageType").ToMessageType();
                    if (msgType == MessageType.SaveRequest)
                    {
                        // zip directory
                        Console.WriteLine("Zipping directory...");
                        fileOperator.ZipDirectory(src, dst);
                        Console.WriteLine("Zip Complete");
                    }

                    // send response
                    string response = "000";
                    writer.Write(response);
                    Console.WriteLine("Sent response: " + response);
                }
                catch (Exception)
                {
                    Console.WriteLine("Connection with client lost.");
                    client.Close();
                    break;
                }
            }
        }

        public void HandleClient()
        {

        }

        private void HandleClientWork()
        {

        }
    }
}
