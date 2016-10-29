using Be.Windows.Forms;
using KTZipPresentation.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Trinet.Core.IO.Ntfs;

namespace KTZipPresentation
{
    public partial class PreviewEditForm : Form
    {
        private HexBox box;
        private string attributes;
        private string path;
        DynamicFileByteProvider provider = null;
        public PreviewEditForm(string path, string attributes)
        {
            InitializeComponent();
            this.path = path;
            this.attributes = attributes;
        }

        private void PreviewEditForm_Load(object sender, EventArgs e)
        {
            if (attributes == "F")
            {
                provider = new DynamicFileByteProvider(path);
            }
            else
            {
                string[] adsFilePathParts = path.Split(':');
                string newPath = string.Empty;
                for (int i = 0; i < adsFilePathParts.Length - 1; i++)
                {
                    newPath += adsFilePathParts[i] + ':';
                }
                newPath = newPath.Remove(newPath.Length - 1);
                FileInfo fileInfo = new FileInfo(newPath);
                FileStream fs = fileInfo.GetAlternateDataStream(adsFilePathParts[adsFilePathParts.Length - 1], FileMode.Open).OpenRead();
                //
                //ads'y nie otwieraja sie do edycji - tylko odczyt
                //
                provider = new DynamicFileByteProvider(fs);
            }
            var hexBox = new HexBox { ByteProvider = provider };
            hexBox.Dock = DockStyle.Fill;
            hexBox.VScrollBarVisible = true;
            hexBox.StringViewVisible = true;
            hexBox.ShadowSelectionVisible = true;
            hexBox.LineInfoVisible = true;
            hexBox.ColumnInfoVisible = true;
            hexBox.UseFixedBytesPerLine = true;
            hexBox.Font = new Font("Segoe", 11);
            hexBox.Visible = true;
            hexBox.KeyDown += HexBox_KeyDown;
            hexPanel.Controls.Add(hexBox);
            this.Width = hexBox.RequiredWidth + 50;
            box = hexBox;
            setFormColor();
        }

        private void HexBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                    provider.ApplyChanges();
            }
        }

        private void setFormColor()
        {
            Color BackColor, ForeColor;
            if (Settings.Default.NightMode)
            {
                BackColor = SystemColors.Desktop;
                ForeColor = Color.FromArgb(255, 200, 200, 200);
                foreach (System.Windows.Forms.Control item in this.Controls)
                {
                    item.BackColor = BackColor;
                    item.ForeColor = ForeColor;
                }
                box.BackColor = BackColor;
                box.ForeColor = ForeColor;
            }
        }

        private void PreviewEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (provider.HasChanges())
            {
                DialogResult dr = MessageBox.Show("Czy chcesz zapisać zmiany w pliku?", "Zamykanie pliku", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                    e.Cancel = true;
                else if (dr == DialogResult.OK)
                {
                    provider.ApplyChanges();
                    provider.Dispose();
                }
            }
            else
                provider.Dispose();
        }

        private void PreviewEditForm_SizeChanged(object sender, EventArgs e)
        {
            if (box != null)
            {
                int width = hexPanel.Width - 40;
                int widthLeft = box.RequiredWidth - width;
                float fontSize = box.Font.Size;
                if (widthLeft < 0)
                {
                    widthLeft *= -1;
                }
                int i = 0;
                while (widthLeft > 50 && i < 1000)
                {
                    i++;
                    if (box.RequiredWidth > width)
                    {
                        fontSize -= 0.1f;
                        box.Font = new Font("Segoe", fontSize);
                    }
                    else if (box.RequiredWidth < width)
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
}
