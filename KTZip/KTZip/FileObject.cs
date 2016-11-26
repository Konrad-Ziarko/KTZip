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
        public string fileName { get; private set; }
        public long size { get; private set; }
        public DateTime modified { get; private set; }
        public bool isDirectory { get; private set; }
        public ImageSource imgSource
        {
            get
            {
                return ico.ToImageSource();
            }
            private set
            {
                ;
            }
        }
        public Icon ico { get; private set; }
        public string fileType { get; private set; }
        public string absolutePath { get; private set; }

        public FileObject(string fileName, long size, DateTime modified, bool isDirectory, Icon ico)
        {
            this.fileName = fileName;
            this.size = size;
            this.modified = modified;
            this.isDirectory = isDirectory;
            this.ico = ico;
        }
    }
}
