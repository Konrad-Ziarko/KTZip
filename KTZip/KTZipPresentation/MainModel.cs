using KTZipPresentation.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTZipPresentation.Model
{
    public class MainModel
    {
        public DataGridView filesGrid { get; set; }
        public void SetDataGrid (ref DataGridView dgv)
        {
            filesGrid = dgv;
        }

        public MainModel()
        {

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
            if (reload || isForward == int.MaxValue)
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
                AddToGridDelegate d = new AddToGridDelegate(addToGrid);
                filesGrid.Invoke(d, Icon.ExtractAssociatedIcon(file), fileName, string.Format("{0:n0}", fi.Length), modif, create);
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
                string modif, create;
                if (fi.LastWriteTime.Date == DateTime.Today)
                    modif = fi.LastWriteTime.ToString("HH:mm:ss");
                else
                    modif = fi.LastWriteTime.Date.ToString("dd-MM-yyyy");
                if (fi.CreationTime.Date == DateTime.Today)
                    create = fi.CreationTime.ToString("HH:mm:ss");
                else
                    create = fi.CreationTime.Date.ToString("dd-MM-yyyy");
                AddToGridDelegate d2 = new AddToGridDelegate(addToGrid);
                filesGrid.Invoke(d2, Resources.folder1, dirName, "", modif, create);
            }
        }
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
    }
}
