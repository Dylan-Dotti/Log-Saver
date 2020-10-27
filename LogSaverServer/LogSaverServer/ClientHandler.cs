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

        private readonly MessageDecoder decoder;
        private readonly FileOperator fileOperator;
        private readonly string logsSourcePath;
        private readonly string logsDestPath;

        public ClientHandler(TcpClient client, string logsSourcePath, string logsDestPath)
        {
            this.client = client;
            this.logsSourcePath = logsSourcePath;
            this.logsDestPath = logsDestPath;
            decoder = new MessageDecoder();
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
                    if (decoder.TryDecodeMessage(request, out SaveRequestMessage decodedSR))
                    {
                        string[] filePaths = fileOperator.GetFilePathsInDirectory(logsSourcePath);
                        string zipPath = Path.Combine(logsDestPath, decodedSR.ZipFileName);
                        if (File.Exists(zipPath))
                        {
                            SendResponseMessage(ResponseCode.Error,
                                $"Zip archive with the name {decodedSR.ZipFileName} already exists.");
                        }
                        else
                        {
                            // send response
                            SendResponseMessage(ResponseCode.Ok);
                            // zip directory
                            fileOperator.ZipFiles(filePaths, zipPath, writer);
                        }
                    }
                    else
                    {
                        SendResponseMessage(ResponseCode.Error, "Invalid message received");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Connection with client lost.");
                client.Close();
            }
        }

        private void SendResponseMessage(ResponseCode resCode, string message = "")
        {
            var response = new ResponseMessage(resCode, message);
            writer.Write(response);
            Console.WriteLine("Sent response: " + response.ToString(true));
        }
    }
}
