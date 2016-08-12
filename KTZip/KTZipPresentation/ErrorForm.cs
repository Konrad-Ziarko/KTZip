﻿using System;
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
