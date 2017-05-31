using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using System.Win32;

namespace CFW.WinFormBase.Controls
{
    public partial class ComboBoxEx : ComboBox
    {
        public ComboBoxEx():base()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor 
                | ControlStyles.ResizeRedraw
                | ControlStyles.DoubleBuffer, true);
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.BackColor = Color.Transparent;
            
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
       
        protected  void OnPrePaint()
        {
            var g = this.CreateGraphics();
            //画边框
            if (this.Focused)
            {
                ControlPaint.DrawBorder(g, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height), Color.DeepSkyBlue, ButtonBorderStyle.Solid);
            }
            else
            {
                ControlPaint.DrawBorder(g, new Rectangle(0, 0, ClientRectangle.Width - 17, ClientRectangle.Height), BackColor, ButtonBorderStyle.Solid);
            }

            g.DrawLine(new Pen(Color.Blue, 2.5f), 0, ClientRectangle.Height, ClientRectangle.Width - 17, ClientRectangle.Height);
        }
        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            var g = CreateGraphics();
            int width = this.Width;
            foreach (var item in Items)
            {
                var text = FilterItemOnProperty(item).ToString();
                var dwidth = (int)g.MeasureString(text, this.Font).Width;
                if (dwidth > width)
                {  width = dwidth; }
            }
            this.DropDownWidth = width;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            //获取要在其上绘制项的图形表面
            Graphics g = e.Graphics;
            //获取表示所绘制项的边界的矩形
            Rectangle rect = e.Bounds;
            //定义字体对象
            if (e.Index >= 0)
            {
                //获得当前Item的文本
                string tempString = FilterItemOnProperty(Items[e.Index]).ToString();
                //在当前项图形表面上划一个矩形
                g.FillRectangle(new SolidBrush(BackColor), rect);
                //在当前项图形表面上划上当前Item的文本
                g.DrawString(tempString, this.Font, new SolidBrush(Color.Blue), rect.Left, rect.Top);
                //e.DrawFocusRectangle();

                if ((e.State&DrawItemState.Focus)==0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(BackColor), rect);
                    g.DrawString(tempString, Font, new SolidBrush(ForeColor), rect.Left, rect.Top);
                    e.DrawFocusRectangle();
                }
            }
        }

    protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //WM_PAINT = 0xf; 要求一个窗口重画自己,即Paint事件时  
            //WM_CTLCOLOREDIT = 0x133;当一个编辑型控件将要被绘制时发送此消息给它的父窗口；  
            //通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景颜色  
            //windows消息值表,可参考:http://hi.baidu.com/dooy/blog/item/0e770a24f70e3b2cd407421b.html  
            switch (m.Msg)
            {
                case 0xF:
                    IntPtr hDC = Win32.GetWindowDC(m.HWnd);
                    if (hDC.ToInt32() == 0) //如果取设备上下文失败则返回  
                    { return; }

                    Graphics g = Graphics.FromHdc(hDC);
                    PaintComboBox(g);
                    //释放DC    
                    Win32.ReleaseDC(m.HWnd, hDC);
                    break;
                default:
                    break;
            }
        }
        private void PaintComboBox(Graphics g)
        {
            
            //int iDropDownButtonWidth = 17;
            //int iDropDownButtonHeight = this.Height;
            //int iDropDownButtonLocatinX = 17;
            //int iDropDownButtonLocatinY = 0;

            //下拉按钮
            //Rectangle dropDownRectangle = new Rectangle(ClientRectangle.Width - iDropDownButtonLocatinX, iDropDownButtonLocatinY, iDropDownButtonWidth, iDropDownButtonHeight);
            //背景色刷
            //Brush bkgBrush;
            //字体色刷
            //Brush fcBrush;
            //设置背景色和字体色
            //bkgBrush = new SolidBrush(BackColor);
            //fcBrush = new SolidBrush(this.ForeColor);
            //画背景
            //g.FillRectangle(bkgBrush, new Rectangle(0, 0, this.Width - 17, this.Height));
            //ComboBoxRenderer.DrawTextBox(g, new Rectangle(0, 0, this.Width, this.Height), this.Enabled ? ComboBoxState.Normal : ComboBoxState.Disabled);
            //画下拉按钮
            //ComboBoxRenderer.DrawDropDownButton(g, dropDownRectangle, this.Enabled ? ComboBoxState.Normal : ComboBoxState.Disabled);

            //为了字体正常，Disable时才重画文本


            //if (!this.Enabled)
            //{
            //    画文本
            //    SizeF sizeF = g.MeasureString(base.Text, Font);
            //    g.DrawString(base.Text, this.Font, fcBrush, 2, this.ClientSize.Height / 2, new StringFormat() { LineAlignment = StringAlignment.Center });
            //}
            //else
            //{
            //    if (!SelectedText.IsNullOrEmpty())
            //    {
            //        base.Text = SelectedText;
            //    }
            //    画文本
            //    SizeF sizeF = g.MeasureString(base.Text, Font);
            //    g.DrawString(base.Text, this.Font, fcBrush, new Rectangle(2, 2, this.Width, this.Height), new StringFormat() { LineAlignment = StringAlignment.Center });
            //}
            //画边框
            if (this.Focused)
            {
                ControlPaint.DrawBorder(g, new Rectangle(0, 0, ClientRectangle.Width , ClientRectangle.Height), Color.DeepSkyBlue, ButtonBorderStyle.Solid);
            }
            else 
            {
                ControlPaint.DrawBorder(g, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height), BackColor, ButtonBorderStyle.Solid);
            }
            
            g.DrawLine(new Pen(Color.Blue, 2.5f), 0, ClientRectangle.Height, ClientRectangle.Width , ClientRectangle.Height);
            g.Dispose();
            //bkgBrush.Dispose();
            //fcBrush.Dispose();
        }
    }
}
