using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {

        }
    }
}
