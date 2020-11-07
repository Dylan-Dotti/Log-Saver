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
        private readonly FileOperator fileOp;
        private readonly string logsSourcePath;
        private readonly string logsDestPath;

        public ClientHandler(TcpClient client, string logsSourcePath, string logsDestPath)
        {
            this.client = client;
            this.logsSourcePath = logsSourcePath;
            this.logsDestPath = logsDestPath;
            decoder = new MessageDecoder();
            fileOp = new FileOperator();
            reader = new BinaryReader(client.GetStream());
            writer = new BinaryWriter(client.GetStream());
        }

        public void HandleClient()
        {
            try
            {
                ServerInfoMessage serverInfo = new ServerInfoMessage(
                    fileOp.GetLogCategories(logsSourcePath));
                writer.Write(serverInfo);
                FileLogger.Log("Sent server info");
                while (true)
                {
                    FileLogger.Log("Waiting for user request...");
                    string request = reader.ReadString();
                    // blocks here until client sends a request
                    FileLogger.Log("Request: " + request);
                    if (decoder.TryDecodeMessage(request, out ZipRequestMessage decodedZR))
                    {
                        FileLogger.Log("Decoded message as ZipRequest");
                        HandleZipRequest(decodedZR);
                    }
                    else if (decoder.TryDecodeMessage(request, out TransferRequestMessage decodedTR))
                    {
                        FileLogger.Log("Decoded message as TransferRequest");
                        HandleTransferRequest(decodedTR);
                    }
                    else
                    {
                        SendResponseMessage(ResponseCode.Error, "Invalid message received");
                    }
                }
            }
            catch (EndOfStreamException)
            {
                // disconnected from client
            }
            catch (Exception e)
            {
                FileLogger.Log(e.ToString());
            }
            finally
            {
                client.Close();
                FileLogger.Log("Connection with client closed.");
            }
        }

        private void HandleZipRequest(ZipRequestMessage request)
        {
            string zipPath = Path.Combine(logsDestPath, request.ZipFileName);
            if (File.Exists(zipPath))
            {
                SendResponseMessage(ResponseCode.Error,
                    $"Zip archive with the name {request.ZipFileName} already exists.");
            }
            else
            {
                // send response
                SendResponseMessage(ResponseCode.Ok);
                // zip directory
                string[] filePaths = fileOp.GetFilteredFilePaths(logsSourcePath, 
                    request.TimeRangeLocal, request.FullCategories);
                fileOp.ZipFiles(filePaths, zipPath, writer);
            }
        }

        private void HandleTransferRequest(TransferRequestMessage request)
        {
            // send response
            SendResponseMessage(ResponseCode.Ok);
            // transfer files
            string[] filePaths = fileOp.GetFilteredFilePaths(logsSourcePath,
                request.TimeRangeLocal, request.FullCategories);
            fileOp.TransferFiles(filePaths, writer);
        }

        private void SendResponseMessage(ResponseCode resCode, string message = "")
        {
            var response = new ResponseMessage(resCode, message);
            writer.Write(response);
            FileLogger.Log("Sent response: " + response.ToString(true));
        }
    }
}
