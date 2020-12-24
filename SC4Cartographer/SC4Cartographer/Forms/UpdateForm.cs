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
    public partial class UpdateForm : Form
    {
        UpdateInfo Update;

        public UpdateForm(UpdateInfo update)
        {
            InitializeComponent();

            // Populate form with update info
            Update = update;
            UpdateLabel.Text = "Do you want to download v" + update.Version.ToString() + "?";
            ChangelogTextBox.Text = string.Format("{0} changelog {1}{2}{3}{4}",
                update.Version.ToString(),
                Environment.NewLine,
                "--------------------------",
                Environment.NewLine,
                update.Description);

            if (Properties.Settings.Default.FirstTimeUpdatePrompt)
            {
                // Enable the option to automatically turn off auto updates 
                // by default on first update prompt (auto updates here are a bit annoying)
                DoNotShowAgainCheckbox.Checked = true;
                Properties.Settings.Default.FirstTimeUpdatePrompt = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                DoNotShowAgainCheckbox.Checked = Properties.Settings.Default.IgnoreUpdatePrompts;
            }
        }

        private void UpdateForm_OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Question, 16, 8);
        }

        private void UpdatePageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdatePageLinkLabel.LinkVisited = true;

            Process.Start(Update.ReleasePageLink);
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            Process.Start(Update.BrowserDownloadLink);

            Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoNotShowAgainCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IgnoreUpdatePrompts = DoNotShowAgainCheckbox.Checked;
            Properties.Settings.Default.Save();
        }

        private void UpdateForm_OnClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.IgnoreUpdatePrompts = DoNotShowAgainCheckbox.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
