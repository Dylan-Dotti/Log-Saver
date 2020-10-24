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
                try
                {
                    LSClient client = new LSClient();
                    resultLabel.Text = "Connecting...";
                    await client.ConnectAsync(ip, 1337);
                    //resultLabel.Text = "Connection successful";
                    ConnectionMade?.Invoke(client);

                }
                catch (Exception exception)
                {
                    resultLabel.Text = "Connection failed";
                    Console.WriteLine(exception.Message);
                    Console.WriteLine(exception.StackTrace);
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
