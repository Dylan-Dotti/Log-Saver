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
        private readonly IPAddress ip;
        private readonly int port;
        private readonly string logSourcePath;
        private readonly string logDestPath;

        public LogSaverServer(IPAddress ip, int port,
            string logSourcePath, string logDestPath)
        {
            this.ip = ip;
            this.port = port;
            this.logSourcePath = logSourcePath;
            this.logDestPath = logDestPath;
        }

        public void StartServer()
        {
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();
            Console.WriteLine($"The server is running at {ip}:{port}...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                // blocks here until a client connects
                Console.WriteLine("Received connection.");
                //new Thread(HandleClient).Start(client);
                new Thread(() => new ClientHandler(client, logSourcePath, logDestPath).HandleClient()).Start();
            }
        }

        private void HandleClient(object client)
        {
            string src = @"C:\Users\Dylan\Desktop\Logs";
            string dst = @"C:\Users\Dylan\Desktop\LogsBackup\59972.zip";
            FileOperator fileOperator = new FileOperator();
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
                        // zip directory
                        Console.WriteLine("Zipping directory...");
                        //fileOperator.ZipDirectory(src, dst);
                        Console.WriteLine("Zip Complete");
                    }

                    // send response
                    string response = ResponseCode.Ok.ToIntString();
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
