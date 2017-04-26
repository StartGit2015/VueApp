using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WordTEST
{
    class Program
    {
        static void Main(string[] args)
        {

            var tabLsit = new WordHelp(@"C:\Users\Administrator\Desktop\BB疗保险DRGs支付制度改革方案测算数据的通知.docx").init();
            StringBuilder sb = new StringBuilder();
            StringBuilder selectSb = new StringBuilder();
            int id = 0;
            foreach (XWPFTable tb in tabLsit)
            {
                StringBuilder tbSb = new StringBuilder();
                StringBuilder tbComment = new StringBuilder();
                tbSb.Append(string.Format(" create table table{0}(",id));

                selectSb.Append("select ");

                var rows = tb.Rows;
                if (rows.Count <2)
                {
                    continue;
                }
                foreach (var row in rows)
                {
                    if (row.GetTableCells().Count < 5)
                    {
                        continue;
                    }
                    var cols = row.GetTableCells();
                    var colName = cols[0].GetText();
                    var colType = cols[2].GetText();
                    var comment = cols[1].GetText() + "例子：" + cols[3].GetText();//注释

                    selectSb.Append(colName + " AS " +cols[1].GetText() + ",");
                    switch (colType.ToLower())
                    {
                        case "int":
                            colType = "int";
                            break;
                        case "datetime":
                            colType = "datetime";
                            break;
                        case "true|false":
                            colType = "bit";
                            break;
                        case "float":
                            colType = "float";
                            break;
                        default:
                            colType = "nvarchar(50)";
                            break;
                    }
                    tbSb.Append(colName + " " + colType +",");
                    tbComment.Append(string.Format(@" EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'{0}',
@level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'table{1}', @level2type = N'COLUMN', @level2name = N'{2}'", comment,id, colName));
                }

                tbSb.Append(")");
                selectSb.AppendFormat(" FROM table{0} ", id);

                var tabSql = tbSb.ToString();
                sb.Append(tabSql.Substring(0, tabSql.LastIndexOf(",")) +")");
                sb.Append(tbComment.ToString());
                id++;
            }
            using (FileStream fs = new FileStream(@"d:\sql.txt", FileMode.OpenOrCreate))
            {
                var data = Encoding.Default.GetBytes(sb.ToString());
                fs.Write(data, 0,data.Length);
                fs.Flush();
                fs.Close();
            }

            using (FileStream fs = new FileStream(@"d:\sqlSELECT.txt", FileMode.OpenOrCreate))
            {
                var data = Encoding.Default.GetBytes(selectSb.ToString());
                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
            }
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }

        
    }
}
