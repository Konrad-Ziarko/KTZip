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
                MessageBox.Show("Nie możesz nazwać pliku jak strumień alternatywny.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
