using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogSaverClient
{
    public partial class FileOperationProgressForm : Form
    {
        private readonly LSClient client;
        private readonly FileOperationType operationType;
        private readonly MessageDecoder decoder;

        public FileOperationProgressForm(LSClient client,
            FileOperationType operationType)
        {
            InitializeComponent();
            this.client = client;
            this.operationType = operationType;
            decoder = new MessageDecoder();
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            operationLabel.Text =
                (operationType == FileOperationType.Zip ? "Zip" : "Transfer") +
                " operation in progress...";
            await HandleOperationUpdates();
            Close();
        }

        private async Task HandleOperationUpdates()
        {
            if (operationType == FileOperationType.Zip)
            {
                var receiver = new ZipOperationUpdateReceiver(client);
                receiver.ProgressUpdated += UpdateProgressDisplay;
                await receiver.HandleOperationUpdates();
            }
            else if (operationType == FileOperationType.Transfer)
            {
                var receiver = new TransferOperationUpdateReceiver(
                    client, @"C:\Users\h4dottd\Desktop\ReceivedLogs\");
                receiver.ProgressUpdated += UpdateProgressDisplay;
                await receiver.HandleOperationUpdates();
            }
            /*while (true)
            {
                string message = await client.AwaitMessageAsync();
                if (operationType == FileOperationType.Zip)
                {
                    ZipOperationMessage msgDecoded = decoder.DecodeMessage<ZipOperationMessage>(message);
                    UpdateProgressDisplay(msgDecoded.NumFilesCompleted, msgDecoded.NumTotalFiles);
                }
                else if (operationType == FileOperationType.Transfer)
                {
                    TransferOperationMessage msgDecoded = null;
                    await Task.Run(() =>
                    {
                        msgDecoded = decoder.DecodeMessage<TransferOperationMessage>(message);
                        Console.WriteLine("Received file: " + msgDecoded.FileName);
                    });
                    UpdateProgressDisplay(msgDecoded.NumFilesCompleted, msgDecoded.NumTotalFiles);
                }
            }*/
        }

        private void UpdateProgressDisplay(int numFilesCompleted, int numTotalFiles)
        {
            int percentComplete = (int)((float)numFilesCompleted / numTotalFiles * 100);
            operationProgressBar.BeginInvoke(
                new Action(() => operationProgressBar.Value = percentComplete));
            progressLabel.BeginInvoke(
                new Action(() => progressLabel.Text = percentComplete + "% completed"));
            ;
        }
    }
}
