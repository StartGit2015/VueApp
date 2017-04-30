namespace DataBaseTest
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Test = new System.Windows.Forms.Button();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.cmb_con = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(822, 412);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmb_con);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_Test);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 36);
            this.panel1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(388, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 31);
            this.button4.TabIndex = 5;
            this.button4.Text = "批量删除数据";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(212, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 31);
            this.button3.TabIndex = 4;
            this.button3.Text = "批量插入数据";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(318, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "删除数据";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(142, 2);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(64, 31);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "插入数据";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(72, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "读取数据";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Test
            // 
            this.btn_Test.BackColor = System.Drawing.Color.White;
            this.btn_Test.Location = new System.Drawing.Point(3, 3);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(64, 31);
            this.btn_Test.TabIndex = 0;
            this.btn_Test.Text = "连接测试";
            this.btn_Test.UseVisualStyleBackColor = false;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // dgv_data
            // 
            this.dgv_data.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_data.Location = new System.Drawing.Point(0, 36);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowTemplate.Height = 23;
            this.dgv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_data.Size = new System.Drawing.Size(822, 376);
            this.dgv_data.TabIndex = 3;
            // 
            // cmb_con
            // 
            this.cmb_con.FormattingEnabled = true;
            this.cmb_con.Items.AddRange(new object[] {
            "DefaultConnection",
            "AlCon"});
            this.cmb_con.Location = new System.Drawing.Point(503, 8);
            this.cmb_con.Name = "cmb_con";
            this.cmb_con.Size = new System.Drawing.Size(121, 20);
            this.cmb_con.TabIndex = 6;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 412);
            this.Controls.Add(this.dgv_data);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainFrm";
            this.ShowIcon = false;
            this.Text = "数据连接测试";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cmb_con;
    }
}

