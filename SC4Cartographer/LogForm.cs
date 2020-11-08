using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace SC4CartographerUI
{
    public partial class LogForm : Form
    {
        private string logPath;
        private bool logStarted;

        public LogForm(string path, bool started)
        {
            InitializeComponent();
            logPath = path;
            logStarted = started;

        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            if (logStarted == false)
            {
                LogOutputTextbox.Text = "Log could not be created.";
                return;
            }

            // Read log file contents into textbox
            try
            {
                Version v = Assembly.GetExecutingAssembly().GetName().Version;
                string version = Assembly.GetExecutingAssembly().GetName().Name + " v" + v.Major + "." + v.Minor + "." + v.Build + " (r" + v.Revision + ") ";

                LogOutputTextbox.Text = version + Environment.NewLine + File.ReadAllText(logPath);
                LogOutputTextbox.SelectionStart = LogOutputTextbox.Text.Length;
                LogOutputTextbox.ScrollToCaret();
            }
            catch (Exception ex)
            {
                LogOutputTextbox.Text = "An error occured reading log file. (" + ex.GetType().ToString() + ":" + ex.Message + ")";
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(LogOutputTextbox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not copy message to clipboard", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
