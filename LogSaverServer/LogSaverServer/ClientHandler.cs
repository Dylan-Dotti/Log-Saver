using FileUtilities;
using Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace LogSaverServer
{
    class ClientHandler
    {
        private readonly BinaryTcpClient client;
        private readonly ClientRequestHandler requestHandler;

        private readonly MessageDecoder decoder;
        private readonly string logsSourcePath;
        private readonly string logsDestPath;

        public ClientHandler(BinaryTcpClient client, string logsSourcePath, string logsDestPath)
        {
            this.client = client;
            this.logsSourcePath = logsSourcePath;
            this.logsDestPath = logsDestPath;
            requestHandler = new ClientRequestHandler(client, logsSourcePath, logsDestPath);
            decoder = new MessageDecoder();
        }

        public void HandleClient()
        {
            try
            {
                ServerInfoMessage serverInfo = new ServerInfoMessage(
                    FileOperations.GetLogCategories(logsSourcePath));
                client.Writer.Write(serverInfo);
                FileLogger.Log("Sent server info");
                while (true)
                {
                    FileLogger.Log("Waiting for user request...");
                    string request = client.Reader.ReadString();
                    // blocks here until client sends a request
                    FileLogger.Log("Request: " + request);
                    if (decoder.TryDecodeMessage(request, out ZipRequestMessage decodedZR))
                    {
                        FileLogger.Log("Decoded message as ZipRequest");
                        requestHandler.HandleZipRequest(decodedZR);
                    }
                    else if (decoder.TryDecodeMessage(request, out TransferRequestMessage decodedTR))
                    {
                        FileLogger.Log("Decoded message as TransferRequest");
                        requestHandler.HandleTransferRequest(decodedTR);
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
                client.Client.Close();
                FileLogger.Log("Connection with client closed.");
            }
        }

        private void SendResponseMessage(ResponseCode resCode, string message = "")
        {
            var response = new ResponseMessage(resCode, message);
            client.Writer.Write(response);
            FileLogger.Log("Sent response: " + response.ToString(true));
        }
    }
}
