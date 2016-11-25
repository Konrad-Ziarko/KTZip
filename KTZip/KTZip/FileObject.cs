using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTZip
{
    public class FileObject
    {
        public string fileName { get; private set; }
        public bool isDirectory { get; private set; }
        public Icon ico { get; private set; }

        public FileObject(string fileName, bool isDirectory, Icon ico)
        {
            this.fileName = fileName;
            this.isDirectory = isDirectory;
            this.ico = ico;
        }
    }
}
