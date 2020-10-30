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
                    FileLogger.Log("Waiting for user request...");
                    string request = reader.ReadString();
                    // blocks here until client sends a request
                    FileLogger.Log("Request: " + request);
                    if (decoder.TryDecodeMessage(request, out ZipRequestMessage decodedZR))
                    {
                        FileLogger.Log("Decoded message as ZipRequest");
                        string zipPath = Path.Combine(logsDestPath, decodedZR.ZipFileName);
                        if (File.Exists(zipPath))
                        {
                            SendResponseMessage(ResponseCode.Error,
                                $"Zip archive with the name {decodedZR.ZipFileName} already exists.");
                        }
                        else
                        {
                            // send response
                            SendResponseMessage(ResponseCode.Ok);
                            // zip directory
                            string[] filePaths = fileOperator.GetFilePathsInDirectory(logsSourcePath);
                            fileOperator.ZipFiles(filePaths, zipPath, writer);
                        }
                    }
                    else if (decoder.TryDecodeMessage(request, out TransferRequestMessage decodedTR))
                    {
                        FileLogger.Log("Decoded message as TransferRequest");
                        // send response
                        SendResponseMessage(ResponseCode.Ok);
                        // transfer files
                        string[] filePaths = fileOperator.GetFilePathsInDirectory(logsSourcePath);
                        fileOperator.TransferFiles(filePaths, writer);
                    }
                    else
                    {
                        SendResponseMessage(ResponseCode.Error, "Invalid message received");
                    }
                }
            }
            catch (Exception e)
            {
                FileLogger.Log(e.Message);
                FileLogger.Log(e.StackTrace);
                client.Close();
                FileLogger.Log("Connection with client closed.");
            }
        }

        private void SendResponseMessage(ResponseCode resCode, string message = "")
        {
            var response = new ResponseMessage(resCode, message);
            writer.Write(response);
            FileLogger.Log("Sent response: " + response.ToString(true));
        }
    }
}
