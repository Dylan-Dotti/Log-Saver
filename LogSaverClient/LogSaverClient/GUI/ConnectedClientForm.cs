using Messages;
using System;
using System.IO;
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
            UpdateLocalFolderLabel();
            UpdateSendButtonEnabled();
        }

        private async void sendRequestButton_Click(object sender, EventArgs e)
        {
            sendRequestButton.Enabled = false;
            var timeRangeUtc = timeRangeSelector.GetTimeRange().ToUtc();
            // validate target local path if send copy option selected
            bool continueOperation = true;
            string localFolderPath = sendCopyCheck.Checked ?
                Path.Combine(localFolderBrowser.SelectedPath, zipNameInput.Text) : "";
            if (Directory.Exists(localFolderPath))
            {
                var result = MessageBox.Show($"The path {localFolderPath} already exists. " +
                    "Do you wish to overwrite? Operation cannot continue otherwise",
                    "Request Error",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                continueOperation = result == DialogResult.Yes;
            }
            // send requests
            if (serverZipCheck.Checked && continueOperation)
            {
                continueOperation = await requestManager.SendAndManageZipRequest(
                    zipNameInput.Text, timeRangeUtc, categorySelector.FullCategories);
            }
            if (sendCopyCheck.Checked && continueOperation)
            {
                await requestManager.SendAndManageTransferRequest(
                    localFolderPath, 
                    timeRangeUtc, categorySelector.FullCategories);
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
            UpdateLocalFolderLabel();
            UpdateSendButtonEnabled();
        }

        private void localFolderButton_Click(object sender, EventArgs e)
        {
            localFolderBrowser.ShowDialog();
            localFolderLabel.Text = localFolderBrowser.SelectedPath == "" ?
                "No folder selected" : localFolderBrowser.SelectedPath;
            UpdateLocalFolderLabel();
            UpdateSendButtonEnabled();
        }

        private void UpdateSendButtonEnabled()
        {
            sendRequestButton.Enabled = zipNameInput.Text.Length > 0 &&
                (!sendCopyCheck.Checked || localFolderBrowser.SelectedPath != "");
        }

        private void UpdateLocalFolderLabel()
        {
            if (sendCopyCheck.Checked && localFolderBrowser.SelectedPath != "")
            {
                localFolderLabel.Text = Path.Combine(
                    localFolderBrowser.SelectedPath, zipNameInput.Text);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            client.Close();
            Close();
        }
    }
}
