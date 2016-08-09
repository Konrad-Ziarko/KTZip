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
        public event Action SendGridTempl;

        public event Action AFormLoad;
        public event Action AFormClosing;
        public event Action ADragDrop;
        public event Action AResizeEnd;
        public event Action<string> ReloadContent;

        public MainWindow()
        {
            InitializeComponent();
            filesGrid.RowTemplate.Height = 21;
            int widthToFill = filesGrid.Width;
            widthToFill -= 270;
            filesGrid.Columns[1].Width = widthToFill - 2;
        }

        #region MainFormMethods
        public DataGridView GetDataGrid()
        {
            return filesGrid;
        }
        public void SetDataGrid(DataGridView dgv)
        {
            filesGrid = dgv;
        }
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            SendGridTempl();
            textBox_Path.Text = Settings.Default.CurrentPath;
            ReloadContent(Settings.Default.CurrentPath);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {
            int widthToFill = filesGrid.Width;
            widthToFill -= (30 + filesGrid.Columns[2].Width + filesGrid.Columns[3].Width + filesGrid.Columns[4].Width);
            filesGrid.Columns[1].Width = widthToFill-2;
        }

        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region MenuToolStripMethods
        private void optionsToolStrip_Click(object sender, EventArgs e)
        {

        }
        private void adsToolStrip_Click(object sender, EventArgs e)
        {
            adsToolStrip.Checked = !adsToolStrip.Checked;
        }
        private void editToolStrip_Click(object sender, EventArgs e)
        {

        }
        private void createFolderToolStrip_Click(object sender, EventArgs e)
        {

        }
        private void endToolStrip_Click(object sender, EventArgs e)
        {

        }
        private void copyToolStrip_Click(object sender, EventArgs e)
        {

        }
        private void cutToolStrip_Click(object sender, EventArgs e)
        {

        }
        private void selectAllToolStrip_Click(object sender, EventArgs e)
        {

        }
        private void unselectAllToolStrip_Click(object sender, EventArgs e)
        {

        }
        private void changeNameToolStrip_Click(object sender, EventArgs e)
        {

        }
        private void deleteToolStrip_Click(object sender, EventArgs e)
        {

        }
        private void propertiesToolStrip_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region ButtonMethods
        private void buttonBack_Click(object sender, EventArgs e)
        {

        }

        private void buttonUp_Click(object sender, EventArgs e)
        {

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void textBox_Path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void filesGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int widthToFill = filesGrid.Width;
            widthToFill -= (30 + filesGrid.Columns[2].Width + filesGrid.Columns[3].Width + filesGrid.Columns[4].Width);
            filesGrid.Columns[1].Width = widthToFill - 2;
        }
    }
}
