using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace G_POS_Form
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
            //Application.Run(new Form1());
            Application.Run(new G_POS.POS.Forms.LoginForm());
            //Application.Run(new G_POS.POS.Forms.POSForm());

           // Application.Run(new G_POS.POS.Forms.SalesForm());
        }
    }
}
