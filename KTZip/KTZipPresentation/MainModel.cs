using KTZipPresentation.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Trinet.Core.IO.Ntfs;
using static KTZipPresentation.Control.MainControler;

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
        public void reloadContent(string path, OperationType OpTy)
        {
            bool reload = true;
            if (path == @"\")
                path = @"C:\";
            if (OpTy == OperationType.Reload)
                reload = true;
            else if (Directory.Exists(path))
            {
                try
                {
                    Directory.GetDirectories(path);
                    path = path.Replace(@"\\", @"\");
                    Settings.Default.CurrentPath = path.Replace(@"\\", @"\");
                    if (OpTy == OperationType.LoadNew || OpTy == OperationType.MoveUp)
                    {
                        for (int i = Settings.Default.History.Count - 1; i > Settings.Default.PositionInHistory; i--)
                            Settings.Default.History.RemoveAt(i);
                        Settings.Default.History.Add(path);
                        Settings.Default.PositionInHistory++;
                    }
                }
                catch
                {
                    reload = false;
                }
            }
            else if (OpTy == OperationType.LoadPrev)
            {
                if (Settings.Default.PositionInHistory > 0)
                    Settings.Default.CurrentPath = Settings.Default.History[--Settings.Default.PositionInHistory];
                else
                    reload = false;
            }
            else if (OpTy == OperationType.LoadNext)
            {
                if (Settings.Default.PositionInHistory < Settings.Default.History.Count - 1)
                    Settings.Default.CurrentPath = Settings.Default.History[++Settings.Default.PositionInHistory];
                else
                    reload = false;
            }
            else if (OpTy == OperationType.FirstLoad)
            {
                Settings.Default.History.Add(Settings.Default.CurrentPath);
            }
            else if (OpTy == OperationType.NoReload)
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
                FileInfo fileInfo = new FileInfo(file);
                string modif, create;
                if (fileInfo.LastWriteTime.Date == DateTime.Today)
                    modif = fileInfo.LastWriteTime.ToString("HH:mm:ss");
                else
                    modif = fileInfo.LastWriteTime.Date.ToString("dd-MM-yyyy");
                if (fileInfo.CreationTime.Date == DateTime.Today)
                    create = fileInfo.CreationTime.ToString("HH:mm:ss");
                else
                    create = fileInfo.CreationTime.Date.ToString("dd-MM-yyyy");
                Image img = new Bitmap(Icon.ExtractAssociatedIcon(file).ToBitmap(), new Size(20, 20));
                if ((fileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    img = ChangeOpacity(img);
                filesGrid.Rows.Add(img, fileName, string.Format("{0:n0}", fileInfo.Length), modif, create, "F");
                img = new Bitmap(Resources.stream, new Size(20, 20));

                foreach (AlternateDataStreamInfo stream in fileInfo.ListAlternateDataStreams())
                {
                    filesGrid.Rows.Add(img, fileName + ":" + stream.Name, stream.Size, "", "", "A");
                }
            }
        }
        private void reloadDirs()
        {
            ClearGridDelagate d1 = new ClearGridDelagate(clearGrid);
            filesGrid.Invoke(d1);
            if (!Directory.Exists(Settings.Default.CurrentPath))
                Settings.Default.CurrentPath = @"C:\";
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
                filesGrid.Rows.Add(img, dirName, "", modif, create, "D");
                img = new Bitmap(Resources.stream, new Size(20, 20));
                foreach (AlternateDataStreamInfo stream in di.ListAlternateDataStreams())
                {
                    filesGrid.Rows.Add(img, dirName + ":" + stream.Name, stream.Size, "", "", "A");
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
        public string DeleteSelectedFiles(DataGridViewSelectedRowCollection obj)
        {
            string toDelete = "Czy chcesz usunąć następujące pliki:";
            notDeletedFiles = "";
            if (obj.Count < 20)
            {
                toDelete += "\n";
                foreach (DataGridViewRow row in obj)
                {
                    toDelete += row.Cells[1].Value.ToString();
                    if (row.Cells[2].Value.ToString() == "")
                    {
                        DirectoryInfo di = new DirectoryInfo(Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString());
                        toDelete += "(Folderów: " + di.GetDirectories().Length + ",  Plików: " + di.GetFiles().Length + ")";
                    }
                    toDelete += "\n";
                }
            }
            else
            {
                toDelete += "(" + obj.Count + ")";
            }
            DialogResult doDeleteFiles = MessageBox.Show(toDelete, "Uwaga!", MessageBoxButtons.YesNo);
            if (doDeleteFiles == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in obj)
                {
                    if (row.Cells[3].Value.ToString() == "" && row.Cells[4].Value.ToString() == "")
                    {
                        string[] split = row.Cells[1].Value.ToString().Split(':');
                        FileInfo fi = new FileInfo(Settings.Default.CurrentPath + "\\" + split[0]);
                        fi.DeleteAlternateDataStream(split[1]);
                        DirectoryInfo di = new DirectoryInfo(Settings.Default.CurrentPath + "\\" + split[0]);
                        di.DeleteAlternateDataStream(split[1]);
                    }
                    else if (row.Cells[2].Value.ToString() != "")
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
                            DeleteDirectory(Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString());
                        }
                        catch
                        {
                            notDeletedFiles += Settings.Default.CurrentPath + "\\" + row.Cells[1].Value.ToString() + "?";
                        }
                }
            }
            return notDeletedFiles;
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
