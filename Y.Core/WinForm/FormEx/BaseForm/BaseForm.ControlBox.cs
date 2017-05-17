using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Win32;
using Y.Core.WinForm.Enums;
using System.Drawing;

namespace Y.Core.WinForm.FormEx
{
  public partial class BaseForm
  {
    #region 字段

    private EnumControlState _MinBoxState;

    private EnumControlState _MaxBoxState;

    private EnumControlState _CloseBoxState;

    #endregion

    #region 控制按钮初始化

    /// <summary>
    /// 控制按钮初始化.
    /// </summary>
    private void InitializeControlBoxInfo()
    {
      this._MinBoxState = EnumControlState.Default;
      this._MaxBoxState = EnumControlState.Default;
      this._CloseBoxState = EnumControlState.Default;
    }

    #endregion

    #region 按钮状态属性

    /// <summary>
    /// 最小化按钮.
    /// </summary>
    /// <value>The state of the min box.</value>
    private EnumControlState MinBoxState
    {
      get { return this._MinBoxState; }
      set
      {
        this._MinBoxState = value;
      }
    }

    private EnumControlState MaxBoxState
    {
      get { return this._MaxBoxState; }
      set
      {
        this._MaxBoxState = value;
      }
    }

    private EnumControlState CloseBoxState
    {
      get { return this._CloseBoxState; }
      set
      {
        this._CloseBoxState = value;
      }
    }
    #endregion

    #region 按钮鼠标处理方法

    /// <summary>
    /// 处理鼠标移动
    /// </summary>
    /// <param name="p">The Point.</param>
    protected virtual void ProcessMouseMove(System.Drawing.Point p)
    {
      this.CloseBoxState = EnumControlState.Default;
      this.MaxBoxState = EnumControlState.Default;
      this.MinBoxState = EnumControlState.Default;
      if (this.CloseBoxRect.Contains(p))
      {
        this.CloseBoxState = EnumControlState.HeightLight;
      }

      if (this.MinimizeBoxRect.Contains(p))
      {
        this.MinBoxState = EnumControlState.HeightLight;
      }

      if (this.MaximizeBoxRect.Contains(p))
      {
        this.MaxBoxState = EnumControlState.HeightLight;
      }

      this.Invalidate(this.CaptionRect);
    }

    /// <summary>
    /// 处理鼠标按下
    /// </summary>
    /// <param name="p">The Point.</param>
    protected virtual void ProcessMouseDown(Point p)
    {
      Rectangle closeRect = this.CloseBoxRect;
      Rectangle maxRect = this.MaximizeBoxRect;
      Rectangle minRect = this.MinimizeBoxRect;
      if (!closeRect.IsEmpty && closeRect.Contains(p))
      {
        this.CloseBoxState = EnumControlState.Focused;
      }

      if (!maxRect.IsEmpty && maxRect.Contains(p))
      {
        this.MaxBoxState = EnumControlState.Focused;
      }

      if (!minRect.IsEmpty && minRect.Contains(p))
      {
        this.MinBoxState = EnumControlState.Focused;
      }

      this.Invalidate(this.CaptionRect);
    }

    /// <summary>
    /// 处理鼠标放开
    /// </summary>
    /// <param name="p">The Point.</param>
    protected virtual void ProcessMouseUp(Point p)
    {
      Rectangle closeRect = this.CloseBoxRect;
      Rectangle maxRect = this.MaximizeBoxRect;
      Rectangle minRect = this.MinimizeBoxRect;
      if (!closeRect.IsEmpty && closeRect.Contains(p))
      {
        base.Close();
        this.CloseBoxState = EnumControlState.Default;
      }

      if (!maxRect.IsEmpty && maxRect.Contains(p))
      {
        FormWindowState fs = FormWindowState.Normal;
        switch (base.WindowState)
        {
          case FormWindowState.Maximized:
            fs = FormWindowState.Normal;
            break;
          case FormWindowState.Normal:
          default:
            fs = FormWindowState.Maximized;
            break;
        }

        base.WindowState = fs;
        this.MaxBoxState = EnumControlState.Default;
      }

      if (!minRect.IsEmpty && minRect.Contains(p))
      {
        base.WindowState = FormWindowState.Minimized;
        this.MinBoxState = EnumControlState.Default;
      }

      this.Invalidate(this.CaptionRect);
    }

