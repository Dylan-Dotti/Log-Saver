using Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            progressLabel.Text = "0% completed";
            while (percentComplete < 100)
            {
                string message = await client.AwaitMessageAsync();
                ZipOperationMessage msgDecoded = decoder.DecodeMessage<ZipOperationMessage>(message);
                percentComplete = (int)((float)msgDecoded.NumFilesCompleted / msgDecoded.NumTotalFiles * 100);
                operationProgressBar.Value = percentComplete;
                progressLabel.Text = percentComplete + "% completed";
            }
        }
    }
}
