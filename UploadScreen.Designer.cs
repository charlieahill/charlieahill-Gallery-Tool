namespace charlieahill_Gallery_Tool
{
    partial class UploadScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadScreen));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtGallery = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCopyGallery = new System.Windows.Forms.Button();
            this.btnCopyIndex = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gallery Creation Complete";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Files output to:";
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Enabled = false;
            this.txtOutputFile.Location = new System.Drawing.Point(96, 46);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(395, 20);
            this.txtOutputFile.TabIndex = 2;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.Image")));
            this.btnOpenFile.Location = new System.Drawing.Point(497, 44);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(27, 23);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtGallery
            // 
            this.txtGallery.Enabled = false;
            this.txtGallery.Location = new System.Drawing.Point(12, 117);
            this.txtGallery.Multiline = true;
            this.txtGallery.Name = "txtGallery";
            this.txtGallery.Size = new System.Drawing.Size(518, 204);
            this.txtGallery.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Code to add to gallery.html";
            // 
            // btnCopyGallery
            // 
            this.btnCopyGallery.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyGallery.Image")));
            this.btnCopyGallery.Location = new System.Drawing.Point(497, 89);
            this.btnCopyGallery.Name = "btnCopyGallery";
            this.btnCopyGallery.Size = new System.Drawing.Size(27, 23);
            this.btnCopyGallery.TabIndex = 6;
            this.btnCopyGallery.UseVisualStyleBackColor = true;
            this.btnCopyGallery.Click += new System.EventHandler(this.btnCopyGallery_Click);
            // 
            // btnCopyIndex
            // 
            this.btnCopyIndex.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyIndex.Image")));
            this.btnCopyIndex.Location = new System.Drawing.Point(497, 335);
            this.btnCopyIndex.Name = "btnCopyIndex";
            this.btnCopyIndex.Size = new System.Drawing.Size(27, 23);
            this.btnCopyIndex.TabIndex = 9;
            this.btnCopyIndex.UseVisualStyleBackColor = true;
            this.btnCopyIndex.Click += new System.EventHandler(this.btnCopyIndex_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Code to add to index.html";
            // 
            // txtIndex
            // 
            this.txtIndex.Enabled = false;
            this.txtIndex.Location = new System.Drawing.Point(12, 363);
            this.txtIndex.Multiline = true;
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(518, 204);
            this.txtIndex.TabIndex = 7;
            // 
            // UploadScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 593);
            this.Controls.Add(this.btnCopyIndex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.btnCopyGallery);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGallery);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UploadScreen";
            this.Text = "UploadScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtGallery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCopyGallery;
        private System.Windows.Forms.Button btnCopyIndex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIndex;
    }
}