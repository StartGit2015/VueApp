using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// <summary>
    /// 多线程本地Txt日志
    /// </summary>
    public class Log
    {
        private static readonly Thread WriteThread;
        private static readonly Queue<string> MsgQueue;
        private static readonly object FileLock;
        private static readonly string FilePath;

        static Log()
        {
            FileLock = new object();
            FilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log\\";
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            WriteThread = new Thread(WriteMsg);
            WriteThread.IsBackground = true;
            MsgQueue = new Queue<string>();
            WriteThread.Start();
        }

        public static void WriteInfoLog(string msg)
        {
            Monitor.Enter(MsgQueue);
            MsgQueue.Enqueue(string.Format("{0}[{1}]{2}\r\n", " Info", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), msg));
            Monitor.Exit(MsgQueue);
        }
        public static void WriteErrorLog(string msg)
        {
            Monitor.Enter(MsgQueue);
            MsgQueue.Enqueue(string.Format("{0}[{1}]{2}\r\n", "Error", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), msg));
            Monitor.Exit(MsgQueue);
        }
        public static void WriteDebugLog(string msg)
        {
            Monitor.Enter(MsgQueue);
            MsgQueue.Enqueue(string.Format("{0}[{1}]{2}\r\n", "Debug", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), msg));
            Monitor.Exit(MsgQueue);
        }
        private static void WriteMsg()
        {
            while (true)
            {
                if (MsgQueue.Count > 0)
                {
                    Monitor.Enter(MsgQueue);
                    string msg = MsgQueue.Dequeue();
                    Monitor.Exit(MsgQueue);

                    Monitor.Enter(FileLock);

                    string _path = FilePath + msg.Substring(0, 5).Trim() + "\\" + DateTime.Now.ToString("yyyy-MM");

                    if (!Directory.Exists(_path))
                    {
                        Directory.CreateDirectory(_path);
                    }
                    string fileName = _path + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                    msg = msg.Remove(0, 5);
                    var logStreamWriter = new StreamWriter(fileName, true);
                    logStreamWriter.WriteLine(msg);
                    logStreamWriter.Close();
                    logStreamWriter.Dispose();
                    Monitor.Exit(FileLock);
                    if (GetFileSize(fileName) > 1024 * 2)
                    {
                        CopyToBak(fileName);
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(5);
                }

            }
        }


        private static long GetFileSize(string fileName)
        {
            long strRe = 0;
            if (File.Exists(fileName))
            {
                Monitor.Enter(FileLock);
                var myFs = new FileStream(fileName, FileMode.Open);
                strRe = myFs.Length / 1024;
                myFs.Close();
                myFs.Dispose();
                Monitor.Exit(FileLock);
            }
            return strRe;
        }
        private static void CopyToBak(string sFileName)
        {
            int fileCount = 0;
            string sBakName = "";
            Monitor.Enter(FileLock);
            do
            {
                fileCount++;
                sBakName = sFileName + "." + fileCount + ".BAK";
            }
            while (File.Exists(sBakName));

            File.Copy(sFileName, sBakName);
            File.Delete(sFileName);
            Monitor.Exit(FileLock);
        }
    }

}
