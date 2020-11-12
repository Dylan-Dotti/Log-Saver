using FileUtilities;
using Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace LogSaverServer
{
    class ClientRequestHandler
    {
        private readonly BinaryTcpClient client;

        private readonly string logsSourcePath;
        private readonly string logsDestPath;

        public ClientRequestHandler(BinaryTcpClient client,
            string logsSourcePath, string logsDestPath)
        {
            this.client = client;
            this.logsSourcePath = logsSourcePath;
            this.logsDestPath = logsDestPath;
        }

        public void HandleZipRequest(ZipRequestMessage request)
        {
            string zipPath = Path.Combine(logsDestPath, request.ZipFileName);
            if (File.Exists(zipPath))
            {
                SendResponseMessage(ResponseCode.Error,
                    $"Zip archive with the name {request.ZipFileName} already exists.");
                return;
            }
            // send response
            SendResponseMessage(ResponseCode.Ok);
            // zip directory
            string[] filePaths = FileOperations.GetFilteredFilePaths(logsSourcePath,
                request.TimeRangeLocal, request.FullCategories);
            // Open zip archive if it does not already exist
            FileLogger.Log("Creating zip archive: " + zipPath);
            using (ZipArchive archive = FileOperations.CreateZipArchive(zipPath))
            {
                FileLogger.Log("Beginning zip operation...");
                // Loop through the input files and zip one by one. Report progress to client through writer.
                for (int i = 0; i < filePaths.Length; i++)
                {
                    string path = filePaths[i];
                    try
                    {
                        FileLogger.Log("Zipping file: " + path);
                        archive.CreateEntryFromFile(path, Path.GetFileName(path));
                        // report progress to the client
                        client.Writer.Write(new ZipOperationMessage(i + 1, filePaths.Length));
                    }
                    catch (Exception e)
                    {
                        FileLogger.Log($"Error while zipping {path}. Zip operation aborted");
                        FileLogger.Log(e.Message);
                        File.Delete(zipPath);
                        break;
                    }
                }
                FileLogger.Log("Zip operation complete");
            }
        }

        public void HandleTransferRequest(TransferRequestMessage request)
        {
            // send response
            SendResponseMessage(ResponseCode.Ok);
            // transfer files
            string[] filePaths = FileOperations.GetFilteredFilePaths(logsSourcePath,
                request.TimeRangeLocal, request.FullCategories);
            FileLogger.Log("Transferring files...");
            for (int i = 0; i < filePaths.Length; i++)
            {
                string path = filePaths[i];
                FileLogger.Log("Transferring: " + path);
                string fileName = Path.GetFileName(path);
                byte[] fileBytes = File.ReadAllBytes(path);
                var message = new TransferOperationMessage(
                    i + 1, filePaths.Length, fileName, fileBytes);
                client.Writer.Write(message);
            }
            FileLogger.Log("Transfer operation complete");
        }

        private void SendResponseMessage(ResponseCode resCode, string message = "")
        {
            var response = new ResponseMessage(resCode, message);
            client.Writer.Write(response);
            FileLogger.Log("Sent response: " + response.ToString(true));
        }
    }
}
