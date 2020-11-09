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

        public ConnectedClientForm(LSClient client, ServerInfoMessage serverInfo)
        {
            InitializeComponent();
            this.client = client;
            categorySelector.Categories = serverInfo.fileCategories;
            requestManager = new FileOperationRequestManager(client);
        }

        private void OnZipNameChanged(string newInput)
        {
            UpdateSendButtonEnabled();
        }

        private async void sendRequestButton_Click(object sender, EventArgs e)
        {
            sendRequestButton.Enabled = false;
            var timeRangeUtc = timeRangeSelector.GetTimeRange().ToUtc();
            if (serverZipCheck.Checked)
            {
                await requestManager.SendAndManageZipRequest(
                    zipNameInput.Text, timeRangeUtc, categorySelector.FullCategories);
            }
            if (sendCopyCheck.Checked)
            {
                await requestManager.SendAndManageTransferRequest(
                    localFolderBrowser.SelectedPath, timeRangeUtc, categorySelector.FullCategories);
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
            UpdateSendButtonEnabled();
        }

        private void localFolderButton_Click(object sender, EventArgs e)
        {
            localFolderBrowser.ShowDialog();
            localFolderLabel.Text = localFolderBrowser.SelectedPath == "" ?
                "No folder selected" : localFolderBrowser.SelectedPath;
            UpdateSendButtonEnabled();
        }

        private void UpdateSendButtonEnabled()
        {
            sendRequestButton.Enabled = zipNameInput.Text.Length > 0 &&
                (!sendCopyCheck.Checked || localFolderBrowser.SelectedPath != "");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            client.Close();
            Close();
        }
    }
}
