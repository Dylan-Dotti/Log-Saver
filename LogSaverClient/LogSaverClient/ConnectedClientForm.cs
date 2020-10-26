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

        private async void sendRequestButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sending request");
            sendRequestButton.Enabled = false;
            string zipName = zipNameInput.InputText.Trim();
            // append .zip if the string does not end with it
            if (!zipName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
            {
                zipName += ".zip";
            }
            // create and send request
            var request = new SaveRequestMessage(zipName);
            client.SendMessage(request);
            // wait for response and decode message
            string response = await client.AwaitMessageAsync();
            ResponseMessage resDecoded = decoder.DecodeMessage<ResponseMessage>(response);
            // process message
            if (resDecoded.ResCode == ResponseCode.Ok)
            {
                new FileOperationProgressForm(client, decoder).ShowDialog();
            }
            else if (resDecoded.ResCode == ResponseCode.Error)
            {
                MessageBox.Show("Request sent to server was in error \n" +
                    "Request: " + request.ToString(true), 
                    "Request Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sendRequestButton.Enabled = true;
        }

        private void OnZipNameChanged(string newInput)
        {
            sendRequestButton.Enabled = newInput.Length > 0;
        }
    }
}
