using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseTest
{
    /// <summary>
    /// 测试监听数据库表变动的操作
    /// </summary>
    public partial class Form1 : Form
    {
        string conStr = "server=.;database=YBML;uid=sa;pwd=yxz";
        string cmdStr = @"SELECT [public_top]
      ,[public_item]
      ,[public_name]
      ,[spellshort]
      ,[sp_id]
      ,[specification]
      ,[authorizecode]
      ,[frm_name]
      ,[mnu_name]
      ,[unit]
      ,[price]
      ,[limit_high_price]
      ,[ratio_0]
      ,[ratio_1]
      ,[ratio_2]
      ,[ratio_3]
      ,[ratio_4]
      ,[ratio_5]
      ,[ratio_6]
      ,[ratio_7]
      ,[ratio_8]
      ,[ratio_9]
      ,[Bz]
      ,[ProductName]
  FROM[dbo].[V_Ybml]";
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            FormClosing += Form1_FormClosing;      
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlDependency.Stop(conStr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDependency.Start(conStr);
            UpdateData();
        }

        private void UpdateData()
        {
                SqlDataAdapter da = new SqlDataAdapter(cmdStr, conStr);
               
                
                SqlDependency sqlDenpendency = new SqlDependency(da.SelectCommand);
                sqlDenpendency.OnChange += SqlDenpendency_OnChange;

                DataTable dt = new DataTable();
                da.Fill(dt);
                   
                dataGridView1.Invoke(((MethodInvoker)delegate 
                { dataGridView1.DataSource = dt; }));
              
        }

        private void SqlDenpendency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info == SqlNotificationInfo.Insert ||e.Info == SqlNotificationInfo.Update ||e.Info == SqlNotificationInfo.Delete)
            {
               
                UpdateData();
            }
        }
    }
}
