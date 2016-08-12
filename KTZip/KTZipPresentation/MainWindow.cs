using KTZipPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTZipPresentation.View
{
    public partial class MainWindow : Form
    {
        public event Action ASendGridTempl;

        public event Action AFormLoad;
        public event Action AFormClosing;
        public event Action ADragDrop;
        public event Action AResizeEnd;
        public event Action AReloadSameContent;
        public event Action<string, int> AReloadContent;
        public event Action<DataGridViewSelectedRowCollection> ADeleteSelectedFiles;

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
            dgv =  filesGrid;
        }
        #endregion

        #region MainFormMethods
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            ASendGridTempl();
            AReloadContent(textBox_Path.Text, 666);
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
                AReloadSameContent();
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

        #region ButtonMethods
        private void buttonBack_Click(object sender, EventArgs e)
        {
            AReloadContent("", -1);
        }
        private void buttonUp_Click(object sender, EventArgs e)
        {
            string[] parts = textBox_Path.Text.Split('\\');
            string tmp = "";
            int j = 1;
            if (parts.Last() == "")
                j++;
            for (int i = 0; i < parts.Length - j; i++)
                tmp += parts[i] + '\\';
            if (Settings.Default.CurrentPath != "C:\\")
                AReloadContent(tmp, 1);
            else
                AReloadContent("", int.MinValue);
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            AReloadContent("", 2);
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            AReloadSameContent();
        }
        #endregion

        private void textBox_Path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AReloadContent(textBox_Path.Text, 1);
            }
        }

        #region DataGridViewMethods
        private void filesGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //e.Column.MinimumWidth = e.Column.Width;
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
            else if (e.Button == MouseButtons.XButton1)
            {
                AReloadContent("", -1);
            }
            else if (e.Button == MouseButtons.XButton2)
            {
                AReloadContent("", 2);
            }
        }
        private void filesGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex != -1)
                AReloadContent(textBox_Path.Text + '\\' + filesGrid.Rows[e.RowIndex].Cells[1].Value.ToString(), 1);
        }
        #endregion

        #region MenuToolStripMethods
        private void toolStripNewFolder_Click(object sender, EventArgs e)
        {
            using (NewFileForm form = new NewFileForm())
            {
                form.ShowDialog();
                AReloadSameContent();
            }
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

        }

        private void toolStripFileProperties_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTurnAds_Click(object sender, EventArgs e)
        {

        }

        private void toolStripOptions_Click(object sender, EventArgs e)
        {

        }
        private void deletFileToolStrip_Click(object sender, EventArgs e)
        {
            ADeleteSelectedFiles(filesGrid.SelectedRows);
            AReloadSameContent();
        }
        #endregion
    }
}
