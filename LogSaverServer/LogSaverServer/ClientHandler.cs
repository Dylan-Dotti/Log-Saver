using Messages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace LogSaverServer
{
    class ClientHandler
    {
        private readonly TcpClient client;
        private readonly BinaryReader reader;
        private readonly BinaryWriter writer;

        private readonly FileOperator fileOperator;
        private readonly string logsSourcePath;
        private readonly string logsDestPath;

        public ClientHandler(TcpClient client, string logsSourcePath, string logsDestPath)
        {
            this.client = client;
            this.logsSourcePath = logsSourcePath;
            this.logsDestPath = logsDestPath;
            fileOperator = new FileOperator();
            reader = new BinaryReader(client.GetStream());
            writer = new BinaryWriter(client.GetStream());
        }

        public void HandleClient()
        {
            try
            {
                while (true)
                {
                    string request = reader.ReadString();
                    // blocks here until client sends a request
                    Console.WriteLine("Request: " + request);
                    JObject requestJson = JObject.Parse(request);
                    MessageType msgType = requestJson.Value<string>("MessageType").ToMessageType();
                    if (msgType == MessageType.SaveRequest)
                    {
                        // zip directory
                        var filePaths = fileOperator.GetFilePathsInDirectory(logsSourcePath);
                        // send response
                        var response = new ResponseMessage(ResponseCode.Ok).ToString();
                        writer.Write(response);
                        Console.WriteLine("Sent response: " + response);
                        fileOperator.ZipFiles(filePaths, logsDestPath, writer);
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
                client.Close();
            }
        }
    }
}
