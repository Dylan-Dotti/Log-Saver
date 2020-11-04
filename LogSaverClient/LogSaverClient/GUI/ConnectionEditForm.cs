using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogSaverClient.GUI
{
    public partial class ConnectionEditForm : Form
    {
        private bool isConnectionTested;

        public ConnectionEditForm()
        {
            InitializeComponent();
        }

        private async void okTestButton_Click(object sender, EventArgs e)
        {
            if (isConnectionTested)
            {
                // add connection to file and close
                ConnectionsDAL.TryAddConnection(new ConnectionInfo(nameInput.Text, ipInput.Text));
                DialogResult = DialogResult.OK;
            }
            else
            {
                string ipString = ipInput.Text;
                // test connection
                if (ipString.IsIPv4Format() && 
                    IPAddress.TryParse(ipString, out IPAddress ip))
                {
                    okTestButton.Enabled = false;
                    cancelButton.Enabled = false;
                    connectionResultLabel.Text = "Connecting...";
                    LSClient testClient = new LSClient();
                    if (await testClient.TryConnectAsync(ip, 1337))
                    {
                        // connection successful
                        testClient.Close();
                        isConnectionTested = true;
                        okTestButton.Text = "OK";
                        connectionResultLabel.Text = "Connected!";
                    }
                    else
                    {
                        connectionResultLabel.Text = "Connection failed";
                    }
                    okTestButton.Enabled = true;
                    cancelButton.Enabled = true;
                }
                else
                {
                    // invalid IP
                    connectionResultLabel.Text = "Invalid IP";
                }
            }
        }

        private void nameInput_TextChanged(object sender, EventArgs e)
        {
            nameInput.Text = nameInput.Text.TrimStart();
            okTestButton.Enabled = nameInput.Text.Length > 0 &&
                ipInput.Text.Length > 0;
        }

        private void ipInput_TextChanged(object sender, EventArgs e)
        {
            ipInput.Text = ipInput.Text.TrimStart();
            okTestButton.Enabled = nameInput.Text.Length > 0 &&
                ipInput.Text.Length > 0;
            isConnectionTested = false;
            okTestButton.Text = "Test";
            connectionResultLabel.Text = "";
            DialogResult = DialogResult.None;
        }
    }
}
