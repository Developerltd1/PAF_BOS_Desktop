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
            Application.Run(new Mainfrm());

            //Application.Run(new UserAttendancefrm());
            //if (MainClass.IsLoginPageOpen)
            //{
            //    Application.Run(new Loginfrm());
            //    if (MainClass.UserName != null)
            //    {
            //    }
            //}
        }
    }
}
