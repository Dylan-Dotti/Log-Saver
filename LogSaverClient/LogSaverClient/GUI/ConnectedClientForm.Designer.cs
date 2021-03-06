﻿namespace LogSaverClient
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
            this.timeRangeSelector = new LogSaverClient.TimeRangeSelectionControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.localFolderButton = new System.Windows.Forms.Button();
            this.localFolderLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.zipNameInput = new LogSaverClient.FileNameInputControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sendCopyCheck = new System.Windows.Forms.CheckBox();
            this.serverZipCheck = new System.Windows.Forms.CheckBox();
            this.localZipCheck = new System.Windows.Forms.CheckBox();
            this.categorySelector = new LogSaverClient.GUI.CategorySelectionDisplay();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.existingArchivesButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.sendRequestButton = new System.Windows.Forms.Button();
            this.localFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.timeRangeSelector, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.categorySelector, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(703, 415);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // timeRangeSelector
            // 
            this.timeRangeSelector.AutoSize = true;
            this.timeRangeSelector.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.timeRangeSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeRangeSelector.Location = new System.Drawing.Point(291, 10);
            this.timeRangeSelector.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.timeRangeSelector.Name = "timeRangeSelector";
            this.timeRangeSelector.Size = new System.Drawing.Size(402, 167);
            this.timeRangeSelector.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(291, 187);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 160);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archiving Options";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(396, 137);
            this.tableLayoutPanel5.TabIndex = 0;
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(5, 92);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(386, 40);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // localFolderButton
            // 
            this.localFolderButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.localFolderButton.Enabled = false;
            this.localFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localFolderButton.Location = new System.Drawing.Point(45, 5);
            this.localFolderButton.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.localFolderButton.Name = "localFolderButton";
            this.localFolderButton.Size = new System.Drawing.Size(144, 29);
            this.localFolderButton.TabIndex = 8;
            this.localFolderButton.Text = "Select local folder";
            this.localFolderButton.UseVisualStyleBackColor = true;
            this.localFolderButton.Click += new System.EventHandler(this.localFolderButton_Click);
            // 
            // localFolderLabel
            // 
            this.localFolderLabel.AutoEllipsis = true;
            this.localFolderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localFolderLabel.Enabled = false;
            this.localFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localFolderLabel.Location = new System.Drawing.Point(199, 3);
            this.localFolderLabel.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.localFolderLabel.Name = "localFolderLabel";
            this.localFolderLabel.Size = new System.Drawing.Size(180, 34);
            this.localFolderLabel.TabIndex = 9;
            this.localFolderLabel.Text = "No folder selected";
            this.localFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.zipNameInput, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 43);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(386, 39);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Archive folder name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // zipNameInput
            // 
            this.zipNameInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zipNameInput.Location = new System.Drawing.Point(196, 3);
            this.zipNameInput.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.zipNameInput.Name = "zipNameInput";
            this.zipNameInput.Size = new System.Drawing.Size(155, 33);
            this.zipNameInput.TabIndex = 8;
            this.zipNameInput.InputTextChanged += new System.Action<string>(this.OnZipNameChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.sendCopyCheck, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.serverZipCheck, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.localZipCheck, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(386, 28);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // sendCopyCheck
            // 
            this.sendCopyCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendCopyCheck.AutoSize = true;
            this.sendCopyCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendCopyCheck.Location = new System.Drawing.Point(122, 3);
            this.sendCopyCheck.Name = "sendCopyCheck";
            this.sendCopyCheck.Size = new System.Drawing.Size(134, 22);
            this.sendCopyCheck.TabIndex = 3;
            this.sendCopyCheck.Text = "Transfer to local";
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
            this.serverZipCheck.Location = new System.Drawing.Point(3, 3);
            this.serverZipCheck.Name = "serverZipCheck";
            this.serverZipCheck.Size = new System.Drawing.Size(113, 22);
            this.serverZipCheck.TabIndex = 0;
            this.serverZipCheck.Text = "Zip on server";
            this.serverZipCheck.UseVisualStyleBackColor = true;
            this.serverZipCheck.CheckedChanged += new System.EventHandler(this.serverZipCheck_CheckedChanged);
            // 
            // localZipCheck
            // 
            this.localZipCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.localZipCheck.AutoSize = true;
            this.localZipCheck.Enabled = false;
            this.localZipCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localZipCheck.Location = new System.Drawing.Point(271, 3);
            this.localZipCheck.Name = "localZipCheck";
            this.localZipCheck.Size = new System.Drawing.Size(103, 22);
            this.localZipCheck.TabIndex = 2;
            this.localZipCheck.Text = "Zip on local";
            this.localZipCheck.UseVisualStyleBackColor = true;
            // 
            // categorySelector
            // 
            this.categorySelector.Categories = null;
            this.categorySelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categorySelector.Location = new System.Drawing.Point(7, 7);
            this.categorySelector.Margin = new System.Windows.Forms.Padding(7);
            this.categorySelector.Name = "categorySelector";
            this.tableLayoutPanel1.SetRowSpan(this.categorySelector, 2);
            this.categorySelector.Size = new System.Drawing.Size(267, 343);
            this.categorySelector.TabIndex = 9;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel6, 2);
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.existingArchivesButton, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.closeButton, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.sendRequestButton, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 357);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(703, 58);
            this.tableLayoutPanel6.TabIndex = 10;
            // 
            // existingArchivesButton
            // 
            this.existingArchivesButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.existingArchivesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.existingArchivesButton.Location = new System.Drawing.Point(15, 13);
            this.existingArchivesButton.Margin = new System.Windows.Forms.Padding(15, 7, 7, 7);
            this.existingArchivesButton.Name = "existingArchivesButton";
            this.existingArchivesButton.Size = new System.Drawing.Size(175, 32);
            this.existingArchivesButton.TabIndex = 11;
            this.existingArchivesButton.Text = "Existing Archives";
            this.existingArchivesButton.UseVisualStyleBackColor = true;
            this.existingArchivesButton.Click += new System.EventHandler(this.existingArchivesButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.closeButton.Location = new System.Drawing.Point(518, 13);
            this.closeButton.Margin = new System.Windows.Forms.Padding(7, 7, 15, 7);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(170, 32);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Disconnect";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // sendRequestButton
            // 
            this.sendRequestButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sendRequestButton.Enabled = false;
            this.sendRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.sendRequestButton.Location = new System.Drawing.Point(334, 13);
            this.sendRequestButton.Margin = new System.Windows.Forms.Padding(7);
            this.sendRequestButton.Name = "sendRequestButton";
            this.sendRequestButton.Size = new System.Drawing.Size(170, 32);
            this.sendRequestButton.TabIndex = 9;
            this.sendRequestButton.Text = "Send Request";
            this.sendRequestButton.UseVisualStyleBackColor = true;
            this.sendRequestButton.Click += new System.EventHandler(this.sendRequestButton_Click);
            // 
            // ConnectedClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 415);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Name = "ConnectedClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectedClientForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FolderBrowserDialog localFolderBrowser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button localFolderButton;
        private System.Windows.Forms.Label localFolderLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox serverZipCheck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private FileNameInputControl zipNameInput;
        private TimeRangeSelectionControl timeRangeSelector;
        private GUI.CategorySelectionDisplay categorySelector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button sendRequestButton;
        private System.Windows.Forms.CheckBox sendCopyCheck;
        private System.Windows.Forms.CheckBox localZipCheck;
        private System.Windows.Forms.Button existingArchivesButton;
    }
}