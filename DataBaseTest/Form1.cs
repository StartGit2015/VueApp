using DataBaseTest.Model;
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
using Y.Core.Dao;
using Y.Core.Interface;
using Y.Core.WinForm.FormEx;

namespace DataBaseTest
{
    public partial class MainFrm : BaseForm
    {
        private IDao<Content> db;
        private IDao<Content> sqldb;
        public MainFrm()
        {
            InitializeComponent();
        }
        private void btn_Test_Click(object sender, EventArgs e)
        {
            if (cmb_con.Text != "")
            {
                db = new ContentServer();
            }
            else
            {
                db = new ContentServer();
            }
         sqldb = new ContentServer().Dao;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (db==null)
            {
                return;
            }

            var dt = db.QueryList(o=>o.ID >0);
           
            dgv_data.DataSource = dt;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var obj = dgv_data.CurrentRow.DataBoundItem as Content;
            db.BeginTran();
            try
            {
                db.IsWriteLog = true;
                db.Insert(obj);
                db.CommitTran();
            }
            catch (Exception)
            {
                db.RollbackTran();
                throw;
            }
            

            var dt = db.QueryList(o => o.ID > 0);
            dgv_data.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var obj = dgv_data.CurrentRow.DataBoundItem as Content;
            db.BeginTran();
            db.Delete(obj);
            db.CommitTran();

            var dt = db.QueryList(o => o.ID > 0);
            dgv_data.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var list = new List<Content>();

            foreach (DataGridViewRow item in dgv_data.SelectedRows)
            {
                var obj = item.DataBoundItem as Content;
                list.Add(obj);
            }
            try
            {
                db.Insert(list);
                db.CommitTran();
            }
            catch (Exception)
            {
                db.RollbackTran();
                throw;
            }
            var dt = db.QueryList(o => o.ID > 0);
            dgv_data.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var list = new List<Content>();

            foreach (DataGridViewRow item in dgv_data.SelectedRows)
            {
                var obj = item.DataBoundItem as Content;
                list.Add(obj);
            }
            try
            {
                db.Deletes(list);
                db.CommitTran();
            }
            catch (Exception)
            {
                db.RollbackTran();
                throw;
            }
            var dt = db.QueryList(o => o.ID > 0);
            dgv_data.DataSource = dt;
        }
    }
}
