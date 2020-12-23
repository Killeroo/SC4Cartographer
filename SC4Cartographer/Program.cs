using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SC4CartographerUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
            {
                // run normally with default parameters
                Application.Run(new MainForm());
            }
            else
            {
                // Try and run program with properties file specified
                Application.Run(new MainForm(args[0]));
            }
        }
    }
}
