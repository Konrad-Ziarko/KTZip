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
            this.theView.AContentDoubleClick += TheView_AContentDoubleClick1;
        }

        private void TheView_AContentDoubleClick1(string path, string attributes)
        {
            if (attributes == "D")
                TheView_ReloadContent(path, OperationType.LoadNew);
            else if (attributes == "F")
                using(PreviewEditForm prevForm = new PreviewEditForm(path))
                {

                }
            else if (attributes == "A")
                ;
        }

        private void TheView_ADeleteSelectedFiles(DataGridViewSelectedRowCollection rows)
        {
            string result = theModel.DeleteSelectedFiles(rows);
            if (result != "")
                new ErrorForm(result).ShowDialog();
        }

        private void TheView_ReloadContent(string path, OperationType OpTy)
        {
            theModel.reloadContent(path, OpTy);
            if (theModel.filesGrid.SortedColumn != null)
            {
                DataGridViewColumn col = theModel.filesGrid.SortedColumn;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
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
