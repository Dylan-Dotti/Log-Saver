namespace LogSaverClient.GUI
{
    partial class CategorySelectionDisplay
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.allCategoriesRadio = new System.Windows.Forms.RadioButton();
            this.selectedCategoriesRadio = new System.Windows.Forms.RadioButton();
            this.allCategoriesLabel = new System.Windows.Forms.Label();
            this.selectedCategoriesLabel = new System.Windows.Forms.Label();
            this.categoriesTreeView = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 403);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 397);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Category Options";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.categoriesTreeView, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(293, 374);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.allCategoriesRadio, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.selectedCategoriesRadio, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.allCategoriesLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.selectedCategoriesLabel, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(283, 60);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // allCategoriesRadio
            // 
            this.allCategoriesRadio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.allCategoriesRadio.AutoSize = true;
            this.allCategoriesRadio.Checked = true;
            this.allCategoriesRadio.Location = new System.Drawing.Point(15, 8);
            this.allCategoriesRadio.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.allCategoriesRadio.Name = "allCategoriesRadio";
            this.allCategoriesRadio.Size = new System.Drawing.Size(14, 13);
            this.allCategoriesRadio.TabIndex = 0;
            this.allCategoriesRadio.TabStop = true;
            this.allCategoriesRadio.UseVisualStyleBackColor = true;
            this.allCategoriesRadio.CheckedChanged += new System.EventHandler(this.OnRadioSelected);
            // 
            // selectedCategoriesRadio
            // 
            this.selectedCategoriesRadio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.selectedCategoriesRadio.AutoSize = true;
            this.selectedCategoriesRadio.Location = new System.Drawing.Point(15, 38);
            this.selectedCategoriesRadio.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.selectedCategoriesRadio.Name = "selectedCategoriesRadio";
            this.selectedCategoriesRadio.Size = new System.Drawing.Size(14, 13);
            this.selectedCategoriesRadio.TabIndex = 1;
            this.selectedCategoriesRadio.UseVisualStyleBackColor = true;
            this.selectedCategoriesRadio.CheckedChanged += new System.EventHandler(this.OnRadioSelected);
            // 
            // allCategoriesLabel
            // 
            this.allCategoriesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.allCategoriesLabel.AutoSize = true;
            this.allCategoriesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allCategoriesLabel.Location = new System.Drawing.Point(37, 5);
            this.allCategoriesLabel.Margin = new System.Windows.Forms.Padding(5);
            this.allCategoriesLabel.Name = "allCategoriesLabel";
            this.allCategoriesLabel.Size = new System.Drawing.Size(104, 20);
            this.allCategoriesLabel.TabIndex = 2;
            this.allCategoriesLabel.Text = "All categories";
            // 
            // selectedCategoriesLabel
            // 
            this.selectedCategoriesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectedCategoriesLabel.AutoSize = true;
            this.selectedCategoriesLabel.Enabled = false;
            this.selectedCategoriesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedCategoriesLabel.Location = new System.Drawing.Point(37, 35);
            this.selectedCategoriesLabel.Margin = new System.Windows.Forms.Padding(5);
            this.selectedCategoriesLabel.Name = "selectedCategoriesLabel";
            this.selectedCategoriesLabel.Size = new System.Drawing.Size(150, 20);
            this.selectedCategoriesLabel.TabIndex = 3;
            this.selectedCategoriesLabel.Text = "Selected categories";
            // 
            // categoriesTreeView
            // 
            this.categoriesTreeView.CheckBoxes = true;
            this.categoriesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesTreeView.Enabled = false;
            this.categoriesTreeView.FullRowSelect = true;
            this.categoriesTreeView.Location = new System.Drawing.Point(10, 80);
            this.categoriesTreeView.Margin = new System.Windows.Forms.Padding(10);
            this.categoriesTreeView.Name = "categoriesTreeView";
            this.categoriesTreeView.Size = new System.Drawing.Size(273, 284);
            this.categoriesTreeView.TabIndex = 4;
            this.categoriesTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.categoriesTreeView_AfterCheck);
            // 
            // CategorySelectionDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CategorySelectionDisplay";
            this.Size = new System.Drawing.Size(305, 403);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton allCategoriesRadio;
        private System.Windows.Forms.RadioButton selectedCategoriesRadio;
        private System.Windows.Forms.Label allCategoriesLabel;
        private System.Windows.Forms.Label selectedCategoriesLabel;
        private System.Windows.Forms.TreeView categoriesTreeView;
    }
}
