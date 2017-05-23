using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Win32;
using Y.Core.WinForm.SKin;
using Y.Core.WinForm.Utility;
using System.Windows.Forms;
using System.ComponentModel;
using Y.Core.ComFunc;

namespace Y.Core.WinForm.FormEx
{
  /// <summary>
  /// 后台任务类
  /// </summary>
  public partial class BaseForm
  {
    public virtual void BckWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      
    }

    public void DoWaitWork(Action work)
    {

      
    }

  }
}
