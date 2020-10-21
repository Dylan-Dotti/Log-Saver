using Messages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogSaverServer
{
    class LogSaverServer
    {
        public void StartServer(IPAddress ip, int port)
        {
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();
            Console.WriteLine($"The server is running at {ip}:{port}...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                // blocks here until a client connects
                Console.WriteLine("Received connection.");
                new Thread(HandleClient).Start(client);
            }
        }

        private void HandleClient(object client)
        {
            string src = @"C:\Users\Dylan\Desktop\Logs";
            string dst = @"C:\Users\Dylan\Desktop\59972.zip";
            FileOperator fOperator = new FileOperator();
            TcpClient clientLocal = (TcpClient)client;
            BinaryReader reader = new BinaryReader(clientLocal.GetStream());
            BinaryWriter writer = new BinaryWriter(clientLocal.GetStream());
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
                        new SaveRequestMessage();
                        // copy directory
                        Console.WriteLine("Zipping directory...");
                        //fOperator.ZipDirectory(src, dst);
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
                    clientLocal.Close();
                    break;
                }
            }
        }
    }
}