    /// <summary>
    /// 处理鼠标离开
    /// </summary>
    /// <param name="p">The Point.</param>
    protected virtual void ProcessMouseLeave(Point p)
    {
      Rectangle closeRect = this.CloseBoxRect;
      Rectangle maxRect = this.MaximizeBoxRect;
      Rectangle minRect = this.MinimizeBoxRect;
      if (!closeRect.IsEmpty)
      {
        this.CloseBoxState = EnumControlState.Default;
      }

      if (!maxRect.IsEmpty)
      {
        this.MaxBoxState = EnumControlState.Default;
      }

      if (!minRect.IsEmpty)
      {
        this.MinBoxState = EnumControlState.Default;
      }

      this.Invalidate(this.CaptionRect);
    }

    #endregion

    #region 消息处理方法

    #region 窗体消息处理方法

    /// <summary>
    /// 对窗体鼠标消息的处理
    /// </summary>
    /// <param name="m">windows窗体消息</param>
    protected virtual void WmNcHitTest(ref Message m)
    {
      int wparam = m.LParam.ToInt32();
      Point point = new Point(
          Win32.LOWORD(wparam), Win32.HIWORD(wparam));
      point = PointToClient(point);

      if (this.LogoRect.Contains(point))
      {
        m.Result = new IntPtr((int)NCHITTEST.HTSYSMENU);
        return;
      }

      ////调整窗体大小
      if (this._ResizeEnable && this._CaptionHeight > 0)
      {
        int w = 4;
        if (point.X <= w && point.Y <= w)
        {
          m.Result = new IntPtr((int)NCHITTEST.HTTOPLEFT);
          return;
        }

        if (point.X >= (base.Width - w) && point.Y <= w)
        {
          m.Result = new IntPtr((int)NCHITTEST.HTTOPRIGHT);
          return;
        }

        if (point.X >= (base.Width - w) && point.Y >= (base.Height - w))
        {
          m.Result = new IntPtr((int)NCHITTEST.HTBOTTOMRIGHT);
          return;
        }

        if (point.X <= w && point.Y >= (base.Height - w))
        {
          m.Result = new IntPtr((int)NCHITTEST.HTBOTTOMLEFT);
          return;
        }

        if (point.Y <= w)
        {
          m.Result = new IntPtr((int)NCHITTEST.HTTOP);
          return;
        }

        if (point.Y >= (base.Height - w))
        {
          m.Result = new IntPtr((int)NCHITTEST.HTBOTTOM);
          return;
        }

        if (point.X <= w)
        {
          m.Result = new IntPtr((int)NCHITTEST.HTLEFT);
          return;
        }

        if (point.X >= (base.Width - w))
        {
          m.Result = new IntPtr((int)NCHITTEST.HTRIGHT);
          return;
        }
      }

      if (point.Y <= this._CaptionHeight)
      {
        if (!this.CloseBoxRect.Contains(point)
            && !this.MaximizeBoxRect.Contains(point)
            && !this.MinimizeBoxRect.Contains(point)
            )
        {
          m.Result = new IntPtr((int)NCHITTEST.HTCAPTION);
          return;
        }
        else
        {
          ////终于算是找着你了，都可以移动了
          m.Result = new IntPtr((int)NCHITTEST.HTCLIENT);
          return;
        }
      }

      if (this._CaptionHeight > 0)
      {
        m.Result = new IntPtr((int)NCHITTEST.HTCAPTION);
      }
    }
    #endregion

    #region 窗体状态消息

    /// <summary>
    /// 对窗体状态的控制
    /// </summary>
    /// <param name="m">The Message.</param>
    private void WmMinMaxInfo(ref Message m)
    {
      MINMAXINFO minMaxInfo = (MINMAXINFO)System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
      if (MaximumSize != Size.Empty)
      {
        minMaxInfo.maxTrackSize = base.MaximumSize;
      }
      else
      {
        Rectangle rect = Screen.GetWorkingArea(this);
        minMaxInfo.maxPosition = new Point(rect.X - this._BorderWidth, rect.Y);
        minMaxInfo.maxTrackSize = new Size(rect.Width + this._BorderWidth * 2, rect.Height + this._BorderWidth);
      }

      if (MinimumSize != Size.Empty)
      {
        minMaxInfo.minTrackSize = base.MinimumSize;
      }
      else
      {
        minMaxInfo.minTrackSize = new Size(this.CloseBoxRect.Width + this.MinimizeBoxRect.Width + this.MaximizeBoxRect.Width + this._Offset.X * 2 + this._LogoSize.Width,
            this._CaptionHeight);
      }

      System.Runtime.InteropServices.Marshal.StructureToPtr(minMaxInfo, m.LParam, false);
    }

    #endregion

    #endregion
  }
}
