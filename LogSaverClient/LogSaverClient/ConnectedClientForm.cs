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
    public partial class ConnectedClientForm : Form
    {
        private readonly LSClient client;

        public ConnectedClientForm(LSClient client)
        {
            InitializeComponent();
            this.client = client;
        }

        private async void sendRequestButton_Click(object sender, EventArgs e)
        {
            sendRequestButton.Enabled = false;
            client.SendMessage(new SaveRequestMessage());
            await client.AwaitMessageAsync();
            sendRequestButton.Enabled = true;
        }
    }
}
