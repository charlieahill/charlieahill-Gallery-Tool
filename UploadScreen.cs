using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace charlieahill_Gallery_Tool
{
    public partial class UploadScreen : Form
    {
        public UploadScreen(string OutputFolder, string galleryInfo, string indexInfo)
        {
            InitializeComponent();
            txtGallery.Text = galleryInfo;
            txtIndex.Text = indexInfo;
            txtOutputFile.Text = OutputFolder;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", txtOutputFile.Text);
        }

        private void btnCopyGallery_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtGallery.Text);
        }

        private void btnCopyIndex_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtIndex.Text);
        }
    }
}
