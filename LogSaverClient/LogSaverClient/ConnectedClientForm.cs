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
        }

        private void OnZipNameChanged(string newInput)
        {
            UpdateButtonEnabled();
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
                await requestManager.SendAndManageTransferRequest(localFolderBrowser.SelectedPath);
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
            localFolderButton.Enabled = sendCopyCheck.Checked;
            localFolderLabel.Enabled = sendCopyCheck.Checked;
            if (!serverZipCheck.Checked && !sendCopyCheck.Checked)
            {
                serverZipCheck.Checked = true;
            }
            UpdateButtonEnabled();
        }

        private void localFolderButton_Click(object sender, EventArgs e)
        {
            localFolderBrowser.ShowDialog();
            localFolderLabel.Text = localFolderBrowser.SelectedPath == "" ?
                "No folder selected" : localFolderBrowser.SelectedPath;
            UpdateButtonEnabled();
        }

        private void UpdateButtonEnabled()
        {
            sendRequestButton.Enabled = zipNameInput.InputText.Length > 0 &&
                (!sendCopyCheck.Checked || localFolderBrowser.SelectedPath != "");
        }
    }
}
