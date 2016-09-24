using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTZipPresentation
{
    public partial class PreviewEditForm : Form
    {
        private bool isFileChanged = false;
        private HexBox box;
        public PreviewEditForm()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void PreviewEditForm_Load(object sender, EventArgs e)
        {

        }

        public void addToPanel(System.Windows.Forms.Control control)
        {
            hexPanel.Controls.Add(control);
            box = (HexBox)control;
        }

        private void PreviewEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFileChanged)
            {

            }
        }

        private void PreviewEditForm_SizeChanged(object sender, EventArgs e)
        {
            int width = hexPanel.Width-50;
            int widthLeft = box.RequiredWidth - width;
            float fontSize = box.Font.Size;
            if (widthLeft < 0)
            {
                widthLeft *= -1;
            }
            while (widthLeft > 50)
            {

                if (box.RequiredWidth - width > 5)
                {
                    fontSize -= 0.1f;
                    box.Font = new Font("Segoe", fontSize);
                }
                else if (box.RequiredWidth - width < -5)
                {
                    fontSize += 0.1f;
                    box.Font = new Font("Segoe", fontSize);
                }
                widthLeft = box.RequiredWidth - width;
                if (widthLeft < 0)
                {
                    widthLeft *= -1;
                }
            }
        }
    }
}
