using Messages;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
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
            client.SendMessage(new SaveRequestMessage());
            string response = await client.AwaitMessageAsync();
            ResponseMessage resDecoded = decoder.DecodeMessage<ResponseMessage>(response);
            if (resDecoded.ResCode == ResponseCode.Ok)
            {
                await HandleZipUpdates();
            }
            else if (resDecoded.ResCode == ResponseCode.Error)
            {
                Console.WriteLine("Error");
            }
            sendRequestButton.Enabled = true;
        }

        private async Task HandleZipUpdates()
        {
            Console.WriteLine("Switching to receiving mode");
            while (true)
            {
                string message = await client.AwaitMessageAsync();
                ZipStatusMessage msgDecoded = decoder.DecodeMessage<ZipStatusMessage>(message);
                int percentComplete = (int)((float)msgDecoded.ZippedCount / msgDecoded.TotalFileCount * 100);
                progressBar1.Value = percentComplete;
                if (percentComplete == 100) break;
            }
        }
    }
}
