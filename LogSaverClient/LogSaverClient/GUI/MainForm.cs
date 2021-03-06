﻿using Messages;
using Newtonsoft.Json;
using System;
using System.Net;
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
            selectedConnectionLabel.Text = connection == null ?
                "No connection selected" :
                connection.ConnectionName + Environment.NewLine + 
                connection.ConnectionIP;
            connectButton.Enabled = selectedConnection != null;
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            connectButton.Enabled = false;
            LSClient client = new LSClient();
            if (await client.TryConnectAsync(IPAddress.Parse(selectedConnection.ConnectionIP), 1337))
            {
                Console.WriteLine("Waiting for server info...");
                ServerInfoMessage serverInfo = await new RequestManager(client).RetrieveServerInfo();
                //Console.WriteLine("Received server info: " + 
                  //  JsonConvert.SerializeObject(serverInfo, Formatting.Indented));
                new ConnectedClientForm(client, serverInfo).ShowDialog(this);
                client.Close();
            }
            connectButton.Enabled = true;
        }
    }
}
