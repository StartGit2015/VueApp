using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using System.Data;
using System.Collections;
using Microsoft.SqlServer.Server;
using Y.Core.Enum;
using Y.Core.ComFunc;

namespace Y.Core.WinForm.Controls
{
    /// <summary>
    /// 系统级Button
    /// </summary>
    public class TextBoxEx: TextBox
    {
        public TextBoxEx() : base()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.Opaque | ControlStyles.DoubleBuffer, true);

            this.BackColor = Color.Transparent;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            //DrawUndLine();
            //DrawRBpicture();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawUndLine();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.Style &= ~0x02000000;
                return paras;
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Text = GetTextByValueID(this.Text);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.X > (this.Location.X + this.Width - this.Height)) { this.Cursor = Cursors.Hand; }
        }

        private Color undLineColor = Color.Blue;
        [Category("YXZ")]
        [DefaultValue(typeof(Color), "Blue")]
        [Description("下划线颜色")]
        public Color UndLineColor
        {
            get { return this.undLineColor; }
            set
            {
                undLineColor = value;
                OnCreateControl();
                base.Invalidate();
            }
        }

        private bool hasUndLine = false;
        [Category("YXZ")]
        [DefaultValue(false)]
        [Description("是否有下划线")]
        public bool HasUndLine
        {
            get { return this.hasUndLine; }
            set
            {
                this.BorderStyle = BorderStyle.None;
                hasUndLine = value;
                base.Invalidate();

            }
        }
        private string textvalue = "";
        [Category("YXZ")]
        [DefaultValue(false)]
        [Description("获取ID value值")]
        public string TextValue
        {
            get { return textvalue.Length > 0 ? textvalue : Text; }
            set
            {
                textvalue = value;
                base.Invalidate();

            }
        }
        private List<ItemList> dataSource;
        [Category("YXZ")]
        [Bindable(true)]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue((string)null)]
        [Description("是否有数据源")]
        public List<ItemList> DataSource
        {
            get { return this.dataSource; }
            set
            {
                if (value != null)
                {
                    dataSource = value;
                }
            }
        }

        private string rButtonIcon = "";
        [Category("YXZ")]
        [Description("可以设置右边的图片")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(PropertyEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        public string RButtonIcon
        {
            get
            {
                return rButtonIcon;
            }

            set
            {
                rButtonIcon = value.Replace("_", "-");
                Invalidate();
            }
        }
        /// <summary>
        /// 重绘的Msg
        /// </summary>
        private const int WM_PAINT = 0xF;
        /// <summary>
        /// 截获重绘信息 进行绘制
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                DrawUndLine();
            }
        }
        /// <summary>
        /// 绘制下划线
        /// </summary>
        private void DrawUndLine()
        {
            Graphics g = this.CreateGraphics();

            if (Focused && !ReadOnly && Enabled)
            {
                //RoundRectangle rec = new RoundRectangle(new Rectangle(0, 0, ClientRectangle.Width - 17, ClientRectangle.Height), 0);
                //GDIHelper.DrawPathOuterBorder(g, rec, Color.DeepSkyBlue);
                //ControlPaint.DrawBorder(g, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height), Color.DeepSkyBlue, ButtonBorderStyle.Solid);
                //g.DrawLine(g, new Pen(Color.DeepSkyBlue, 2.5f), new Point(0, this.Height), new Point(this.Width, this.Height));
            }
            else
            {
                //RoundRectangle rec = new RoundRectangle(new Rectangle(0, 0, ClientRectangle.Width - 17, ClientRectangle.Height), 0);
                //GDIHelper.DrawPathOuterBorder(g, rec, BackColor);
                ControlPaint.DrawBorder(g, new Rectangle(0, 0, ClientRectangle.Width - 17, ClientRectangle.Height), BackColor, ButtonBorderStyle.None);
            }
            if (hasUndLine)
            {

                //GDIHelper.DrawLine(g, new Pen(this.undLineColor, 2.5f), new Point(0, this.Height), new Point(this.Width, this.Height));
            }
            g.Dispose();
        }

        private string GetTextByValueID(string text)
        {
            if (dataSource != null)
            {
                var valueName = dataSource.Exists(m => m.Value == text) ? dataSource.Find(m => m.Value == text).Text : text;
                textvalue = text;
                if (valueName.Length < 1) { valueName = text; }
                return valueName;
            }
            return text;
        }
        /// <summary>
        /// 数据源类
        /// </summary>
        public class ItemList
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }

        // <summary>
        /// 图片选择编辑器
        /// </summary>
        public class PropertyEditor : UITypeEditor
        {

            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                //指定为模式窗体属性编辑器类型 
                return UITypeEditorEditStyle.Modal;
            }

            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                return FrmSelectPic.EditValue(value);
            }



            public class FrmSelectPic : Form
            {
                public static PictureBox SelectPic;
                public static object EditValue(object value)
                {
                    FrmSelectPic editForm = new FrmSelectPic();
                    editForm.ShowIcon = false;
                    editForm.ShowInTaskbar = false;
                    editForm.MinimizeBox = false;
                    editForm.MaximizeBox = false;
                    editForm.ControlBox = true;
                    var formPoint = new Point();
                    formPoint.X = MousePosition.X - editForm.Width - 10;
                    formPoint.Y = (Screen.PrimaryScreen.WorkingArea.Height - MousePosition.Y) - editForm.Height > 0 ? MousePosition.Y : MousePosition.Y - editForm.Height;
                    editForm.Location = formPoint;
                    editForm.StartPosition = FormStartPosition.Manual;
                    List<PictureBox> picList = new List<PictureBox>();
                    var panl = new FlowLayoutPanel();
                    panl.FlowDirection = FlowDirection.TopDown;
                    panl.AutoScroll = true;
                    panl.Dock = DockStyle.Fill;
                    foreach (FaEnum item in  System.Enum.GetValues(typeof(FaEnum)))
                    {
                        PictureBox picB = new PictureBox();
                        picB.Height = 35;
                        picB.Width = 35;
                        picB.Image = FontAwesome.GetImage(item);
                        picB.Name = item.ToString();
                        picList.Add(picB);
                        picB.Click += delegate (object sender, EventArgs e)
                        {
                            SelectPic = (PictureBox)sender;
                            editForm.Text = SelectPic.Name;
                        };
                        picB.DoubleClick += delegate (object sender, EventArgs e)
                        {
                            SelectPic = (PictureBox)sender;
                            editForm.Text = SelectPic.Name;
                            editForm.Close();
                        };
                    }
                    panl.Controls.AddRange(picList.ToArray());
                    editForm.Controls.Add(panl);
                    editForm.ShowDialog();
                    return editForm.GetValue();
                }

                public string GetValue()
                {
                    return SelectPic.Name;
                }
            }
        }
    }
}
