using KTZipPresentation.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KTZipPresentation
{
    public partial class ErrorForm : Form
    {
        List<string> content;
        public ErrorForm(List<string> e, string labelText)
        {
            InitializeComponent();
            content = e;
            label1.Text = labelText;
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            Color BackColor, ForeColor;
            if (Settings.Default.NightMode)
            {
                BackColor = SystemColors.Desktop;
                ForeColor = Color.FromArgb(255, 200, 200, 200);
                panel1.BackColor = BackColor;
                panel1.ForeColor = ForeColor;
                listView1.BackColor = BackColor;
                listView1.ForeColor = ForeColor;
                label1.BackColor = BackColor;
                label1.ForeColor = ForeColor;
            }
            foreach (string s in content)
                listView1.Items.Add(new ListViewItem(s));
        }
    }
}
