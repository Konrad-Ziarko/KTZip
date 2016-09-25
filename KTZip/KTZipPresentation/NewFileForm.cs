using KTZipPresentation.Properties;
using KTZipPresentation.View;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KTZipPresentation
{
    public partial class NewFileForm : Form
    {
        public string path;
        private bool isAdsSet = false;
        private bool isTextSet = false;
        public MainWindow parent;
        Color backColor, foreColor;
        public NewFileForm(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            AcceptButton = button1;
            CancelButton = button2;
        }
        private void NewFile_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings.Default.CurrentPath;
            ActiveControl = textBox1;
            textBox2.Text = "Nazwa pliku";
            textBox3.Text = "ADS";

            if (Settings.Default.NightMode)
            {
                backColor = SystemColors.Desktop;
                foreColor = Color.FromArgb(255, 200, 200, 200);
                foreach (System.Windows.Forms.Control item in this.Controls)
                {
                    item.BackColor = backColor;
                    item.ForeColor = foreColor;
                }
                BackColor = backColor;
                ForeColor = foreColor;
            }
            else
            {
                foreColor = Color.Black;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            path = textBox1.Text + "\\" + textBox2.Text;
            if (checkBox1.Checked && (!isAdsSet || (isAdsSet && textBox3.Text == "")))
                try
                {
                    if (Directory.Exists(path))
                        throw new IOException();
                    Directory.CreateDirectory(path);
                }
                catch (IOException)
                {
                    MessageBox.Show("Folder o takiej nazwie już istnieje!");
                }
            else if (!isAdsSet || (isAdsSet && textBox3.Text == ""))
                try
                {
                    FileStream fs = new FileStream(path, FileMode.CreateNew);
                    fs.Close();
                }
                catch (IOException)
                {
                    MessageBox.Show("Plik o takiej nazwie już istnieje!");
                }
            else if (isAdsSet && textBox3.Text != "")
            {
                
                if (checkBox1.Checked && !Directory.Exists(path) && !File.Exists(path))
                    Directory.CreateDirectory(path);
                var stream = CreateFile(
                    path + ":" + textBox3.Text,
                    GENERIC_WRITE,
                    FILE_SHARE_WRITE,
                    IntPtr.Zero,
                    OPEN_ALWAYS,
                    0,
                    IntPtr.Zero);
                if (stream != IntPtr.Zero)
                    CloseHandle(stream);
            }
            parent.RefreshContent();
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (!isTextSet)
            {
                isTextSet = true;
                textBox2.Text = "";
                textBox2.ForeColor = foreColor;
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (!isAdsSet)
            {
                isAdsSet = true;
                textBox3.Text = "";
                textBox3.ForeColor = foreColor;
            }
        }

        #region ADS
        public const int GENERIC_WRITE = 1073741824;
        public const int FILE_SHARE_DELETE = 4;
        public const int FILE_SHARE_WRITE = 2;
        public const int FILE_SHARE_READ = 1;
        public const int OPEN_ALWAYS = 4;
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFile(string lpFileName,
                                                uint dwDesiredAccess,
                                                uint dwShareMode,
                                                IntPtr lpSecurityAttributes,
                                                uint dwCreationDisposition,
                                                uint dwFlagsAndAttributes,
                                                IntPtr hTemplateFile);
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
