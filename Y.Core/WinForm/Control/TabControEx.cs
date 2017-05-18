using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace CFW.WinFormBase.Controls.YContorls
{
    public partial class TabControlEx : TabControl
    {

        #region 属性字段
        /// <summary>
        /// 特殊字符集合，不能被关闭
        /// </summary>
        private string _special = "";

        string[] _arraySpecial;
        /// <summary>
        /// 是否绘制关闭窗口按钮
        /// </summary>
        private bool _bclosebtn = false;

        /// <summary>
        /// 关闭按钮的颜色
        /// </summary>
        private Color _closeColor = Color.Red;
        

        [Category("设计(自定义)")]
        [Description("特殊内容集合（该内容的TabPage不会被删除），如果有多个，请以分号【;】分割")]
        public string SpecialString
        {
            get { return _special; }
            set
            {
                _special = value;
                _arraySpecial = value.Split(new char[] { ';' });
                base.Invalidate(true);
            }
        }

        [Category("设计(自定义)")]
        [Description("是否绘制关闭按钮")]
        public bool CloseButton
        {
            get { return _bclosebtn; }
            set
            {
                _bclosebtn = value;
                base.Invalidate(true);
            }
        }

        private Color _backColor = SystemColors.Control;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                base.Invalidate(true);
            }
        }

        private Color _borderColor = Color.Silver;
        [DefaultValue(typeof(Color), "23, 169, 254")]
        [Description("TabContorl边框色")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                base.Invalidate(true);
            }
        }

        private Color _headSelectedBackColor = Color.White;
        [Description("TabPage头部选中后的背景颜色")]
        public Color HeadSelectedBackColor
        {
            get { return _headSelectedBackColor; }
            set { _headSelectedBackColor = value; base.Invalidate(true); }
        }

        private Color _headSelectedBorderColor = Color.Silver;
        [Description("TabPage头部选中后的边框颜色")]
        public Color HeadSelectedBorderColor
        {
            get { return _headSelectedBorderColor; }
            set { _headSelectedBorderColor = value; base.Invalidate(true); }
        }

        private Color _headerBackColor = Color.Gray;
        [Description("TabPage头部默认边框颜色")]
        public Color HeaderBackColor
        {
            get { return _headerBackColor; }
            set { _headerBackColor = value;
                base.Invalidate(true);
            }
        }
        #endregion

        #region 新增一个绑定窗口TabPage
        /// <summary>
        /// 新增一个绑定窗口TabPage
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="tabName"></param>
        public void AddTabPage(Form frm, string tabName)
        {
            if (frm == null)//窗口没有初始化返回
            {
                return;
            }

            for (int i = 0; i < this.TabCount; i++)
            {
                if (TabPages[i].Text == tabName)
                {
                    this.SelectedIndex = i;
                    return;
                }
            }

            this.Cursor = Cursors.WaitCursor;
            //Form myForm;
            //新建并打开属性页
            TabPages.Add(tabName);
            SelectTab(TabPages.Count - 1);
            this.SelectedTab.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            frm.Show();
            frm.Parent = this.SelectedTab;
            this.Cursor = Cursors.Default;
        }
        #endregion

        public TabControlEx(): base()
        {
            base.SetStyle(
                  ControlStyles.UserPaint |                      // 控件将自行绘制，而不是通过操作系统来绘制  
                  ControlStyles.OptimizedDoubleBuffer |          // 该控件首先在缓冲区中绘制，而不是直接绘制到屏幕上，这样可以减少闪烁  
                  ControlStyles.AllPaintingInWmPaint |           // 控件将忽略 WM_ERASEBKGND 窗口消息以减少闪烁  
                  ControlStyles.ResizeRedraw |                   // 在调整控件大小时重绘控件  
                  ControlStyles.SupportsTransparentBackColor,    // 控件接受 alpha 组件小于 255 的 BackColor 以模拟透明  
                  true);
            this.DrawMode =  TabDrawMode.OwnerDrawFixed;
            base.UpdateStyles();

            this.ItemSize = new Size(44, 35);
        }

        /// <summary>
        /// 设置边框间距为0
        /// </summary>
        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                return new Rectangle(rect.Left - 4, rect.Top - 4, rect.Width + 8, rect.Height + 8);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!DesignMode)
            {
                if (_bclosebtn)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        int x = e.X;
                        int y = e.Y;

                        Rectangle tabRect = GetTabRect(this.SelectedIndex);
                        tabRect.Offset(tabRect.Width - 7 * tabRect.Height / 8, tabRect.Height / 8);
                        tabRect.Width = tabRect.Height * 3 / 4;
                        tabRect.Height = tabRect.Height * 3 / 4;
                        if ((((x >= tabRect.X) && (x <= tabRect.Right)) && (y >= tabRect.Y)) && (y <= tabRect.Bottom))
                        {
                            int iSelect = this.SelectedIndex;
                            if (_arraySpecial != null)//如果为特殊字符中内容不允许关闭
                            {
                                for (int i = 0; i < _arraySpecial.Length; i++)
                                {
                                    if (TabPages[iSelect].Text.IndexOf(_arraySpecial[i]) != -1)
                                    {
                                        return;
                                    }
                                }
                            }
                            foreach (var ctr in SelectedTab.Controls)
                            {
                                if (ctr is Form)
                                {
                                    (ctr as Form).Close();
                                    (ctr as Form).Dispose();
                                    break;
                                }
                            }
                            this.TabPages.Remove(this.SelectedTab);
                            try
                            {
                                if (this.TabCount > 0)
                                {
                                    if (iSelect >= this.TabCount)
                                    {
                                        this.SelectedIndex = iSelect - 1;
                                    }
                                    else
                                    {
                                        this.SelectedIndex = iSelect;
                                    }
                                }
                            }
                            catch
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    //base.OnPaint(e);
        //    Rectangle tabRect;
        //    Point cusorPoint = PointToClient(MousePosition);
        //    bool hover;
        //    bool selected;
        //    Color backGroundColor = Color.BurlyWood;
        //    for (int index = 0; index < base.TabCount; index++)
        //    {
        //        TabPage page = TabPages[index];
        //        tabRect = GetTabRect(index);
        //        hover = tabRect.Contains(cusorPoint);
        //        selected = SelectedIndex == index;
        //        e.Graphics.DrawRectangle(Pens.Red, tabRect);
        //        using (Brush b = new SolidBrush(backGroundColor))
        //        {
        //            e.Graphics.FillRectangle(b, tabRect);
        //        }

        //        //绘制标签头
        //        Rectangle bounds = tabRect;
        //        PointF textPoint = new PointF();
        //        SizeF textSize = TextRenderer.MeasureText(this.TabPages[index].Text, this.Font);
        //        // 加上每个标签的左偏移量X  
        //        textPoint.X
        //            = bounds.X + (bounds.Width - textSize.Width) / 2;
        //        textPoint.Y
        //            = bounds.Bottom - textSize.Height - this.Padding.Y;

        //        // Draw highlights  
        //        e.Graphics.DrawString(
        //            this.TabPages[index].Text,
        //            this.Font,
        //            SystemBrushes.ControlLightLight,    // 高光颜色  
        //            textPoint.X,
        //            textPoint.Y);

        //        // 绘制正常文字  
        //        textPoint.Y--;
        //        e.Graphics.DrawString(
        //            this.TabPages[index].Text,
        //            this.Font,
        //            SystemBrushes.ControlText,    // 正常颜色  
        //            textPoint.X,
        //            textPoint.Y);
        //        //绘制图片


        //        Pen borderPen = new Pen(SystemColors.ControlDark);// TabPage 非选中时候的 TabPage 头部边框色
        //        if (index == this.SelectedIndex)
        //        {
        //            //borderPen = new Pen(ThemedColors.ToolBorder);
        //            borderPen = new Pen(Color.Gray); // TabPage 选中后的 TabPage 头部边框色
        //        }

        //        borderPen.Dispose();

        //        if (SelectedIndex == index)
        //        {
        //            using (Brush b = new SolidBrush(Color.White))
        //            {
        //                e.Graphics.FillRectangle(b, tabRect);
        //            }
        //            //绘制关闭按钮
        //            if (_bclosebtn)
        //            {
        //                bool b = false;//是否绘制关闭按钮

        //                if (_arraySpecial != null)//如果不为特殊字符中内容绘制关闭按钮
        //                {
        //                    for (int i = 0; i < _arraySpecial.Length; i++)
        //                    {
        //                        if (_arraySpecial[i] == TabPages[index].Text)
        //                        {
        //                            b = true;
        //                            break;
        //                        }
        //                    }
        //                }

        //                if (b)
        //                {
        //                    continue;
        //                }

        //                //画关闭符号(叉子)
        //                using (Pen pen2 = new Pen(_closeColor, tabRect.Height / 12f))
        //                {
        //                    Point point = new Point(tabRect.X + tabRect.Width - 2 * tabRect.Height / 3, tabRect.Y + tabRect.Height / 3);//左上
        //                    Point point2 = new Point(tabRect.X + tabRect.Width - tabRect.Height / 3, tabRect.Y + tabRect.Height * 2 / 3);//右下
        //                    e.Graphics.DrawLine(pen2, point, point2);
        //                    Point point3 = new Point(tabRect.X + tabRect.Width - 2 * tabRect.Height / 3, tabRect.Y + tabRect.Height * 2 / 3);//左下
        //                    Point point4 = new Point(tabRect.X + tabRect.Width - tabRect.Height / 3, tabRect.Y + tabRect.Height / 3);//右上
        //                    e.Graphics.DrawLine(pen2, point3, point4);
        //                }
        //                if (hover)
        //                {
        //                    int x = cusorPoint.X;
        //                    int y = cusorPoint.Y;
        //                    Rectangle rect = GetTabRect(index);
        //                    rect.Offset(rect.Width - 7 * tabRect.Height / 8, rect.Height / 8);
        //                    rect.Width = tabRect.Height * 3 / 4;
        //                    rect.Height = tabRect.Height * 3 / 4;
        //                    if ((((x >= rect.X) && (x <= rect.Right)) && (y >= rect.Y)) && (y <= rect.Bottom))
        //                    {
        //                        Color _pencolor = _closeColor;


        //                        if (_down)
        //                        {
        //                            _pencolor = DownColor;
        //                            //_pencolor = NetControlByJowen.RenderHelper.GetColor(_pencolor, 0, -70, -66, -56);
        //                        }

        //                        using (SolidBrush brush = new SolidBrush(_pencolor))//画圆
        //                        {
        //                            e.Graphics.FillEllipse(brush, tabRect.X + tabRect.Width - tabRect.Height / 2 - 3 * tabRect.Height / 8, tabRect.Y + tabRect.Height / 2 - 3 * tabRect.Height / 8, 3 * tabRect.Height / 4, 3 * tabRect.Height / 4);
        //                        }

        //                        using (Pen pen2 = new Pen(_cselectColor, tabRect.Height / 12f))
        //                        {
        //                            Point point = new Point(tabRect.X + tabRect.Width - 2 * tabRect.Height / 3, tabRect.Y + tabRect.Height / 3);//左上
        //                            Point point2 = new Point(tabRect.X + tabRect.Width - tabRect.Height / 3, tabRect.Y + tabRect.Height * 2 / 3);//右下
        //                            e.Graphics.DrawLine(pen2, point, point2);
        //                            Point point3 = new Point(tabRect.X + tabRect.Width - 2 * tabRect.Height / 3, tabRect.Y + tabRect.Height * 2 / 3);//左下
        //                            Point point4 = new Point(tabRect.X + tabRect.Width - tabRect.Height / 3, tabRect.Y + tabRect.Height / 3);//右上
        //                            e.Graphics.DrawLine(pen2, point3, point4);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        

        //protected override void OnPaintBackground(PaintEventArgs pevent)
        //{
        //    if (this.DesignMode == true)
        //    {
        //        LinearGradientBrush backBrush = new LinearGradientBrush(
        //                    this.Bounds,
        //                    SystemColors.ControlLightLight,
        //                    SystemColors.ControlLight,
        //                    LinearGradientMode.Vertical);
        //        pevent.Graphics.FillRectangle(backBrush, this.Bounds);
        //        backBrush.Dispose();
        //    }
        //    else
        //    {
        //        this.PaintTransparentBackground(pevent.Graphics, this.ClientRectangle);
        //    }
        //}
        /// <summary>
        ///  TabContorl 背景色设置
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        protected void PaintTransparentBackground(Graphics g, Rectangle clipRect)
        {
            if ((this.Parent != null))
            {
                //clipRect.Offset(this.Location);
                PaintEventArgs e = new PaintEventArgs(g, clipRect);
                GraphicsState state = g.Save();
                g.SmoothingMode = SmoothingMode.HighSpeed;
                try
                {
                    g.TranslateTransform((float)-this.Location.X, (float)-this.Location.Y);
                    this.InvokePaintBackground(this.Parent, e);
                    this.InvokePaint(this.Parent, e);
                }
                finally
                {
                    g.Restore(state);
                    clipRect.Offset(-this.Location.X, -this.Location.Y);
                    //using (SolidBrush brush = new SolidBrush(_backColor))
                    //{
                    //    clipRect.Inflate(1, 1);
                    //    g.FillRectangle(brush, clipRect);
                    //}
                }
            }
            else
            {
                System.Drawing.Drawing2D.LinearGradientBrush backBrush = new System.Drawing.Drawing2D.LinearGradientBrush(this.Bounds, SystemColors.ControlLightLight, SystemColors.ControlLight, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                g.FillRectangle(backBrush, this.Bounds);
                backBrush.Dispose();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.PaintTransparentBackground(e.Graphics, this.ClientRectangle);
            this.PaintAllTheTabs(e);
            this.PaintTheTabPageBorder(e);
            this.PaintTheSelectedTab(e);
            
        }
        /// <summary>
        /// 绘制Tabs
        /// </summary>
        /// <param name="e"></param>
        private void PaintAllTheTabs(PaintEventArgs e)
        {
            if (this.TabCount > 0)
            {
                for (int index = 0; index < this.TabCount; index++)
                {
                    this.PaintTab(e, index);
                }
            }
        }
        /// <summary>
        /// 绘制Tab
        /// </summary>
        /// <param name="e"></param>
        private void PaintTab(PaintEventArgs e, int index)
        {
            GraphicsPath path = this.GetPath(index);
            this.PaintTabBackground(e.Graphics, index, path);
            this.PaintTabBorder(e.Graphics, index, path);
            this.PaintTabText(e.Graphics, index);
            this.PaintTabImage(e.Graphics, index);
        }

        /// <summary>
        /// 设置选项卡头部颜色
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="index"></param>
        /// <param name="path"></param>
        private void PaintTabBackground(Graphics graph, int index,GraphicsPath path)
        {
            Rectangle rect = this.GetTabRect(index);

            if(rect.Width == 0)rect.Width = 5;
            if (rect.Height == 0) rect.Height = 5;

            Brush buttonBrush = new LinearGradientBrush(rect,BackColor, SystemColors.ControlLight, LinearGradientMode.Vertical);  //非选中时候的 TabPage 页头部背景色
            if (index == this.SelectedIndex)
            {
                buttonBrush = new SolidBrush(_headSelectedBackColor);
            }
            graph.FillPath(buttonBrush, path);
            buttonBrush.Dispose();
        }

        /// <summary>
        /// 设置选项卡头部边框色
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="index"></param>
        /// <param name="path"></param>
        private void PaintTabBorder(Graphics graph, int index, GraphicsPath path)
        {
            Pen borderPen = new Pen(_borderColor);// TabPage 非选中时候的 TabPage 头部边框色
            if (index == this.SelectedIndex)
            {
                borderPen = new Pen(_headSelectedBorderColor); // TabPage 选中后的 TabPage 头部边框色
            }
            graph.DrawPath(borderPen, path);
            borderPen.Dispose();
        }
        /// <summary>
        /// 绘制图片
        /// </summary>
        /// <param name="g"></param>
        /// <param name="index"></param>
        private void PaintTabImage(Graphics g, int index)
        {
            Image tabImage = null;
            if (this.TabPages[index].ImageIndex > -1 && this.ImageList != null)
            {
                tabImage = this.ImageList.Images[this.TabPages[index].ImageIndex];
            }
            else if (this.TabPages[index].ImageKey.Trim().Length > 0 && this.ImageList != null)
            {
                tabImage = this.ImageList.Images[this.TabPages[index].ImageKey];
            }
            if (tabImage != null)
            {
                Rectangle rect = this.GetTabRect(index);
                g.DrawImage(tabImage, rect.Right - rect.Height - 4, 4, rect.Height - 2, rect.Height - 2);
            }
        }
        /// <summary>
        /// 绘制标签文字
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="index"></param>
        private void PaintTabText(System.Drawing.Graphics graph, int index)
        {
            Rectangle rect = this.GetTabRect(index);
            
            PointF textPoint = new PointF();
            SizeF textSize = TextRenderer.MeasureText(this.TabPages[index].Text, this.Font);
            // 加上每个标签的左偏移量X  
            textPoint.X = rect.X + (rect.Width - textSize.Width) / 2;
            textPoint.Y = rect.Bottom - textSize.Height - this.Padding.Y;
            var newRect = new Rectangle(rect.Location,new Size(rect.Width + Padding.X, rect.Height + Padding.Y * 2));
            string tabtext = this.TabPages[index].Text;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;

            Brush forebrush = null;

            if (this.TabPages[index].Enabled == false)
            {
                forebrush = SystemBrushes.ControlDark;
            }
            else
            {
                forebrush = SystemBrushes.ControlText;
            }

            Font tabFont = this.Font;
            if (index == this.SelectedIndex)
            {
                tabFont = new Font(this.Font, FontStyle.Bold);
            }
            graph.DrawString(tabtext, tabFont, forebrush, newRect, format);
        }

        /// <summary>
        /// 设置 TabPage 内容页边框色
        /// </summary>
        /// <param name="e"></param>
        private void PaintTheTabPageBorder(System.Windows.Forms.PaintEventArgs e)
        {
            if (this.TabCount > 0)
            {
                Rectangle borderRect = this.TabPages[0].Bounds;
                borderRect.Inflate(1, 1);
                //ControlPaint.DrawBorder(e.Graphics, borderRect, ThemedColors.ToolBorder, ButtonBorderStyle.Solid);
                ControlPaint.DrawBorder(e.Graphics, borderRect, this.BorderColor, ButtonBorderStyle.Solid);
            }
        }

        /// <summary>
        /// // TabPage 页头部间隔色
        /// </summary>
        /// <param name="e"></param>
        private void PaintTheSelectedTab(System.Windows.Forms.PaintEventArgs e)
        {
            Rectangle selrect;
            int selrectRight = 0;

            switch (this.SelectedIndex)
            {
                case -1:
                    break;
                case 0:
                    selrect = this.GetTabRect(this.SelectedIndex);
                    selrectRight = selrect.Right;
                    e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect.Left + 2, selrect.Bottom + 1, selrectRight - 2, selrect.Bottom + 1);
                    break;
                default:
                    selrect = this.GetTabRect(this.SelectedIndex);
                    selrectRight = selrect.Right;
                    e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect.Left + 6 - selrect.Height, selrect.Bottom + 2, selrectRight - 2, selrect.Bottom + 2);
                    break;
            }
        }

        private GraphicsPath GetPath(int index)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.Reset();

            Rectangle rect = this.GetTabRect(index);

            switch (Alignment)
            {
                case TabAlignment.Top:

                    break;
                case TabAlignment.Bottom:

                    break;
                case TabAlignment.Left:

                    break;
                case TabAlignment.Right:

                    break;
            }

            if (index == 0)
            {
                path.AddLine(rect.Left - 1, rect.Top + 1, rect.Left - 1, rect.Top + 1);
                path.AddLine(rect.Left - 1, rect.Top + 1, rect.Right, rect.Top + 1);
                path.AddLine(rect.Right, rect.Top + 1, rect.Right, rect.Bottom);
                path.AddLine(rect.Right, rect.Bottom, rect.Left - 1, rect.Bottom);
            }
            else
            {
                if (index == this.SelectedIndex)
                {
                    path.AddLine(rect.Left - 1, rect.Top, rect.Left - 1, rect.Top);
                    path.AddLine(rect.Left - 1, rect.Top, rect.Right, rect.Top);
                    path.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
                    path.AddLine(rect.Right, rect.Bottom + 1, rect.Left - 1, rect.Bottom + 1);
                }
                else
                {
                    path.AddLine(rect.Left - 1, rect.Top, rect.Left - 1, rect.Top);
                    path.AddLine(rect.Left - 1, rect.Top, rect.Right, rect.Top);
                    path.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
                    path.AddLine(rect.Right, rect.Bottom + 1, rect.Left - 1, rect.Bottom + 1);
                }
            }
            return path;
        }
        #region 字体变动

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_SETFONT = 0x30;
        private const int WM_FONTCHANGE = 0x1d;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.OnFontChanged(EventArgs.Empty);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            IntPtr hFont = this.Font.ToHfont();
            SendMessage(this.Handle, WM_SETFONT, hFont, (IntPtr)(-1));
            SendMessage(this.Handle, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);
            this.UpdateStyles();
            //this.ItemSize = new Size(0, this.Font.Height + 2);
        }
#endregion
    }
}

