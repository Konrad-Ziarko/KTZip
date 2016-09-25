using KTZipPresentation.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KTZipPresentation
{
    public partial class RenameForm : Form
    {
        private string oldName;
        public RenameForm(string filePath, string fileName)
        {
            InitializeComponent();
            textBox1.Text = filePath;
            textBox2.Text = oldName = fileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File.Move(textBox1.Text + oldName, textBox1.Text + textBox2.Text);
                Close();
            }
            catch (IOException)
            {
                MessageBox.Show("Plik o takiej nazwie już istnieje.");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Niepoprawna nazwa.");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Operacje na strumieniach alternatywnych nie są wspierane.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RenameForm_Load(object sender, EventArgs e)
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
                this.BackColor = BackColor;
                this.ForeColor = ForeColor;
            }
        }
    }
}
