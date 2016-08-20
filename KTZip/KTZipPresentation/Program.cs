using KTZipPresentation.Control;
using KTZipPresentation.Model;
using KTZipPresentation.Properties;
using KTZipPresentation.View;
using System;
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
            Settings.Default.History = new System.Collections.Specialized.StringCollection();
            Settings.Default.PositionInHistory = 0;
            MainWindow mw = new MainWindow();
            new MainControler(mw, new MainModel());
            Application.Run(mw);
        }
    }
}
