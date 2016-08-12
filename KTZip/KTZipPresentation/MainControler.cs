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
        public MainControler(MainWindow theView, MainModel theModel)
        {
            this.theModel = theModel;
            this.theView = theView;

            this.theView.ASendGridTempl += TheView_SendGridTempl;
            this.theView.AReloadContent += TheView_ReloadContent;
            this.theView.AReloadSameContent += TheView_AReloadSameContent;
            this.theView.ADeleteSelectedFiles += TheView_ADeleteSelectedFiles;
        }

        private void TheView_ADeleteSelectedFiles(DataGridViewSelectedRowCollection obj)
        {
            theModel.notDeletedFiles = "";
            theModel.DeleteSelectedFiles(obj);
        }

        private void TheView_AReloadSameContent()
        {
            theModel.reloadSameContent();
            theView.SetTextBoxText(Settings.Default.CurrentPath);
        }

        private void TheView_ReloadContent(string obj, int isForward)
        {
            theModel.reloadContent(obj, isForward);
            theView.SetTextBoxText(Settings.Default.CurrentPath);
        }

        private void TheView_SendGridTempl()
        {
            DataGridView dgv = null;
            theView.GetDataGrid(ref dgv);
            theModel.filesGrid = dgv;
        }
    }
}
