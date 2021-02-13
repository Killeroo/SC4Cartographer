using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SC4CartographerUI
{
    public partial class SuccessForm : Form
    {
        private string FilePath = "";

        public SuccessForm(string title, string line1, string line2, string path = "")
        {
            InitializeComponent();
            this.Text = title;
            PathTextBox.Text = line1 + Environment.NewLine + line2;
            FilePath = path;

            if (path != "")
            {
                FilePath = path;
            }
            else
            {
                OpenFolderButton.Visible = false;
            }
        }

        private void SuccessForm_OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Information, 16, 8);
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            // Source: https://stackoverflow.com/a/13680458
            Process.Start("explorer.exe", string.Format("/select,\"{0}\"", FilePath));
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
