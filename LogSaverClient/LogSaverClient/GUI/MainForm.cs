using System;
using System.Windows.Forms;

namespace LogSaverClient
{
    public partial class MainForm : Form
    {
        private ConnectionInfo selectedConnection;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnConnectionSelected(ConnectionInfo connection)
        {
            selectedConnection = connection;
            connectButton.Enabled = selectedConnection != null;
        }

        private void OnConnectionMade(LSClient client)
        {
            new ConnectedClientForm(client).ShowDialog(this);
            client.Close();
        }
    }
}
