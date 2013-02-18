using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer
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
            //init the app object
            UVDLPApp.Instance().DoAppStartup();
            Application.Run(new frmMain());
        }
    }
}
