using Messages;
using System;
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
        }

        private async void sendRequestButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sending request");
            sendRequestButton.Enabled = false;
            var request = new SaveRequestMessage(zipNameInput.Text);
            client.SendMessage(request);
            string response = await client.AwaitMessageAsync();
            ResponseMessage resDecoded = decoder.DecodeMessage<ResponseMessage>(response);
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

        private void zipNameInput_TextChanged(object sender, EventArgs e)
        {
            string input = zipNameInput.Text;
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                zipNameInput.Clear();
                sendRequestButton.Enabled = false;
            }
            else
            {
                sendRequestButton.Enabled = true;
            }
        }
    }
}
