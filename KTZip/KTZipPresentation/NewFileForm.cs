using KTZipPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTZipPresentation
{
    public partial class NewFileForm : Form
    {
        public string path;
        private bool isAdsSet = false;
        private bool isTextSet = false;
        private Form parent;
        public NewFileForm()
        {
            InitializeComponent();
        }
        private void NewFile_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings.Default.CurrentPath;
            ActiveControl = textBox1;
            textBox2.Text = "Nazwa pliku";
            textBox2.ForeColor = Color.LightGray;
            textBox3.Text = "ADS";
            textBox3.ForeColor = Color.LightGray;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            path = textBox1.Text + "\\" + textBox2.Text;
            if (checkBox1.Checked && (!isAdsSet || (isAdsSet && textBox3.Text=="")))
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
            else if (!checkBox1.Checked && isAdsSet && textBox3.Text != "")
            {
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
            else if (checkBox1.Checked && isAdsSet && textBox3.Text != "")
            {
                if (!Directory.Exists(path))
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
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (!isTextSet)
            {
                isTextSet = true;
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (!isAdsSet)
            {
                isAdsSet = true;
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        #region ADS
        public const int GENERIC_WRITE = 1073741824;
        public const int FILE_SHARE_DELETE = 4;
        public const int FILE_SHARE_WRITE = 2;
        public const int FILE_SHARE_READ = 1;
        public const int OPEN_ALWAYS = 4;
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFile( string lpFileName,
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
