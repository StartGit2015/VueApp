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
      textBoxEx1.TipText = "okok1!";
      textBoxEx2.TipText = "okok2!";

      LogFunc.WriteLog("ok");
    }

    private void buttonEx1_Click(object sender, EventArgs e)
    {
      LogFunc.WriteLog("ok");
    }
  }
}
