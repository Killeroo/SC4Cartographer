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
    public partial class MapCreatedForm : Form
    {
        string savePath = "";

        public MapCreatedForm(string folder, string filename)
        {
            InitializeComponent();
            MapCreatedLabel.Text = $"Map '{filename}' has been successfully saved to";
            PathLabel.Text = folder;
            savePath = folder;
        }

        private void MapCreatedForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Information, 16, 16);
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", savePath);
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
