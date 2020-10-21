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
            this.connectionMenu = new LogSaverClient.ConnectionMenu();
            this.SuspendLayout();
            // 
            // connectionMenu
            // 
            this.connectionMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionMenu.Location = new System.Drawing.Point(0, 0);
            this.connectionMenu.Name = "connectionMenu";
            this.connectionMenu.Size = new System.Drawing.Size(672, 354);
            this.connectionMenu.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(672, 354);
            this.Controls.Add(this.connectionMenu);
            this.Name = "MainForm";
            this.Text = "Swiss Log Saver";
            this.ResumeLayout(false);

        }

        #endregion

        private ConnectionMenu connectionMenu;
    }
}