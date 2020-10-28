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
            await HandleOperationUpdates();
            Close();
        }

        private async Task HandleOperationUpdates()
        {
            operationLabel.Text =
                (operationType == FileOperationType.Zip ? "Zip" : "Transfer") +
                " operation in progress...";
            int percentComplete = 0;
            while (percentComplete < 100)
            {
                string message = await client.AwaitMessageAsync();
                if (operationType == FileOperationType.Zip)
                {
                    ZipOperationMessage msgDecoded = decoder.DecodeMessage<ZipOperationMessage>(message);
                    percentComplete = (int)((float)msgDecoded.NumFilesCompleted / msgDecoded.NumTotalFiles * 100);
                    UpdateProgressDisplay(percentComplete);
                }
                else if (operationType == FileOperationType.Transfer)
                {
                    TransferOperationMessage msgDecoded = decoder.DecodeMessage<TransferOperationMessage>(message);
                    Console.WriteLine("Received file");// + msgDecoded.ToString(true));
                    percentComplete = (int)((float)msgDecoded.NumFilesCompleted / msgDecoded.NumTotalFiles * 100);
                    UpdateProgressDisplay(percentComplete);
                }
            }
        }

        private void UpdateProgressDisplay(int percentComplete)
        {
            operationProgressBar.Value = percentComplete;
            progressLabel.Text = percentComplete + "% completed";
        }
    }
}
