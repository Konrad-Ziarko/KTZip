using KTZipPresentation.Model;
using KTZipPresentation.Properties;
using KTZipPresentation.View;
using System.Windows.Forms;

namespace KTZipPresentation.Control
{
    public class MainControler
    {
        MainModel theModel;
        MainWindow theView;
        public enum OperationType
        {
            FirstLoad,
            LoadNext,
            LoadPrev,
            Reload,
            LoadNew,
            MoveUp,
            NoReload,
        }
        public MainControler(MainWindow theView, MainModel theModel)
        {
            this.theModel = theModel;
            this.theView = theView;

            this.theView.ASendGridTempl += TheView_SendGridTempl;
            this.theView.AReloadContent += TheView_ReloadContent;
            this.theView.ADeleteSelectedFiles += TheView_ADeleteSelectedFiles;
        }

        private void TheView_ADeleteSelectedFiles(DataGridViewSelectedRowCollection obj)
        {
            theModel.notDeletedFiles = "";
            theModel.DeleteSelectedFiles(obj);
        }

        private void TheView_ReloadContent(string obj, OperationType OpTy)
        {
            theModel.reloadContent(obj, OpTy);
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
