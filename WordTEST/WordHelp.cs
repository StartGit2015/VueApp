using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using NPOI.XWPF.UserModel;

namespace WordTEST
{
    public class WordHelp:IDisposable
    {
        string _wordfile = @"C:\Users\Administrator\Desktop\BB疗保险DRGs支付制度改革方案测算数据的通知.docx";

        XWPFDocument doc;
        List<XWPFTable> tableList = null;
        object missing = Missing.Value;
        object path = null;


        public WordHelp(string file)
        {
            if (!File.Exists(file))
            {
                return;
            }
            _wordfile = file;
            
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public List<XWPFTable> init()
        {
            using (FileStream fs = File.OpenRead(_wordfile))
            {
                doc = new NPOI.XWPF.UserModel.XWPFDocument(fs);
                tableList = new List<XWPFTable>();
                path = _wordfile;

                if (doc.Tables?.Count < 1)
                {
                    return tableList;
                }

                foreach (XWPFTable item in doc.Tables)
                {
                    tableList.Add(item);
                }

                return tableList;
            }
            
        }
        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            if (doc != null)
                doc.Close();

        }
    }
}
