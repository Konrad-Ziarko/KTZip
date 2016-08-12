using KTZipPresentation.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trinet.Core.IO.Ntfs;

namespace KTZipPresentation.Model
{
    public class MainModel
    {
        public string notDeletedFiles { get; set; }
        public DataGridView filesGrid { get; set; }
        public void SetDataGrid (ref DataGridView dgv)
        {
            filesGrid = dgv;
        }

        public MainModel()
        {
        }

        #region LodingFilesFromCurrentLocation
        private Bitmap ChangeOpacity(Image img, float opacityvalue = 0.5f)
        {
            Bitmap bmp = new Bitmap(20, 20);
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix() { Matrix33 = opacityvalue };
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, 20, 20), 0, 0, 20, 20, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();
            return bmp;
        }

        internal void reloadSameContent()
        {
            reloadDirs();
            reloadFiles();
        }

        public void reloadContent(string obj, int isForward)
        {
            bool reload = true;
            if (obj == @"\")
                obj = @"C:\";
            if (Directory.Exists(obj))
            {
                try
                {
                    Directory.GetDirectories(obj);
                    obj = obj.Replace(@"\\", @"\");
                    Settings.Default.CurrentPath = obj.Replace(@"\\", @"\");
                    if (isForward == 1)
                    {
                        for (int i = Settings.Default.History.Count - 1; i > Settings.Default.PositionInHistory; i--)
                            Settings.Default.History.RemoveAt(i);
                        Settings.Default.History.Add(obj);
                        Settings.Default.PositionInHistory++;
                    }
                    else if (isForward == 0)
                    {
                        Settings.Default.History.Add(obj);
                    }
                }
                catch
                {
                    reload = false;
                }
            }
            else if (obj == "" && isForward == -1)
            {
                if (Settings.Default.PositionInHistory > 0)
                    Settings.Default.CurrentPath = Settings.Default.History[--Settings.Default.PositionInHistory];
                else
                    reload = false;
            }
            else if (obj == "" && isForward == 2)
            {
                if (Settings.Default.PositionInHistory < Settings.Default.History.Count - 1)
                    Settings.Default.CurrentPath = Settings.Default.History[++Settings.Default.PositionInHistory];
                else
                    reload = false;
            }
            else if (obj == "" && isForward == 0)
            {
                Settings.Default.History.Add(Settings.Default.CurrentPath = @"C:\");
            }
            else if (isForward == int.MinValue)
                reload = false;
            if (reload)
            {
                reloadDirs();
                reloadFiles();
            }
        }
        private void reloadFiles()
        {
            string[] files = Directory.GetFiles(Settings.Default.CurrentPath);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                FileInfo fi = new FileInfo(file);
                string modif, create;
                if (fi.LastWriteTime.Date == DateTime.Today)
                    modif = fi.LastWriteTime.ToString("HH:mm:ss");
                else
                    modif = fi.LastWriteTime.Date.ToString("dd-MM-yyyy");
                if (fi.CreationTime.Date == DateTime.Today)
                    create = fi.CreationTime.ToString("HH:mm:ss");
                else
                    create = fi.CreationTime.Date.ToString("dd-MM-yyyy");
                Image img = new Bitmap(Icon.ExtractAssociatedIcon(file).ToBitmap(), new Size(20, 20));
                if ((fi.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    img = ChangeOpacity(img);
                filesGrid.Rows.Add(img, fileName, string.Format("{0:n0}", fi.Length), modif, create);
                img = new Bitmap(Resources.stream, new Size(20, 20));
                foreach (AlternateDataStreamInfo s in fi.ListAlternateDataStreams())
                {
                    filesGrid.Rows.Add(img, fileName+":"+s.Name, s.Size, modif, create);
                }
            }
        }
        private void reloadDirs()
        {
            ClearGridDelagate d1 = new ClearGridDelagate(clearGrid);
            filesGrid.Invoke(d1);
            string[] dirs = Directory.GetDirectories(Settings.Default.CurrentPath);
            foreach (string dir in dirs)
            {
                string dirName = Path.GetFileName(dir);
                FileInfo fi = new FileInfo(dir);
                DirectoryInfo di = new DirectoryInfo(dir);
                string modif, create;
                if (fi.LastWriteTime.Date == DateTime.Today)
                    modif = fi.LastWriteTime.ToString("HH:mm:ss");
                else
                    modif = fi.LastWriteTime.Date.ToString("dd-MM-yyyy");
                if (fi.CreationTime.Date == DateTime.Today)
                    create = fi.CreationTime.ToString("HH:mm:ss");
                else
                    create = fi.CreationTime.Date.ToString("dd-MM-yyyy");
                Image img = new Bitmap(Resources.folder, new Size(20, 20));
                if ((fi.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    img = ChangeOpacity(img);
                filesGrid.Rows.Add(img, dirName, "", modif, create);
                img = new Bitmap(Resources.stream, new Size(20, 20));
                foreach (AlternateDataStreamInfo s in di.ListAlternateDataStreams())
                {
                    filesGrid.Rows.Add(img, dirName + ":" + s.Name, s.Size, modif, create);
                }
            }
        }
        #endregion

        #region DataGrid
        public delegate void AddToGridDelegate(object ico, object dir_name, object size, object mod, object create);
        public void addToGrid(object ico, object dir_name, object size, object mod, object create)
        {
            filesGrid.Rows.Add(new object[] { ico, dir_name, size, mod, create });
        }
        public delegate void ClearGridDelagate();
        public void clearGrid()
        {
            filesGrid.Rows.Clear();
        }
        #endregion

        #region OtherMethods
        public void DeleteSelectedFiles(DataGridViewSelectedRowCollection obj)
        {
            foreach (DataGridViewRow row in obj)
            {
                if (row.Cells[2].Value.ToString() != "")
                    try
                    {
                        File.Delete(Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString());
                    }
                    catch
                    {
                        notDeletedFiles += Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString() + "?";
                    }
                else
                    try
                    {
                        if (!Directory.EnumerateFileSystemEntries(Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString()).Any())
                            Directory.Delete(Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString());
                        else
                        {
                            DialogResult dr = MessageBox.Show("Ten folder nie jest pusty. Czy chcesz go usunąć wraz z zawartością?", "", MessageBoxButtons.YesNo);
                            if (dr == DialogResult.Yes)
                            {
                                DeleteDirectory(Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString());
                            }
                        }
                    }
                    catch
                    {
                        notDeletedFiles += Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString() + "?";
                    }
            }
            if (notDeletedFiles != "")
                new ErrorForm(notDeletedFiles).ShowDialog();
        }
        public void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                try
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
                catch
                {
                    notDeletedFiles += file + "?";
                }

            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }
        #endregion
    }
}
