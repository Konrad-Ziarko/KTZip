using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KTZip
{
    public class FileObject
    {
        private FileSystemWatcher watcher;
        public string fileName { get; private set; }
        public long size { get; private set; }
        public DateTime modified { get; private set; }
        public DateTime created { get; private set; }
        public bool isDirectory { get; private set; }
        public ImageSource imgSource
        {
            get
            {
                if(ico!=null)
                    return ico.ToImageSource();
                else
                    return img.ToImageSource();
            }
            private set
            {
                ;
            }
        }
        public Icon ico { get; private set; }
        public Image img { get; private set; }
        public string fileType { get; private set; }
        public string absolutePath { get; private set; }

        public FileObject(string absolutePath, long size, DateTime modified, DateTime created, bool isDirectory, Icon ico)
        {
            this.absolutePath = absolutePath;
            this.fileName = Path.GetFileName(absolutePath);
            this.size = size;
            this.modified = modified;
            this.created = created;
            this.isDirectory = isDirectory;
            this.ico = ico;

            //nie efektywne!!! jeden watcher na obecny katalog starczy
            //watcher = new FileSystemWatcher();
            //watcher.Path = Path.GetDirectoryName(absolutePath);
            //watcher.Filter = Path.GetFileName(absolutePath);
            //watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            //watcher.Changed += Watcher_Changed;
            //watcher.EnableRaisingEvents = true;
        }
        public FileObject(string absolutePath, long size, DateTime modified, DateTime created, bool isDirectory, Image img)
        {
            this.absolutePath = absolutePath;
            this.fileName = Path.GetFileName(absolutePath);
            this.size = size;
            this.modified = modified;
            this.created = created;
            this.isDirectory = isDirectory;
            this.img = img;

            //nie efektywne!!! jeden watcher na obecny katalog starczy
            //watcher = new FileSystemWatcher();
            //watcher.Path = Path.GetDirectoryName(absolutePath);
            //watcher.Filter = Path.GetFileName(absolutePath);
            //watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            //watcher.Changed += Watcher_Changed;
            //watcher.EnableRaisingEvents = true;
        }
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
