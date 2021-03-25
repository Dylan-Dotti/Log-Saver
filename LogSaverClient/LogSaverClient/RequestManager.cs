using Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeUtilities;

namespace LogSaverClient
{
    class RequestManager
    {
        private readonly LSClient client;
        private readonly MessageDecoder decoder;

        public RequestManager(LSClient client)
        {
            this.client = client;
            decoder = new MessageDecoder();
        }

        public async Task<ServerInfoMessage> RetrieveServerInfo()
        {
            client.SendMessage(new ServerInfoRequestMessage());
            string message = await client.AwaitMessageAsync();
            return decoder.DecodeMessage<ServerInfoMessage>(message);
        }

        public async Task<bool> SendAndManageZipRequest(string zipFileName,
            DateTimeRange timeRange, string[] fullCategories)
        {
            zipFileName = zipFileName.Trim();
            // append .zip if the string does not end with it
            if (!zipFileName.ToLower().EndsWith(".zip")) zipFileName += ".zip";

            // create and send request
            var request = new ZipRequestMessage(zipFileName, timeRange, fullCategories);
            var resDecoded = await SendRequestAwaitResponse(request);

            // process response
            if (resDecoded.ResCode == ResponseCode.Ok)
            {
                new FileOperationProgressForm(
                    new ZipOperationUpdateReceiver(client)).ShowDialog();
                return true;
            }
            else if (resDecoded.ResCode == ResponseCode.Error)
            {
                MessageBox.Show("Your request was rejected by the server.\n" +
                    "Reason: " + resDecoded.ErrorMessage,
                    "Request Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public async Task<bool> SendAndManageTransferRequest(
            string localDstPath, DateTimeRange timeRange, string[] fullCategories,
            bool zipLocal)
        {
            if (zipLocal && !localDstPath.EndsWith(".zip")) localDstPath += ".zip";
            // create and send request
            var request = new TransferRequestMessage(timeRange, fullCategories);
            var response = await SendRequestAwaitResponse(request);

            // process response
            if (response.ResCode == ResponseCode.Ok)
            {
                if (zipLocal && File.Exists(localDstPath)) File.Delete(localDstPath);
                else if (Directory.Exists(localDstPath)) Directory.Delete(localDstPath);
                new FileOperationProgressForm(
                    new TransferOperationUpdateReceiver(client, localDstPath, zipLocal))
                    .ShowDialog();
                return true;
            }
            else if (response.ResCode == ResponseCode.Error)
            {
                MessageBox.Show("Your request was rejected by the server.\n" +
                    "Reason: " + response.ErrorMessage,
                    "Request Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private async Task<ResponseMessage> SendRequestAwaitResponse(
            FileOperationRequestMessage requestMessage)
        {
            // create and send request
            client.SendMessage(requestMessage);
            Console.WriteLine("Message sent. Awaiting response...");

            // wait for response and decode
            string response = await client.AwaitMessageAsync();
            ResponseMessage resDecoded = decoder.DecodeMessage<ResponseMessage>(response);
            return resDecoded;
        }
    }
}
