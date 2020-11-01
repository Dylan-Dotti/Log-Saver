namespace LogSaverClient
{
    partial class FileNameInputControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.fileNameInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // errorTooltip
            // 
            this.errorTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            // 
            // fileNameInput
            // 
            this.fileNameInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fileNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameInput.Location = new System.Drawing.Point(4, 2);
            this.fileNameInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileNameInput.Name = "fileNameInput";
            this.fileNameInput.Size = new System.Drawing.Size(247, 35);
            this.fileNameInput.TabIndex = 2;
            this.fileNameInput.TextChanged += new System.EventHandler(this.fileNameInput_TextChanged);
            // 
            // FileNameInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.fileNameInput);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FileNameInputControl";
            this.Size = new System.Drawing.Size(255, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip errorTooltip;
        private System.Windows.Forms.TextBox fileNameInput;
    }
}
