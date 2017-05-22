using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Core.Interface;
using Y.Core.WinForm.FormEx;

namespace Y.Core.ComFunc
{
  /// <summary>
  /// 日志输出类
  /// </summary>
  public class LogFunc
  {
    /// <summary>
    /// 是否时时展示日志 true 是
    /// </summary>
    private static bool ShowLog = ConfigurationManager.AppSettings["ShowLog"].ToString()=="true";

    private static LogForm logFrm = null;
    public static void WriteLog(string message)
    {
      if(logFrm == null)
      {
        logFrm = new LogForm();
        logFrm.Show();
      }
      logFrm.ShowLog(message);
    }

  }
}
