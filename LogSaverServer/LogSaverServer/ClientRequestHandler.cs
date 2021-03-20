using FileUtilities;
using LoggingLibrary;
using Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using TcpLibrary;

namespace LogSaverServer
{
    class ClientRequestHandler
    {
        private readonly BinaryTcpClient client;

        private readonly string logsSourcePath;
        private readonly string logsDestPath;
        private readonly ILogger logger;

        public ClientRequestHandler(BinaryTcpClient client,
            string logsSourcePath, string logsDestPath,
            ILogger logger)
        {
            this.client = client;
            this.logsSourcePath = logsSourcePath;
            this.logsDestPath = logsDestPath;
            this.logger = logger;
        }

        public void HandleZipRequest(ZipRequestMessage request)
        {
            string zipPath = Path.Combine(logsDestPath, request.ZipFileName);
            string[] filePaths = FileOperations.GetFilteredFilePaths(logsSourcePath,
                request.TimeRangeLocal, request.FullCategories);
            if (filePaths.Length == 0)
            {
                SendResponseMessage(ResponseCode.Error,
                    "No files found that match request");
                return;
            }
            if (File.Exists(zipPath))
            {
                SendResponseMessage(ResponseCode.Error,
                    $"Zip archive with the name {request.ZipFileName} already exists.");
                return;
            }
            // send response
            SendResponseMessage(ResponseCode.Ok);
            // Open zip archive if it does not already exist
            logger.Log("Creating zip archive: " + zipPath);
            using (ZipArchive archive = FileOperations.OpenZipArchive(zipPath))
            {
                // track number of files that could not be processed
                int numSkipped = 0;
                logger.Log("Beginning zip operation...");
                // Loop through the input files and zip one by one. Report progress to client through writer.
                for (int i = 0; i < filePaths.Length; i++)
                {
                    string path = filePaths[i];
                    try
                    {
                        if (!File.Exists(path) ||
                            request.TimeRangeLocal.IsAfterRange(File.GetCreationTime(path)))
                        {
                            // file was deleted while processing and/or recreated
                            logger.Log($"File {path} was deleted during the operation. Skipping");
                            numSkipped += 1;
                        }
                        else
                        {
                            logger.Log("Zipping file: " + path);
                            archive.CreateEntryFromFile(path, Path.GetFileName(path));
                        }
                        // report progress to the client
                        var message = new ZipOperationMessage(
                            i + 1 - numSkipped, filePaths.Length - numSkipped);
                        client.Writer.Write(message);

                    }
                    catch (Exception e)
                    {
                        logger.Log($"Error while zipping {path}. Zip operation cancelled");
                        logger.Log(e.ToString());
                        File.Delete(zipPath);
                        break;
                    }
                }
                logger.Log("Zip operation complete");
            }
        }

        public void HandleTransferRequest(TransferRequestMessage request)
        {
            string[] filePaths = FileOperations.GetFilteredFilePaths(logsSourcePath,
                request.TimeRangeLocal, request.FullCategories);
            if (filePaths.Length == 0)
            {
                SendResponseMessage(ResponseCode.Error,
                    "No files found that match request");
                return;
            }
            // send response
            SendResponseMessage(ResponseCode.Ok);
            // transfer files
            logger.Log("Transferring files...");
            for (int i = 0; i < filePaths.Length; i++)
            {
                string path = filePaths[i];
                logger.Log("Transferring: " + path);
                string fileName = Path.GetFileName(path);
                byte[] fileBytes = File.ReadAllBytes(path);
                byte[] fileBytesCompressed = ByteCompression.GZipCompress(fileBytes);
                var message = new TransferOperationMessage(
                    i + 1, filePaths.Length, fileName, fileBytesCompressed);
                client.Writer.Write(message);
            }
            logger.Log("Transfer operation complete");
        }

        private void SendResponseMessage(ResponseCode resCode, string message = "")
        {
            var response = new ResponseMessage(resCode, message);
            client.Writer.Write(response);
            logger.Log("Sent response: " + response.ToString(true));
        }
    }
}
