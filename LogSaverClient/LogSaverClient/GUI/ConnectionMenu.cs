using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace LogSaverClient
{
    public partial class ConnectionMenu : UserControl
    {
        public event Action<LSClient> ConnectionMade;

        public ConnectionMenu()
        {
            InitializeComponent();
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            connectButton.Enabled = false;
            string input = ipInput.Text;
            if (input.IsIPv4Format() && IPAddress.TryParse(input, out IPAddress ip))
            {
                LSClient client = new LSClient();
                resultLabel.Text = "Connecting...";
                if (await client.TryConnectAsync(ip, 1337))
                {
                    ConnectionMade?.Invoke(client);
                    resultLabel.Text = "";
                }
                else
                {
                    resultLabel.Text = "Connection failed";
                }
            }
            else
            {
                resultLabel.Text = "Invalid IP entered";
            }
            connectButton.Enabled = true;
        }
    }
}
