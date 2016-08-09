using KTZipPresentation.Properties;
using KTZipModels;
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
        public event Action AFormLoad;
        public event Action AFormClosing;
        public event Action ADragDrop;
        public event Action AResizeEnd;

        public MainWindow()
        {
            InitializeComponent();
            filesGrid.RowTemplate.Height = 21;
            int widthToFill = filesGrid.Width;
            widthToFill -= 270;
            filesGrid.Columns[1].Width = widthToFill - 2;
        }

        #region MainFormMethods
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            reloadContent();
        }

        private void reloadContent()
        {
            textBox_Path.Text = Settings.Default.CurrentPath;
            reloadDirs();
            reloadFiles();
        }

        private void reloadFiles()
        {
            FileInfoGeter fig;
            string[] files = Directory.GetFiles(Settings.Default.CurrentPath);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                unsafe
                {
                    fixed(char* ptr = &file[0])
                    fig = new FileInfoGeter(ptr);
                }
                
                //FileInfo fi = new FileInfo(file);
                //string modif, create;
                //if (fi.LastWriteTime.Date == DateTime.Today)
                //    modif = fi.LastWriteTime.ToString("HH:mm:ss");
                //else
                //    modif = fi.LastWriteTime.Date.ToString("dd-MM-yyyy");
                //if (fi.CreationTime.Date == DateTime.Today)
                //    create = fi.CreationTime.ToString("HH:mm:ss");
                //else
                //    create = fi.CreationTime.Date.ToString("dd-MM-yyyy");
                filesGrid.Rows.Add(new object[] { Icon.ExtractAssociatedIcon(file), fileName, String.Format("{0:n0}", fi.Length), modif, create });
            }
        }
        private void reloadDirs()
        {
            string[] dirs = Directory.GetDirectories(Settings.Default.CurrentPath);
            foreach (string dir in dirs)
            {
                string dirName = Path.GetFileName(dir);
                FileInfo fi = new FileInfo(dir);
                string modif, create;
                if (fi.LastWriteTime.Date == DateTime.Today)
                    modif = fi.LastWriteTime.ToString("HH:mm:ss");
                else
                    modif = fi.LastWriteTime.Date.ToString("dd-MM-yyyy");
                if (fi.CreationTime.Date == DateTime.Today)
                    create = fi.CreationTime.ToString("HH:mm:ss");
                else
                    create = fi.CreationTime.Date.ToString("dd-MM-yyyy");
                filesGrid.Rows.Add(new object[] { Properties.Resources.folder1, dirName, "", modif, create });
            }
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
