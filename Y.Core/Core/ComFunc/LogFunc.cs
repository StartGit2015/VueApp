using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
    private static string DirectoryName = Directory.GetCurrentDirectory();

    private static LogForm logFrm = null;
    /// <summary>
    /// 日志输出
    /// </summary>
    /// <param name="message"></param>
    public static void WriteLog(string message)
    {
      if (ShowLog)
      {
        if (logFrm == null || logFrm.IsDisposed)
        {
          logFrm = new LogForm();
          logFrm.Show();
        }
        logFrm.ShowLog(message);
      }
      else //写本地日志
      {
        var file = DirectoryName + @"\LogFile";

        if (!Directory.Exists(file))
        {
          Directory.CreateDirectory(file);
        }

        file += "\\log" + DateTime.Now.ToString("yyyyMMdd") + @".txt";

        if (!File.Exists(file))
        {
          FileStream fs;
          fs = File.Create(file);
          fs.Close();
        }

        using (FileStream fs = File.OpenWrite(file))
        {
          StreamWriter sw = new StreamWriter(fs);
          sw.BaseStream.Seek(0, SeekOrigin.End);
          sw.Write(DateTime.Now.ToString() + "——> 日志开始：***********************************************************\r\n");
          sw.Write(DateTime.Now.ToString() + " :" + message + "\r\n");
          sw.Write(DateTime.Now.ToString() + "<—— 日志结束：***********************************************************\r\n");
          sw.Flush();
          sw.Close();
        }

      }
    }

  }
}
