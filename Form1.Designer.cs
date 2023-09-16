namespace charlieahill_Gallery_Tool
{
    partial class Form1
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.selectImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RemoveImageButton = new System.Windows.Forms.Button();
            this.decreaseOrderButton = new System.Windows.Forms.Button();
            this.IncreaseOrderButton = new System.Windows.Forms.Button();
            this.imagesListView = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.IndexIdentifierLabel = new System.Windows.Forms.Label();
            this.PreviewImageButton1 = new System.Windows.Forms.Button();
            this.KeyImageButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectImageToolStripMenuItem,
            this.generateOutputToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1011, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // selectImageToolStripMenuItem
            // 
            this.selectImageToolStripMenuItem.Name = "selectImageToolStripMenuItem";
            this.selectImageToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.selectImageToolStripMenuItem.Text = "Add Images";
            this.selectImageToolStripMenuItem.Click += new System.EventHandler(this.selectImageToolStripMenuItem_Click);
            // 
            // generateOutputToolStripMenuItem
            // 
            this.generateOutputToolStripMenuItem.Name = "generateOutputToolStripMenuItem";
            this.generateOutputToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.generateOutputToolStripMenuItem.Text = "Generate output";
            this.generateOutputToolStripMenuItem.Click += new System.EventHandler(this.generateOutputToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "jpg files|*.jpg;*.jpeg|png files|*.png|bmp files|*.bmp|all files|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select Image";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 579);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1011, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtCaption
            // 
            this.txtCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaption.Location = new System.Drawing.Point(134, 581);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(784, 20);
            this.txtCaption.TabIndex = 3;
            this.txtCaption.TextChanged += new System.EventHandler(this.txtCaption_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.PreviewImageButton1);
            this.splitContainer1.Panel1.Controls.Add(this.KeyImageButton);
            this.splitContainer1.Panel1.Controls.Add(this.RemoveImageButton);
            this.splitContainer1.Panel1.Controls.Add(this.decreaseOrderButton);
            this.splitContainer1.Panel1.Controls.Add(this.IncreaseOrderButton);
            this.splitContainer1.Panel1.Controls.Add(this.imagesListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1011, 555);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 5;
            // 
            // RemoveImageButton
            // 
            this.RemoveImageButton.Location = new System.Drawing.Point(217, 45);
            this.RemoveImageButton.Name = "RemoveImageButton";
            this.RemoveImageButton.Size = new System.Drawing.Size(23, 23);
            this.RemoveImageButton.TabIndex = 5;
            this.RemoveImageButton.Text = "🗑";
            this.RemoveImageButton.UseVisualStyleBackColor = true;
            this.RemoveImageButton.Click += new System.EventHandler(this.RemoveImageButton_Click);
            // 
            // decreaseOrderButton
            // 
            this.decreaseOrderButton.Location = new System.Drawing.Point(217, 74);
            this.decreaseOrderButton.Name = "decreaseOrderButton";
            this.decreaseOrderButton.Size = new System.Drawing.Size(23, 23);
            this.decreaseOrderButton.TabIndex = 4;
            this.decreaseOrderButton.Text = "↓ ";
            this.decreaseOrderButton.UseVisualStyleBackColor = true;
            this.decreaseOrderButton.Click += new System.EventHandler(this.decreaseOrderButton_Click);
            // 
            // IncreaseOrderButton
            // 
            this.IncreaseOrderButton.Location = new System.Drawing.Point(217, 18);
            this.IncreaseOrderButton.Name = "IncreaseOrderButton";
            this.IncreaseOrderButton.Size = new System.Drawing.Size(23, 23);
            this.IncreaseOrderButton.TabIndex = 3;
            this.IncreaseOrderButton.Text = "↑";
            this.IncreaseOrderButton.UseVisualStyleBackColor = true;
            this.IncreaseOrderButton.Click += new System.EventHandler(this.IncreaseOrderButton_Click);
            // 
            // imagesListView
            // 
            this.imagesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.imagesListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imagesListView.HideSelection = false;
            this.imagesListView.Location = new System.Drawing.Point(0, 0);
            this.imagesListView.MultiSelect = false;
            this.imagesListView.Name = "imagesListView";
            this.imagesListView.Size = new System.Drawing.Size(204, 555);
            this.imagesListView.TabIndex = 0;
            this.imagesListView.UseCompatibleStateImageBehavior = false;
            this.imagesListView.SelectedIndexChanged += new System.EventHandler(this.imagesListView_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(757, 555);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.Location = new System.Drawing.Point(924, 576);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 6;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousButton.Location = new System.Drawing.Point(12, 577);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(75, 23);
            this.previousButton.TabIndex = 7;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // IndexIdentifierLabel
            // 
            this.IndexIdentifierLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IndexIdentifierLabel.AutoSize = true;
            this.IndexIdentifierLabel.Location = new System.Drawing.Point(93, 582);
            this.IndexIdentifierLabel.Name = "IndexIdentifierLabel";
            this.IndexIdentifierLabel.Size = new System.Drawing.Size(24, 13);
            this.IndexIdentifierLabel.TabIndex = 3;
            this.IndexIdentifierLabel.Text = "0/0";
            // 
            // PreviewImageButton1
            // 
            this.PreviewImageButton1.BackColor = System.Drawing.Color.White;
            this.PreviewImageButton1.ForeColor = System.Drawing.Color.Black;
            this.PreviewImageButton1.Location = new System.Drawing.Point(217, 186);
            this.PreviewImageButton1.Name = "PreviewImageButton1";
            this.PreviewImageButton1.Size = new System.Drawing.Size(23, 23);
            this.PreviewImageButton1.TabIndex = 7;
            this.PreviewImageButton1.Text = "0";
            this.PreviewImageButton1.UseVisualStyleBackColor = false;
            this.PreviewImageButton1.Click += new System.EventHandler(this.PreviewImageButton1_Click);
            // 
            // KeyImageButton
            // 
            this.KeyImageButton.Location = new System.Drawing.Point(217, 160);
            this.KeyImageButton.Name = "KeyImageButton";
            this.KeyImageButton.Size = new System.Drawing.Size(23, 23);
            this.KeyImageButton.TabIndex = 6;
            this.KeyImageButton.Text = "🔑";
            this.KeyImageButton.UseVisualStyleBackColor = true;
            this.KeyImageButton.Click += new System.EventHandler(this.KeyImageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 601);
            this.Controls.Add(this.IndexIdentifierLabel);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtCaption);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "charlieahill.co.uk Gallery Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectImageToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem generateOutputToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.ListView imagesListView;
        private System.Windows.Forms.Label IndexIdentifierLabel;
        private System.Windows.Forms.Button RemoveImageButton;
        private System.Windows.Forms.Button decreaseOrderButton;
        private System.Windows.Forms.Button IncreaseOrderButton;
        private System.Windows.Forms.Button PreviewImageButton1;
        private System.Windows.Forms.Button KeyImageButton;
    }
}

