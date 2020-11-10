using Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LogSaverServer
{
    class ClientRequestHandler
    {
        private BinaryTcpClient client;
        private FileOperator foperator;

        private readonly string logsSourcePath;
        private readonly string logsDestPath;

        public ClientRequestHandler(BinaryTcpClient client,
            string logsSourcePath, string logsDestPath)
        {
            this.client = client;
            foperator = new FileOperator();
        }

        public void HandleZipRequest(ZipRequestMessage request)
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
                string[] filePaths = foperator.GetFilteredFilePaths(logsSourcePath,
                    request.TimeRangeLocal, request.FullCategories);
                foperator.ZipFiles(filePaths, zipPath, client.Writer);
            }
        }

        public void HandleTransferRequest()
        {

        }

        private void SendResponseMessage(ResponseCode resCode, string message = "")
        {
            var response = new ResponseMessage(resCode, message);
            client.Writer.Write(response);
            FileLogger.Log("Sent response: " + response.ToString(true));
        }
    }
}
