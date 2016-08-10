using KTZipPresentation.Model;
using KTZipPresentation.Properties;
using KTZipPresentation.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTZipPresentation.Control
{
    public class MainControler
    {
        MainModel theModel;
        MainWindow theView;
        Thread T;
        public MainControler(MainWindow theView, MainModel theModel)
        {
            this.theModel = theModel;
            this.theView = theView;

            this.theView.SendGridTempl += TheView_SendGridTempl;
            this.theView.ReloadContent += TheView_ReloadContent;
        }

        private void TheView_ReloadContent(string obj, int isForward)
        {
            if (T != null)
                T.Abort();
            T = new Thread(() =>
            {
                theModel.reloadContent(obj, isForward);
                theView.SetTextBoxText(Settings.Default.CurrentPath);
            });
            T.Start();
        }

        private void TheView_SendGridTempl()
        {
            DataGridView dgv = null;
            theView.GetDataGrid(ref dgv);
            theModel.filesGrid = dgv;
        }
    }
}
