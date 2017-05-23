using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Core.ComFunc;
using Y.Core.WinForm.FormEx;

namespace WinformTest
{
  public partial class tabform : BaseForm
  {
    public tabform()
    {
      InitializeComponent();
    }

    private void buttonEx1_Click(object sender, EventArgs e)
    {
      textBoxEx1.Text = "10";
    }

    private void buttonEx3_Click(object sender, EventArgs e)
    {
      var text = textBoxEx1.Text;
      LogFunc.WriteLog("textBoxEx1:" +text);
    }
  }
}
