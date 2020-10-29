using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogSaverClient
{
    class FileOperationRequestManager
    {
        private readonly LSClient client;
        private readonly MessageDecoder decoder;

        public FileOperationRequestManager(LSClient client)
        {
            this.client = client;
            decoder = new MessageDecoder();
        }

        public async Task SendAndManageZipRequest(string zipFileName)
        {
            zipFileName = zipFileName.Trim();
            // append .zip if the string does not end with it
            if (!zipFileName.ToLower().EndsWith(".zip")) zipFileName += ".zip";

            // create and send request
            var request = new ZipRequestMessage(zipFileName);
            var resDecoded = await SendRequestAndAwaitResponse(request);

            // process response
            if (resDecoded.ResCode == ResponseCode.Ok)
            {
                new FileOperationProgressForm(
                    new ZipOperationUpdateReceiver(client)).ShowDialog();
            }
            else if (resDecoded.ResCode == ResponseCode.Error)
            {
                MessageBox.Show("Your request was rejected by the server.\n" +
                    "Reason: " + resDecoded.ErrorMessage,
                    "Request Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task SendAndManageTransferRequest()
        {
            // create and send request
            var request = new TransferRequestMessage();
            var response = await SendRequestAndAwaitResponse(request);

            // process response
            if (response.ResCode == ResponseCode.Ok)
            {
                new FileOperationProgressForm(
                    new TransferOperationUpdateReceiver(client,
                        @"C:\Users\h4dottd\Desktop\ReceivedLogs\")).ShowDialog();
            }
            else if (response.ResCode == ResponseCode.Error)
            {
                MessageBox.Show("Your request was rejected by the server.\n" +
                    "Reason: " + response.ErrorMessage,
                    "Request Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<ResponseMessage> SendRequestAndAwaitResponse(
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
