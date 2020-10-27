using Messages;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LogSaverClient
{
    public partial class ConnectedClientForm : Form
    {
        private readonly LSClient client;
        private readonly MessageDecoder decoder;

        public ConnectedClientForm(LSClient client)
        {
            InitializeComponent();
            this.client = client;
            decoder = new MessageDecoder();
            zipNameInput.InputTextChanged += OnZipNameChanged;
        }

        private void OnZipNameChanged(string newInput)
        {
            sendRequestButton.Enabled = newInput.Length > 0;
        }

        private async void sendRequestButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sending request...");
            sendRequestButton.Enabled = false;
            string zipName = zipNameInput.InputText.Trim();
            // append .zip if the string does not end with it
            if (!zipName.ToLower().EndsWith(".zip")) zipName += ".zip";
            // create and send request
            var request = new SaveRequestMessage(zipName);
            client.SendMessage(request);
            Console.WriteLine("Message sent. Awaiting response...");
            // wait for response and decode message
            string response = await client.AwaitMessageAsync();
            ResponseMessage resDecoded = decoder.DecodeMessage<ResponseMessage>(response);
            // process message
            if (resDecoded.ResCode == ResponseCode.Ok)
            {
                new FileOperationProgressForm(client, FileOperationType.Zip).ShowDialog();
            }
            else if (resDecoded.ResCode == ResponseCode.Error)
            {
                MessageBox.Show("Your request was rejected by the server.\n" +
                    "Reason: " + resDecoded.ErrorMessage,
                    "Request Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sendRequestButton.Enabled = true;
        }

        private void serverZipCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!serverZipCheck.Checked && !sendCopyCheck.Checked)
            {
                sendCopyCheck.Checked = true;
            }
        }

        private void sendCopyCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!serverZipCheck.Checked && !sendCopyCheck.Checked)
            {
                serverZipCheck.Checked = true;
            }
        }
    }
}
