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
            this.sendRequestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendRequestButton
            // 
            this.sendRequestButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendRequestButton.Location = new System.Drawing.Point(125, 88);
            this.sendRequestButton.Name = "sendRequestButton";
            this.sendRequestButton.Size = new System.Drawing.Size(200, 50);
            this.sendRequestButton.TabIndex = 0;
            this.sendRequestButton.Text = "Save Logs";
            this.sendRequestButton.UseVisualStyleBackColor = true;
            this.sendRequestButton.Click += new System.EventHandler(this.sendRequestButton_Click);
            // 
            // ConnectedClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 229);
            this.Controls.Add(this.sendRequestButton);
            this.Name = "ConnectedClientForm";
            this.Text = "ConnectedClientForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sendRequestButton;
    }
}