using KTZipPresentation.Control;
using KTZipPresentation.Model;
using KTZipPresentation.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTZipPresentation
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
            MainWindow mw = new MainWindow();
            new MainControler(mw, new MainModel());
            Application.Run(mw);
        }
    }
}
