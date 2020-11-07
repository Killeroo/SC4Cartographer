using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace SC4CartographerUI
{
    public partial class MapErrorForm : Form
    {
        private string ExceptionText = "";
        private string ExceptionStackTrace = "";

        public MapErrorForm(string title, string message, Exception exception, bool showInnerException)
        {
            InitializeComponent();
            Text = title;
            ErrorMessageTextbox.Text = message + Environment.NewLine;

            string exceptionText = $"[{exception.GetType().ToString()}: {exception.Message}]";
            if (showInnerException)
            {
                exceptionText += $" -> {exception.InnerException.GetType().ToString()}: {exception.InnerException.Message}";
            }

            ExceptionText = exceptionText;
            ExceptionStackTrace = exception.StackTrace;

            ErrorMessageTextbox.Text += exceptionText + Environment.NewLine;
            ErrorMessageTextbox.Text += exception.StackTrace;
        }

        private void MapErrorForm_OnLoad(object sender, EventArgs e)
        {

        }

        private void MapErrorForm_OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Error, 16, 16);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CopyErrorButton_Click(object sender, EventArgs e)
        {
            // Copy nice error details along with version info to clipboard
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildInfo = Assembly.GetExecutingAssembly().GetLinkerTime();
            string version = Assembly.GetExecutingAssembly().GetName().Name + " v" + v.Major + "." + v.Minor + "." + v.Build + " (r" + v.Revision + ") ";

            string errorDetails = string.Format("{0} (build time: {3})\n{1}\n{2}", version, ExceptionText, ExceptionStackTrace, buildInfo.ToString());
            Clipboard.SetText(errorDetails);


        }


    }
}
