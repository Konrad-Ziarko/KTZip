using System;
using System.Collections.Generic;
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
            foreach (string s in content)
                listView1.Items.Add(new ListViewItem(s));
        }
    }
}
