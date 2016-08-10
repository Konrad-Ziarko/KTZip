using KTZipPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTZipPresentation
{
    public partial class NewFileForm : Form
    {
        public string path;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            path = textBox1.Text + "\\" + textBox2.Text;
            if (checkBox1.Checked)
                try
                {
                    if (Directory.Exists(path))
                        throw new IOException();
                    Directory.CreateDirectory(path);
                    Close();
                }
                catch (IOException)
                {
                    MessageBox.Show("Folder o takiej nazwie już istnieje!");
                }
            else
                try
                {
                    FileStream fs = new FileStream(path, FileMode.CreateNew);
                    Close();
                }
                catch (IOException)
                {
                    MessageBox.Show("Plik o takiej nazwie już istnieje!");
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }
    }
}
