using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace LogSaverClient.GUI
{
    public partial class ConnectionEditForm : Form
    {
        private bool isConnectionTested;
        private ConnectionInfo editingInfo;

        // opens in add mode
        public ConnectionEditForm() : this(null)
        { }

        // opens in edit mode
        public ConnectionEditForm(ConnectionInfo info)
        {
            InitializeComponent();
            if (info != null)
            {
                editingInfo = info;
                nameInput.Text = info.ConnectionName;
                ipInput.Text = info.ConnectionIP;
                isConnectionTested = true;
                okTestButton.Text = "OK";
            }
        }

        private async void okTestButton_Click(object sender, EventArgs e)
        {
            if (isConnectionTested)
            {
                // add connection to file and close
                if (editingInfo != null)
                {
                    if (nameInput.Text != editingInfo.ConnectionName &&
                        ConnectionsDAL.ConnectionExists(nameInput.Text))
                    {
                        MessageBox.Show(
                            $"A connection with the name \"{nameInput.Text}\" " +
                            "already exists." + Environment.NewLine +
                            "Please select another name.",
                            "Connection rejected",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        ConnectionsDAL.EditConnection(
                            editingInfo, nameInput.Text, ipInput.Text);
                    }
                }
                else
                {
                    ConnectionsDAL.TryAddConnection(new ConnectionInfo(nameInput.Text, ipInput.Text));
                }
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

        private void okTestButton_SizeChanged(object sender, EventArgs e)
        {
            //Owner.WindowState = WindowState;
        }
    }
}
