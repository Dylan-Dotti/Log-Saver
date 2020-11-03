namespace LogSaverClient
{
    partial class MainForm
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
            this.connectionMenu1 = new LogSaverClient.ConnectionMenu();
            this.SuspendLayout();
            // 
            // connectionMenu1
            // 
            this.connectionMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionMenu1.Location = new System.Drawing.Point(0, 0);
            this.connectionMenu1.Name = "connectionMenu1";
            this.connectionMenu1.Size = new System.Drawing.Size(465, 233);
            this.connectionMenu1.TabIndex = 0;
            this.connectionMenu1.ConnectionMade += new System.Action<LogSaverClient.LSClient>(this.OnConnectionMade);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(465, 233);
            this.Controls.Add(this.connectionMenu1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Swiss Log Saver";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ConnectionMenu connectionMenu1;
    }
}