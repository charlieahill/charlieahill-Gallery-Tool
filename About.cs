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
    public partial class About : Form
    {
        public static string VERSION = "1.0.0";

        public About()
        {
            InitializeComponent();
            lblVersion.Text = "Version " + VERSION;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            string versionFolder = @"E:\Software\Locker\charlieahill Gallery Creator\";
            Process.Start("explorer.exe", versionFolder);
        }
    }
}
