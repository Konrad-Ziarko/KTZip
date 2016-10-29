using KTZipPresentation.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static KTZipPresentation.Control.MainControler;

namespace KTZipPresentation.View
{
    public partial class MainWindow : Form
    {
        public event Action ASendGridTempl;

        public event Action AFormLoad;
        public event Action ADragDrop;
        public event Action<string, OperationType> AReloadContent;
        public event Action<DataGridViewSelectedRowCollection> ADeleteSelectedFiles;
        public event Action<string, string> AContentDoubleClick;
        public event Action<DataGridViewSelectedRowCollection> AShowProperties;
        public event Action<DataGridViewSelectedRowCollection> ACutFiles;
        public event Action<DataGridViewSelectedRowCollection> ACopyFiles;
        public event Action<string> APasteFiles;

        #region Other
        public MainWindow()
        {
            InitializeComponent();
            filesGrid.RowTemplate.Height = 21;
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (var drive in allDrives)
                comboBox_Path.Items.Add(drive);
            nightModeToolStripMenuItem.Checked = Settings.Default.NightMode;
            switchNightMode();
        }
        public delegate void SetTextDelegate(string txt);
        public void SetComboBoxText(string txt)
        {
            if (InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetComboBoxText);
                Invoke(d, txt);
            }
            else
            {
                comboBox_Path.Text = txt;
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
        private void comboBox_Path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AReloadContent(comboBox_Path.Text, OperationType.LoadNew);
            }
        }
        private void comboBox_Path_SelectedIndexChanged(object sender, EventArgs e)
        {
            AReloadContent(comboBox_Path.Text, OperationType.LoadNew);
        }
        private void switchNightMode()
        {
            Color BackColor, ForeColor;
            if (Settings.Default.NightMode)
            {
                BackColor = SystemColors.Desktop;
                ForeColor = Color.FromArgb(255, 200, 200, 200);
            }
            else
            {
                BackColor = SystemColors.Control;
                ForeColor = Color.FromArgb(255, 0, 0, 0);
            }

            foreach (System.Windows.Forms.Control item in this.Controls)
            {
                item.BackColor = BackColor;
                item.ForeColor = ForeColor;
            }
            foreach (var item in menuStrip1.Items)
            {
                foreach (var child in ((ToolStripMenuItem)item).DropDownItems)
                {
                    if (child.GetType() == typeof(ToolStripMenuItem))
                    {
                        ((ToolStripMenuItem)child).BackColor = BackColor;
                        ((ToolStripMenuItem)child).ForeColor = ForeColor;
                    }
                    else if ((child.GetType() == typeof(ToolStripSeparator)) && Settings.Default.NightMode)
                        ((ToolStripSeparator)child).Paint += BlackToolStripSeparator_Paint;
                    else if ((child.GetType() == typeof(ToolStripSeparator)) && !Settings.Default.NightMode)
                        ((ToolStripSeparator)child).Paint += WhiteToolStripSeparator_Paint;
                }
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).BackColor = BackColor;
                    ((ToolStripMenuItem)item).ForeColor = ForeColor;
                }
                else if ((item.GetType() == typeof(ToolStripSeparator)) && Settings.Default.NightMode)
                    ((ToolStripSeparator)item).Paint += BlackToolStripSeparator_Paint;
                else if ((item.GetType() == typeof(ToolStripSeparator)) && !Settings.Default.NightMode)
                    ((ToolStripSeparator)item).Paint += WhiteToolStripSeparator_Paint;
            }

            foreach (var item in filesGrid_contextMenu.Items)
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).BackColor = BackColor;
                    ((ToolStripMenuItem)item).ForeColor = ForeColor;
                }
                else if ((item.GetType() == typeof(ToolStripSeparator)) && Settings.Default.NightMode)
                    ((ToolStripSeparator)item).Paint += BlackToolStripSeparator_Paint;
                else if ((item.GetType() == typeof(ToolStripSeparator)) && !Settings.Default.NightMode)
                    ((ToolStripSeparator)item).Paint += WhiteToolStripSeparator_Paint;
            }

            filesGrid.BackgroundColor = BackColor;
            filesGrid.DefaultCellStyle.BackColor = BackColor;
            filesGrid.ColumnHeadersDefaultCellStyle.BackColor = BackColor;
            comboBox_Path.BackColor = BackColor;
            filesGrid.ForeColor = ForeColor;
            filesGrid.ColumnHeadersDefaultCellStyle.ForeColor = ForeColor;
            comboBox_Path.ForeColor = ForeColor;

            buttonBack.ForeColor = buttonBack.BackColor = BackColor;
            buttonUp.ForeColor = buttonUp.BackColor = BackColor;
            buttonNext.ForeColor = buttonNext.BackColor = BackColor;
            buttonRefresh.ForeColor = buttonRefresh.BackColor = BackColor;
            panelTopLeft.BackColor = BackColor;
        }
        #endregion

        #region MainFormMethods
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            ASendGridTempl();
            AReloadContent(comboBox_Path.Text, OperationType.FirstLoad);
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

        internal void resetCutPaste()
        {
            contextPaste.Enabled = false;
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
                if (filesGrid.Rows[e.RowIndex].Selected != true)
                    filesGrid.ClearSelection();
                filesGrid.Rows[e.RowIndex].Selected = true;
                filesGrid_contextMenu.Show(Cursor.Position);
            }
        }
        private void filesGrid_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo myHitTest = filesGrid.HitTest(e.X, e.Y);
            if (e.Button == MouseButtons.Right && myHitTest.RowIndex == -1)
            {
                filesGrid.ClearSelection();
            }
            filesGrid_CellMouseClick(sender, new DataGridViewCellMouseEventArgs(myHitTest.ColumnIndex, myHitTest.RowIndex, e.X, e.Y, e));
        }
        private void filesGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex != -1)
                AContentDoubleClick(Settings.Default.CurrentPath + '\\' + filesGrid.Rows[e.RowIndex].Cells[1].Value.ToString(), filesGrid.Rows[e.RowIndex].Cells[5].Value.ToString());
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

                contextCut.Enabled = true;
                contextCopy.Enabled = true;
            }
            else
            {
                toolStripDeleteFile.Enabled = false;
                contextDelete.Enabled = false;
                toolStripChangeName.Enabled = false;
                contextRename.Enabled = false;

                contextCut.Enabled = false;
                contextCopy.Enabled = false;
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

        private void toolStripOptions_Click(object sender, EventArgs e)
        {

        }

        private void nightModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.NightMode = !nightModeToolStripMenuItem.Checked;
            nightModeToolStripMenuItem.Checked = !nightModeToolStripMenuItem.Checked;
            switchNightMode();
        }

        #endregion

        #region ContextMenu
        private void contextCut_Click(object sender, EventArgs e)
        {
            ACutFiles(filesGrid.SelectedRows);
            contextPaste.Enabled = true;
        }
        private void contextCopy_Click(object sender, EventArgs e)
        {
            ACopyFiles(filesGrid.SelectedRows);
            contextPaste.Enabled = true;
        }
        private void contextPaste_Click(object sender, EventArgs e)
        {
            string whereToPaste = string.Empty;
            if (filesGrid.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in filesGrid.SelectedRows)
                {
                    FileAttributes attributes = File.GetAttributes(Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString());
                    if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
                        whereToPaste = Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString();
                    else
                        whereToPaste = Settings.Default.CurrentPath;
                }
            }
            else
            {
                whereToPaste = Settings.Default.CurrentPath;
            }
            APasteFiles(whereToPaste);
            RefreshContent();
        }
        private void contextRename_Click(object sender, EventArgs e)
        {
            newRenameDialog(filesGrid.SelectedRows);
        }
        private void contextProperties_Click(object sender, EventArgs e)
        {
            AShowProperties(filesGrid.SelectedRows);
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
        private void filesGrid_contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        #endregion

        #region CustomeMenuItemSeparator

        private void BlackToolStripSeparator_Paint(object sender, PaintEventArgs e)
        {
            ToolStripSeparator toolStripSeparator = (ToolStripSeparator)sender;
            int width = toolStripSeparator.Width;
            int height = toolStripSeparator.Height;

            Color foreColor = Color.FromArgb(255, 200, 200, 200);
            Color backColor = SystemColors.Desktop;

            e.Graphics.FillRectangle(new SolidBrush(backColor), 0, 0, width, height);
            e.Graphics.DrawLine(new Pen(foreColor), 4, height / 2, width - 4, height / 2);
        }
        private void WhiteToolStripSeparator_Paint(object sender, PaintEventArgs e)
        {
            ToolStripSeparator toolStripSeparator = (ToolStripSeparator)sender;
            int width = toolStripSeparator.Width;
            int height = toolStripSeparator.Height;

            Color foreColor = Color.FromArgb(255, 0, 0, 0);
            Color backColor = SystemColors.Window;

            e.Graphics.FillRectangle(new SolidBrush(backColor), 0, 0, width, height);
            e.Graphics.DrawLine(new Pen(foreColor), 4, height / 2, width - 4, height / 2);
        }
        #endregion

        private void toolStripFileProperties_Click(object sender, EventArgs e)
        {
            AShowProperties(filesGrid.SelectedRows);
        }

        private void cRC32ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cRC64ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sHA256ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moreCRCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compresToZipToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compresTo7zToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToAchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
