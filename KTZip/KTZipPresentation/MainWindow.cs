using KTZipPresentation.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static KTZipPresentation.Control.MainControler;

namespace KTZipPresentation.View
{
    public partial class MainWindow : Form
    {
        public event Action ASendGridTempl;

        public event Action AFormLoad;
        public event Action AFormClosing;
        public event Action ADragDrop;
        public event Action AResizeEnd;
        public event Action<string, OperationType> AReloadContent;
        public event Action<DataGridViewSelectedRowCollection> ADeleteSelectedFiles;
        public event Action<string, string> AContentDoubleClick;

        #region Other
        public MainWindow()
        {
            InitializeComponent();
            filesGrid.RowTemplate.Height = 21;
        }
        public delegate void SetTextDelegate(string txt);
        public void SetTextBoxText(string txt)
        {
            if (InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetTextBoxText);
                Invoke(d, txt);
            }
            else
            {
                textBox_Path.Text = txt;
            }
        }
        public void GetDataGrid(ref DataGridView dgv)
        {
            dgv = filesGrid;
        }
        private void newFileDialog()
        {
            using (NewFileForm form = new NewFileForm(this))
            {
                form.ShowDialog();
                RefreshContent();
            }
        }
        private void newRenameDialog(DataGridViewSelectedRowCollection files)
        {
            foreach (DataGridViewRow fileRow in files)
                using (RenameForm form = new RenameForm(Settings.Default.CurrentPath + "\\", fileRow.Cells[1].Value.ToString()))
                {
                    form.ShowDialog();
                    RefreshContent();
                }
        }
        public void RefreshContent()
        {
            AReloadContent("", OperationType.Reload);
        }
        #endregion

        #region MainFormMethods
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            ASendGridTempl();
            AReloadContent(textBox_Path.Text, OperationType.FirstLoad);
            MainWindow_Resize(sender, e);
        }
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            int reserved = 22;
            if (filesGrid.Controls.OfType<VScrollBar>().First().Visible)
                reserved += 17;
            int widthToFill = filesGrid.Width - reserved;
            if ((int)(widthToFill * 0.10) > 80)
            {
                filesGrid.Columns[3].Width = 80;
                filesGrid.Columns[4].Width = 80;
            }
            else
            {
                filesGrid.Columns[3].Width = (int)(widthToFill * 0.10);
                filesGrid.Columns[4].Width = (int)(widthToFill * 0.10);
            }
            widthToFill -= (filesGrid.Columns[3].Width + filesGrid.Columns[4].Width);
            if ((int)(widthToFill * 0.31) > 100)
                filesGrid.Columns[2].Width = 100;
            else
                filesGrid.Columns[2].Width = (int)(widthToFill * 0.31);
            widthToFill -= filesGrid.Columns[2].Width;
            filesGrid.Columns[1].Width = widthToFill;
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshContent();
            }
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }
        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {

        }
        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region ButtonsMethods
        private void buttonBack_Click(object sender, EventArgs e)
        {
            AReloadContent("", OperationType.LoadPrev);
        }
        private void buttonUp_Click(object sender, EventArgs e)
        {
            string[] parts = Settings.Default.CurrentPath.Split('\\');
            string tmp = "";
            int j = 1;
            if (parts.Last() == "")
                j++;
            for (int i = 0; i < parts.Length - j; i++)
                tmp += parts[i] + '\\';
            if (Settings.Default.CurrentPath != "C:\\")
                AReloadContent(tmp, OperationType.MoveUp);
            else
                AReloadContent("", OperationType.NoReload);
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            AReloadContent("", OperationType.LoadNext);
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshContent();
        }
        #endregion

        private void textBox_Path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AReloadContent(textBox_Path.Text, OperationType.LoadNew);
            }
        }

        #region FilesGridViewMethods
        private void filesGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && filesGrid.SelectedRows.Count == 1)
            {
                AReloadContent(Settings.Default.CurrentPath + "\\" + filesGrid.SelectedRows[0].Cells[1].Value.ToString(), OperationType.LoadNew);
            }
        }
        private void filesGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                if (!filesGrid.SelectedRows.Contains(filesGrid.Rows[e.RowIndex]))
                    filesGrid.ClearSelection();
                filesGrid.Rows[e.RowIndex].Selected = true;
                filesGrid_contextMenu.Show(Cursor.Position);
            }
        }
        private void filesGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex != -1)
                AContentDoubleClick(textBox_Path.Text + '\\' + filesGrid.Rows[e.RowIndex].Cells[1].Value.ToString(), filesGrid.Rows[e.RowIndex].Cells[5].Value.ToString());
        }
        private void filesGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Location.Y > filesGrid.ColumnHeadersHeight + filesGrid.Rows.Cast<DataGridViewRow>().Sum(r => r.Height))
            {
                filesGrid.ClearSelection();
            }
            else if (e.Button == MouseButtons.XButton1)
            {
                AReloadContent("", OperationType.LoadPrev);
            }
            else if (e.Button == MouseButtons.XButton2)
            {
                AReloadContent("", OperationType.LoadNext);
            }
            else if (e.Button == MouseButtons.Right && e.Y > filesGrid.Rows.GetRowsHeight(DataGridViewElementStates.Displayed))
            {
                filesGrid_contextMenu.Show(Cursor.Position);
            }
        }

        private void filesGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (filesGrid.SelectedRows.Count > 0)
            {
                toolStripDeleteFile.Enabled = true;
                contextDelete.Enabled = true;

                toolStripChangeName.Enabled = true;
                contextRename.Enabled = true;
            }
            else
            {
                toolStripDeleteFile.Enabled = false;
                contextDelete.Enabled = false;
                toolStripChangeName.Enabled = false;
                contextRename.Enabled = false;
            }
        }
        #endregion

        #region MenuToolStripMethods
        private void toolStripNewFolder_Click(object sender, EventArgs e)
        {
            newFileDialog();
        }
        private void toolStripEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripSelectAll_Click(object sender, EventArgs e)
        {
            filesGrid.SelectAll();
        }

        private void toolStripUnselectAll_Click(object sender, EventArgs e)
        {
            filesGrid.ClearSelection();
        }

        private void toolStripChangeName_Click(object sender, EventArgs e)
        {
            newRenameDialog(filesGrid.SelectedRows);
        }

        private void toolStripFileProperties_Click(object sender, EventArgs e)
        {

        }

        private void toolStripOptions_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region ContextMenu
        private void contextCut_Click(object sender, EventArgs e)
        {

        }
        private void contextCopy_Click(object sender, EventArgs e)
        {

        }
        private void contextPaste_Click(object sender, EventArgs e)
        {

        }
        private void contextRename_Click(object sender, EventArgs e)
        {
            newRenameDialog(filesGrid.SelectedRows);
        }
        private void contextProperties_Click(object sender, EventArgs e)
        {

        }
        private void contextDelete_Click(object sender, EventArgs e)
        {
            ADeleteSelectedFiles(filesGrid.SelectedRows);
            RefreshContent();
        }
        private void contextCreate_Click(object sender, EventArgs e)
        {
            newFileDialog();
        }
        #endregion

    }
}
