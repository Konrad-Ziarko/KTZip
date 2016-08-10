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
        public MainModel()
        {

        }
        public void reloadContent(string obj, int isForward)
        {
            if (Directory.Exists(obj))
            {
                Settings.Default.CurrentPath = obj;
                Settings.Default.CurrentPath = Settings.Default.CurrentPath.Replace(@"\\", @"\");
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
            else if (obj == "" && isForward == -1 && Settings.Default.PositionInHistory > 0)
            {
                Settings.Default.CurrentPath = Settings.Default.History[--Settings.Default.PositionInHistory];
            }
            else if (obj == "" && isForward == 2 && Settings.Default.PositionInHistory < Settings.Default.History.Count - 1)
            {
                Settings.Default.CurrentPath = Settings.Default.History[++Settings.Default.PositionInHistory];
            }
            else if (obj == "" && isForward == 0)
            {
                Settings.Default.History.Add(Settings.Default.CurrentPath = @"C:\");
            }
            reloadDirs();
            reloadFiles();
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
                filesGrid.Rows.Add(new object[] { Icon.ExtractAssociatedIcon(file), fileName, string.Format("{0:n0}", fi.Length), modif, create });
            }
        }
        private void reloadDirs()
        {
            filesGrid.Rows.Clear();
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
    }
}
