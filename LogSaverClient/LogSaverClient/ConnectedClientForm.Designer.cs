namespace LogSaverClient
{
    partial class ConnectedClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sendRequestButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sendCopyCheck = new System.Windows.Forms.CheckBox();
            this.serverZipCheck = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.timeRangeSelectionControl1 = new LogSaverClient.TimeRangeSelectionControl();
            this.zipNameInput = new LogSaverClient.FileNameInputControl();
            this.fileNameInputControl1 = new LogSaverClient.FileNameInputControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.timeRangeSelectionControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sendRequestButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(817, 567);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // sendRequestButton
            // 
            this.sendRequestButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sendRequestButton.Enabled = false;
            this.sendRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.sendRequestButton.Location = new System.Drawing.Point(258, 494);
            this.sendRequestButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 23);
            this.sendRequestButton.Name = "sendRequestButton";
            this.sendRequestButton.Size = new System.Drawing.Size(300, 50);
            this.sendRequestButton.TabIndex = 1;
            this.sendRequestButton.Text = "Send Request";
            this.sendRequestButton.UseVisualStyleBackColor = true;
            this.sendRequestButton.Click += new System.EventHandler(this.sendRequestButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.sendCopyCheck, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.serverZipCheck, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(15, 288);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(787, 43);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // sendCopyCheck
            // 
            this.sendCopyCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendCopyCheck.AutoSize = true;
            this.sendCopyCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendCopyCheck.Location = new System.Drawing.Point(425, 5);
            this.sendCopyCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendCopyCheck.Name = "sendCopyCheck";
            this.sendCopyCheck.Size = new System.Drawing.Size(329, 33);
            this.sendCopyCheck.TabIndex = 1;
            this.sendCopyCheck.Text = "Send me a copy of the logs";
            this.sendCopyCheck.UseVisualStyleBackColor = true;
            this.sendCopyCheck.CheckedChanged += new System.EventHandler(this.sendCopyCheck_CheckedChanged);
            // 
            // serverZipCheck
            // 
            this.serverZipCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverZipCheck.AutoSize = true;
            this.serverZipCheck.Checked = true;
            this.serverZipCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.serverZipCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverZipCheck.Location = new System.Drawing.Point(42, 5);
            this.serverZipCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serverZipCheck.Name = "serverZipCheck";
            this.serverZipCheck.Size = new System.Drawing.Size(309, 33);
            this.serverZipCheck.TabIndex = 0;
            this.serverZipCheck.Text = "Zip the logs on the server";
            this.serverZipCheck.UseVisualStyleBackColor = true;
            this.serverZipCheck.CheckedChanged += new System.EventHandler(this.serverZipCheck_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.fileNameInputControl1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.zipNameInput, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 349);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(811, 118);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // timeRangeSelectionControl1
            // 
            this.timeRangeSelectionControl1.AutoSize = true;
            this.timeRangeSelectionControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.timeRangeSelectionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeRangeSelectionControl1.Location = new System.Drawing.Point(15, 15);
            this.timeRangeSelectionControl1.Margin = new System.Windows.Forms.Padding(15);
            this.timeRangeSelectionControl1.Name = "timeRangeSelectionControl1";
            this.timeRangeSelectionControl1.Size = new System.Drawing.Size(787, 243);
            this.timeRangeSelectionControl1.TabIndex = 2;
            // 
            // zipNameInput
            // 
            this.zipNameInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.zipNameInput.AutoSize = true;
            this.zipNameInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zipNameInput.Location = new System.Drawing.Point(147, 5);
            this.zipNameInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zipNameInput.Name = "zipNameInput";
            this.zipNameInput.PromptText = "Server folder name:";
            this.zipNameInput.Size = new System.Drawing.Size(516, 49);
            this.zipNameInput.TabIndex = 5;
            // 
            // fileNameInputControl1
            // 
            this.fileNameInputControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fileNameInputControl1.AutoSize = true;
            this.fileNameInputControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fileNameInputControl1.Location = new System.Drawing.Point(154, 64);
            this.fileNameInputControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileNameInputControl1.Name = "fileNameInputControl1";
            this.fileNameInputControl1.PromptText = "Local folder name:";
            this.fileNameInputControl1.Size = new System.Drawing.Size(502, 49);
            this.fileNameInputControl1.TabIndex = 6;
            // 
            // ConnectedClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(817, 567);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConnectedClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectedClientForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button sendRequestButton;
        private TimeRangeSelectionControl timeRangeSelectionControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox sendCopyCheck;
        private System.Windows.Forms.CheckBox serverZipCheck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private FileNameInputControl zipNameInput;
        private FileNameInputControl fileNameInputControl1;
    }
}