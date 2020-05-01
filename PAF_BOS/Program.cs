using System;
using System.Windows.Forms;

namespace PAF_BOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Loginfrm());
            if (!string.IsNullOrEmpty(MainClass.UserName))
            {
                Application.Run(new Mainfrm());
            }
        }
    }
}
