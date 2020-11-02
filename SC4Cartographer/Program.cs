using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SC4CartographerUI
{
    static class Program
    {
        // Zoom
        //https://stackoverflow.com/a/10916023
        // Click and drag
        //https://stackoverflow.com/a/33596149

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
