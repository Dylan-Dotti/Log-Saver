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
            this.timeRangeSelectionControl1 = new LogSaverClient.TimeRangeSelectionControl();
            this.sendRequestButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sendCopyCheck = new System.Windows.Forms.CheckBox();
            this.serverZipCheck = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.zipNameInput = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.localFolderButton = new System.Windows.Forms.Button();
            this.localFolderLabel = new System.Windows.Forms.Label();
            this.localFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.timeRangeSelectionControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sendRequestButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(451, 370);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // timeRangeSelectionControl1
            // 
            this.timeRangeSelectionControl1.AutoSize = true;
            this.timeRangeSelectionControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.timeRangeSelectionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeRangeSelectionControl1.Location = new System.Drawing.Point(10, 10);
            this.timeRangeSelectionControl1.Margin = new System.Windows.Forms.Padding(10);
            this.timeRangeSelectionControl1.Name = "timeRangeSelectionControl1";
            this.timeRangeSelectionControl1.Size = new System.Drawing.Size(431, 167);
            this.timeRangeSelectionControl1.TabIndex = 2;
            // 
            // sendRequestButton
            // 
            this.sendRequestButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sendRequestButton.Enabled = false;
            this.sendRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.sendRequestButton.Location = new System.Drawing.Point(125, 323);
            this.sendRequestButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.sendRequestButton.Name = "sendRequestButton";
            this.sendRequestButton.Size = new System.Drawing.Size(200, 32);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 193);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(431, 28);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // sendCopyCheck
            // 
            this.sendCopyCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendCopyCheck.AutoSize = true;
            this.sendCopyCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendCopyCheck.Location = new System.Drawing.Point(256, 3);
            this.sendCopyCheck.Name = "sendCopyCheck";
            this.sendCopyCheck.Size = new System.Drawing.Size(134, 22);
            this.sendCopyCheck.TabIndex = 1;
            this.sendCopyCheck.Text = "Send me a copy";
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
            this.serverZipCheck.Location = new System.Drawing.Point(39, 3);
            this.serverZipCheck.Name = "serverZipCheck";
            this.serverZipCheck.Size = new System.Drawing.Size(137, 22);
            this.serverZipCheck.TabIndex = 0;
            this.serverZipCheck.Text = "Zip on the server";
            this.serverZipCheck.UseVisualStyleBackColor = true;
            this.serverZipCheck.CheckedChanged += new System.EventHandler(this.serverZipCheck_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.zipNameInput, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 229);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(447, 30);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Archive folder name:";
            // 
            // zipNameInput
            // 
            this.zipNameInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zipNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipNameInput.Location = new System.Drawing.Point(225, 2);
            this.zipNameInput.Margin = new System.Windows.Forms.Padding(2);
            this.zipNameInput.Name = "zipNameInput";
            this.zipNameInput.Size = new System.Drawing.Size(161, 26);
            this.zipNameInput.TabIndex = 10;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tableLayoutPanel4.Controls.Add(this.localFolderButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.localFolderLabel, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 264);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(445, 40);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // localFolderButton
            // 
            this.localFolderButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.localFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localFolderButton.Location = new System.Drawing.Point(50, 5);
            this.localFolderButton.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.localFolderButton.Name = "localFolderButton";
            this.localFolderButton.Size = new System.Drawing.Size(169, 29);
            this.localFolderButton.TabIndex = 8;
            this.localFolderButton.Text = "Select local folder";
            this.localFolderButton.UseVisualStyleBackColor = true;
            this.localFolderButton.Click += new System.EventHandler(this.localFolderButton_Click);
            // 
            // localFolderLabel
            // 
            this.localFolderLabel.AutoEllipsis = true;
            this.localFolderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localFolderLabel.Location = new System.Drawing.Point(229, 3);
            this.localFolderLabel.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.localFolderLabel.Name = "localFolderLabel";
            this.localFolderLabel.Size = new System.Drawing.Size(209, 34);
            this.localFolderLabel.TabIndex = 9;
            this.localFolderLabel.Text = "No folder selected";
            this.localFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConnectedClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 370);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HelpButton = true;
            this.Name = "ConnectedClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectedClientForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button sendRequestButton;
        private TimeRangeSelectionControl timeRangeSelectionControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox sendCopyCheck;
        private System.Windows.Forms.CheckBox serverZipCheck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button localFolderButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label localFolderLabel;
        private System.Windows.Forms.FolderBrowserDialog localFolderBrowser;
        private System.Windows.Forms.TextBox zipNameInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}