using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Y.Core;

namespace WebTest
{
    /// <summary>
    /// IOC注入管理
    /// </summary>
    public class IOCManager
    {
        public static void IOCInit()
        {
            IOCBase.IOCBaseIni();
        }
    }
}