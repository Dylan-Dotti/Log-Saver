﻿using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogSaverClient
{
    public partial class FileOperationProgressForm : Form
    {
        private readonly FileOperationUpdateReceiver receiver;

        public FileOperationProgressForm(FileOperationUpdateReceiver receiver)
        {
            InitializeComponent();
            this.receiver = receiver;
            receiver.ProgressUpdated += UpdateProgressDisplay;
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            operationLabel.Text =
                (receiver.OperationType == FileOperationType.Zip ? 
                "Zip" : "Transfer") + " operation in progress...";
            //invalid operationexception if window closed
            await receiver.HandleOperationUpdates();
            Close();
        }

        private void UpdateProgressDisplay(int numFilesCompleted, int numTotalFiles)
        {
            int percentComplete = (int)((float)numFilesCompleted / numTotalFiles * 100);
            // use Invoke to allow modification from other threads
            Invoke(new Action(() =>
            {
                operationProgressBar.Value = percentComplete;
                progressLabel.Text = percentComplete + "% completed";
            }));
        }
    }
}
