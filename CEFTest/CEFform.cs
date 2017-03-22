using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using System.IO;

namespace CEFTest
{
    public partial class CEFform : Form
    {
        ChromiumWebBrowser webBrower = null;
        
        string path = "";
        public CEFform()
        {
            InitializeComponent();
            
            Load += CEFform_Load;
        }

        private void CEFform_Load(object sender, EventArgs e)
        {
            webBrower = new ChromiumWebBrowser(path);
            webBrower.Dock = DockStyle.Fill;
            pl_Contant.Controls.Add(webBrower);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            path = textBox1.Text;
            webBrower.Load(path);
        }
    }
}
