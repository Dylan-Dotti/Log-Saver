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
            this.serverZipCheck = new System.Windows.Forms.CheckBox();
            this.sendCopyCheck = new System.Windows.Forms.CheckBox();
            this.timeRangeSelectionControl1 = new LogSaverClient.TimeRangeSelectionControl();
            this.zipNameInput = new LogSaverClient.ZipNameInputControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.timeRangeSelectionControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sendRequestButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.zipNameInput, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 364);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // sendRequestButton
            // 
            this.sendRequestButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sendRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.sendRequestButton.Location = new System.Drawing.Point(154, 314);
            this.sendRequestButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.sendRequestButton.Name = "sendRequestButton";
            this.sendRequestButton.Size = new System.Drawing.Size(200, 35);
            this.sendRequestButton.TabIndex = 1;
            this.sendRequestButton.Text = "Save Logs";
            this.sendRequestButton.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 197);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(489, 28);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // serverZipCheck
            // 
            this.serverZipCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverZipCheck.AutoSize = true;
            this.serverZipCheck.Checked = true;
            this.serverZipCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.serverZipCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverZipCheck.Location = new System.Drawing.Point(37, 3);
            this.serverZipCheck.Name = "serverZipCheck";
            this.serverZipCheck.Size = new System.Drawing.Size(169, 22);
            this.serverZipCheck.TabIndex = 0;
            this.serverZipCheck.Text = "Zip logs on the server";
            this.serverZipCheck.UseVisualStyleBackColor = true;
            this.serverZipCheck.CheckedChanged += new System.EventHandler(this.serverZipCheck_CheckedChanged);
            // 
            // sendCopyCheck
            // 
            this.sendCopyCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendCopyCheck.AutoSize = true;
            this.sendCopyCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendCopyCheck.Location = new System.Drawing.Point(295, 3);
            this.sendCopyCheck.Name = "sendCopyCheck";
            this.sendCopyCheck.Size = new System.Drawing.Size(142, 22);
            this.sendCopyCheck.TabIndex = 1;
            this.sendCopyCheck.Text = "Send me the logs";
            this.sendCopyCheck.UseVisualStyleBackColor = true;
            this.sendCopyCheck.CheckedChanged += new System.EventHandler(this.sendCopyCheck_CheckedChanged);
            // 
            // timeRangeSelectionControl1
            // 
            this.timeRangeSelectionControl1.AutoSize = true;
            this.timeRangeSelectionControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.timeRangeSelectionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeRangeSelectionControl1.Location = new System.Drawing.Point(10, 10);
            this.timeRangeSelectionControl1.Margin = new System.Windows.Forms.Padding(10);
            this.timeRangeSelectionControl1.Name = "timeRangeSelectionControl1";
            this.timeRangeSelectionControl1.Size = new System.Drawing.Size(489, 167);
            this.timeRangeSelectionControl1.TabIndex = 2;
            // 
            // zipNameInput
            // 
            this.zipNameInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.zipNameInput.AutoSize = true;
            this.zipNameInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zipNameInput.Location = new System.Drawing.Point(95, 245);
            this.zipNameInput.Margin = new System.Windows.Forms.Padding(10);
            this.zipNameInput.Name = "zipNameInput";
            this.zipNameInput.Size = new System.Drawing.Size(318, 37);
            this.zipNameInput.TabIndex = 0;
            // 
            // ConnectedClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(509, 364);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HelpButton = true;
            this.Name = "ConnectedClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectedClientForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ZipNameInputControl zipNameInput;
        private System.Windows.Forms.Button sendRequestButton;
        private TimeRangeSelectionControl timeRangeSelectionControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox sendCopyCheck;
        private System.Windows.Forms.CheckBox serverZipCheck;
    }
}