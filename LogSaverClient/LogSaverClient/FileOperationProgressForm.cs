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
        private readonly MessageDecoder decoder;

        public FileOperationProgressForm(LSClient client, MessageDecoder decoder)
        {
            InitializeComponent();
            this.client = client;
            this.decoder = decoder;
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await HandleOperationUpdates();
            Close();
        }

        private async Task HandleOperationUpdates()
        {
            int percentComplete = 0;
            while (percentComplete < 100)
            {
                string message = await client.AwaitMessageAsync();
                ZipOperationMessage msgDecoded = decoder.DecodeMessage<ZipOperationMessage>(message);
                percentComplete = (int)((float)msgDecoded.NumFilesCompleted / msgDecoded.NumTotalFiles * 100);
                progressBar1.Value = percentComplete;
            }
        }
    }
}
