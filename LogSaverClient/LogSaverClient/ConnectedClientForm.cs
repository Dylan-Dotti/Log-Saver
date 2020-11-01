using Messages;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LogSaverClient
{
    public partial class ConnectedClientForm : Form
    {
        private readonly LSClient client;
        private readonly FileOperationRequestManager requestManager;

        public ConnectedClientForm(LSClient client)
        {
            InitializeComponent();
            this.client = client;
            requestManager = new FileOperationRequestManager(client);
            //zipNameInput.InputTextChanged += OnZipNameChanged;
        }

        private void OnZipNameChanged(string newInput)
        {
            sendRequestButton.Enabled = newInput.Length > 0;
        }

        private async void sendRequestButton_Click(object sender, EventArgs e)
        {
            sendRequestButton.Enabled = false;
            if (serverZipCheck.Checked)
            {
                await requestManager.SendAndManageZipRequest(zipNameInput.Text);
            }
            if (sendCopyCheck.Checked)
            {
                await requestManager.SendAndManageTransferRequest();
            }
            sendRequestButton.Enabled = true;
        }

        private void serverZipCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!serverZipCheck.Checked && !sendCopyCheck.Checked)
            {
                sendCopyCheck.Checked = true;
            }
        }

        private void sendCopyCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!serverZipCheck.Checked && !sendCopyCheck.Checked)
            {
                serverZipCheck.Checked = true;
            }
        }

        private void localFolderButton_Click(object sender, EventArgs e)
        {
            localFolderBrowser.ShowDialog();
            localFolderLabel.Text = localFolderBrowser.SelectedPath == "" ?
                "No folder selected" : localFolderBrowser.SelectedPath;
        }
    }
}
