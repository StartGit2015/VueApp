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
    private static LoadForm loadingFrm = null;
    /// <summary>
    /// 执行一个无参数无返回值的同步方法
    /// </summary>
    /// <param name="work"></param>
    public void DoWork(Action work)
    {
      ShowLoading();
      var task = new Task(work);
      LogFunc.WriteLog("new Task(work)");
      task.Start();
      LogFunc.WriteLog("task.Start();");
      //ShowLoading(false);
    }

    /// <summary>
    /// 显示Loading界面
    /// </summary>
    /// <param name="showOrHid"></param>
    public void ShowLoading(bool showOrHid = true)
    {
      if(loadingFrm == null || loadingFrm.IsDisposed)
      {
        LogFunc.WriteLog("loadingFrm == null");
        loadingFrm = new LoadForm();
        loadingFrm.TopMost = true;
        //loadingFrm.Parent = this;
        loadingFrm.Size = this.Size;
        loadingFrm.Location = this.Location;
      }

      if (showOrHid)
      {
        loadingFrm.Show();
        LogFunc.WriteLog("loadingFrm == Show");
      } else
      {
        loadingFrm.Hide();
        LogFunc.WriteLog("loadingFrm == Hide");
      }
    }
  }
}
