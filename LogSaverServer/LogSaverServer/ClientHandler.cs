using FileUtilities;
using LoggingLibrary;
using Messages;
using System;
using System.IO;
using TcpLibrary;

namespace LogSaverServer
{
    class ClientHandler
    {
        private readonly BinaryTcpClient client;
        private readonly ClientRequestHandler requestHandler;
        private readonly MessageDecoder decoder;

        private readonly string logsSourcePath;
        private readonly string logsDestPath;
        private readonly ILogger logger;

        private readonly IFileCategorizationStrategy categorizationStrategy;

        public ClientHandler(BinaryTcpClient client,
            string logsSourcePath, string logsDestPath,
            ILogger logger)
        {
            this.client = client;
            this.logsSourcePath = logsSourcePath;
            this.logsDestPath = logsDestPath;
            this.logger = logger;
            requestHandler = new ClientRequestHandler(
                client, logsSourcePath, logsDestPath, this.logger);
            decoder = new MessageDecoder();
            categorizationStrategy = GetCategorizationStrategy();
        }

        public void HandleClient()
        {
            try
            {
                while (true)
                {
                    logger.Log("Waiting for user request...");
                    string request = client.Reader.ReadString();
                    // blocks here until client sends a request
                    logger.Log("Request: " + request);
                    if (decoder.TryDecodeMessage(request, out ZipRequestMessage decodedZR))
                    {
                        logger.Log("Decoded message as ZipRequest");
                        requestHandler.HandleZipRequest(decodedZR);
                    }
                    else if (decoder.TryDecodeMessage(request, out TransferRequestMessage decodedTR))
                    {
                        logger.Log("Decoded message as TransferRequest");
                        requestHandler.HandleTransferRequest(decodedTR);
                    }
                    else if (decoder.TryDecodeMessage(request, out ServerInfoRequestMessage decodedSIR))
                    {
                        logger.Log("Decoded message as ServerInfoRequest");
                        requestHandler.HandleServerInfoRequest(decodedSIR, categorizationStrategy);
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
                logger.Log(e.ToString());
            }
            finally
            {
                client.Client.Close();
                logger.Log("Connection with client closed.");
            }
        }

        private void SendResponseMessage(ResponseCode resCode, string message = "")
        {
            var response = new ResponseMessage(resCode, message);
            client.Writer.Write(response);
            logger.Log("Sent response: " + response.ToString(true));
        }

        private IFileCategorizationStrategy GetCategorizationStrategy()
        {
            string strategyStr = AppSettings.CategorizationStrategy;
            if (strategyStr == "FirstSegment") return new FirstSegmentCategorization();
            else if (strategyStr == "LastSegment") return new LastSegmentCategorization();
            return null;
        }
    }
}
