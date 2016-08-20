using System;
using System.Windows.Forms;

namespace KTZipPresentation
{
    public partial class ErrorForm : Form
    {
        string err;
        public ErrorForm(string e)
        {
            InitializeComponent();
            err = e;            
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            foreach (string s in err.Split('?'))
                listView1.Items.Add(new ListViewItem(s));
        }
    }
}
