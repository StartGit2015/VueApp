using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEFTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += Resolver;
            IniCef();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CEFform());
        }

        private static void IniCef()
        {
            var setting = new CefSettings();
            setting.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, Environment.Is64BitProcess ? "x64" : "x86","CefSharp.BrowserSubprocess.exe");
            Cef.Initialize(setting, performDependencyCheck: false, browserProcessHandler: null);
        }

        private static Assembly Resolver(object sender,ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath= Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, Environment.Is64BitProcess ? "x64" : "x86",assemblyName);
                return File.Exists(archSpecificPath) ? Assembly.LoadFile(archSpecificPath) : null;
            }
            return null;
        }
    }
}
