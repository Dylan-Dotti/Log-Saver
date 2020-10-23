using Messages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogSaverServer
{
    class ClientHandler
    {
        private readonly TcpClient client;
        private readonly string logsSourcePath;
        private readonly string logsDestPath;
        private Thread workThread;

        public ClientHandler(TcpClient client, string logsSourcePath, string logsDestPath)
        {
            this.client = client;
            this.logsSourcePath = logsSourcePath;
            this.logsDestPath = logsDestPath;
        }

        public void HandleClientThreaded()
        {
            workThread = new Thread(HandleClientWork);
            workThread.Start();
        }

        private void HandleClientWork()
        {
            FileOperator fileOperator = new FileOperator();
            BinaryReader reader = new BinaryReader(client.GetStream());
            BinaryWriter writer = new BinaryWriter(client.GetStream());
            try
            {
                while (true)
                {
                    string request = reader.ReadString();
                    Console.WriteLine("Request: " + request);
                    JObject requestJson = JObject.Parse(request);
                    MessageType msgType = requestJson.Value<string>("MessageType").ToMessageType();
                    if (msgType == MessageType.SaveRequest)
                    {
                        // zip directory
                        Console.WriteLine("Zipping logs...");
                        fileOperator.ZipDirectory(logsSourcePath, logsDestPath);
                        Console.WriteLine("Zip Complete");
                        // send response
                        var response = new ResponseMessage(ResponseCode.Ok).ToString();
                        writer.Write(response);
                        Console.WriteLine("Sent response: " + response);
                    }
                    else
                    {
                        var response = new ResponseMessage(ResponseCode.Error).ToString();
                        writer.Write(response);
                        Console.WriteLine("Sent response: " + response);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Connection with client lost.");
            }
        }
    }
}
