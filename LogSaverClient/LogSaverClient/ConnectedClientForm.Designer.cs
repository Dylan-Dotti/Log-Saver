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
            this.label1 = new System.Windows.Forms.Label();
            this.zipNameInput = new System.Windows.Forms.TextBox();
            this.timeRangeSelectionComponent1 = new LogSaverClient.TimeRangeSelectionComponent();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.sendRequestButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.timeRangeSelectionComponent1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(592, 339);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // sendRequestButton
            // 
            this.sendRequestButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sendRequestButton.AutoSize = true;
            this.sendRequestButton.Enabled = false;
            this.sendRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendRequestButton.Location = new System.Drawing.Point(196, 290);
            this.sendRequestButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.sendRequestButton.Name = "sendRequestButton";
            this.sendRequestButton.Size = new System.Drawing.Size(200, 34);
            this.sendRequestButton.TabIndex = 1;
            this.sendRequestButton.Text = "Save Logs";
            this.sendRequestButton.UseVisualStyleBackColor = true;
            this.sendRequestButton.Click += new System.EventHandler(this.sendRequestButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.zipNameInput, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 216);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(586, 37);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(149, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zip file name:";
            // 
            // zipNameInput
            // 
            this.zipNameInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zipNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipNameInput.Location = new System.Drawing.Point(296, 3);
            this.zipNameInput.Name = "zipNameInput";
            this.zipNameInput.Size = new System.Drawing.Size(165, 31);
            this.zipNameInput.TabIndex = 1;
            this.zipNameInput.TextChanged += new System.EventHandler(this.zipNameInput_TextChanged);
            // 
            // timeRangeSelectionComponent1
            // 
            this.timeRangeSelectionComponent1.AutoSize = true;
            this.timeRangeSelectionComponent1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.timeRangeSelectionComponent1.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeRangeSelectionComponent1.Location = new System.Drawing.Point(15, 15);
            this.timeRangeSelectionComponent1.Margin = new System.Windows.Forms.Padding(15);
            this.timeRangeSelectionComponent1.Name = "timeRangeSelectionComponent1";
            this.timeRangeSelectionComponent1.Size = new System.Drawing.Size(562, 183);
            this.timeRangeSelectionComponent1.TabIndex = 3;
            // 
            // ConnectedClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(592, 339);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConnectedClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectedClientForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button sendRequestButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private TimeRangeSelectionComponent timeRangeSelectionComponent1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox zipNameInput;
    }
}