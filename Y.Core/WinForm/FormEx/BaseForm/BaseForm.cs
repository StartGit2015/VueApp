using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Y.Core.WinForm.Utility;
using Y.Core.WinForm.Enums;

namespace Y.Core.WinForm.FormEx
{
  /// <summary>
  /// UI设计的窗体基类
  /// </summary>
  [ToolboxBitmap(typeof(Form))]
  public partial class BaseForm : Form
  {
    #region 私有属性定义

    /// <summary>
    /// 圆角值
    /// </summary>
    private int _CornerRadius = 3;

    /// <summary>
    /// 标题栏高度
    /// </summary>
    private int _CaptionHeight = 27;

    /// <summary>
    /// 标题栏字体
    /// </summary>
    private Font _CaptionFont = SystemFonts.CaptionFont;

    /// <summary>
    /// 标题颜色
    /// </summary>
    private Color _CaptionColor = Color.Black;

    /// <summary>
    /// 边框宽度
    /// </summary>
    private int _BorderWidth = 3;

    /// <summary>
    /// 是否可以调整大小
    /// </summary>
    private bool _ResizeEnable = true;

    /// <summary>
    /// 控制按钮大小（最小化，最大化，关闭）
    /// </summary>
    private Size _ControlBoxSize = new Size(32, 18);

    /// <summary>
    /// 边距
    /// </summary>
    private Point _Offset = new Point(3, 0);

    /// <summary>
    /// 图标大小
    /// </summary>
    private Size _LogoSize = new Size(26, 26);

    /// <summary>
    /// 内部间距
    /// </summary>
    private Padding _Padding = new Padding(3, 1, 3, 3);
    /// <summary>
    /// 窗体Logo
    /// </summary>
    private Image _CapitionLogo;

    private bool _inPosChanged;

    /// <summary>
    /// 窗体控制按钮绘制对象
    /// </summary>
    internal FormControlBoxRender ControlBoxRender;

    #endregion
    #region 初始化
    public BaseForm()
        : base()
    {
      this.SetStyle(ControlStyles.UseTextForAccessibility |
          ControlStyles.AllPaintingInWmPaint |
          ControlStyles.OptimizedDoubleBuffer |
          ControlStyles.DoubleBuffer |
          ControlStyles.SupportsTransparentBackColor |
          ControlStyles.UserPaint, true);
      this.UpdateStyles();
      base.FormBorderStyle = FormBorderStyle.None;
      base.Padding = this.DefaultPadding;
      this.StartPosition = FormStartPosition.CenterScreen;
      base.Size = new Size(500, 350);
      this.ResetRegion();
      ////任务栏的logo
      //base.Icon = Properties.Resources.logo;
      //this._CapitionLogo = Properties.Resources.naruto;
      this._CapitionLogo = base.Icon.ToBitmap();
      this.InitializeControlBoxInfo();
      Control.YToolStripRenderer render = new Control.YToolStripRenderer();
      //this.SetToolStripRenderer(render);
      ToolStripManager.Renderer = render;
      this.KeyPreview = true;
      this.ControlBoxRender = new FormControlBoxRender();
    }
    #endregion
    #region 窗体属性

    [Category("YProperties")]
    [Description("标题栏的Logo")]
    public Image CapitionLogo
    {
      get { return this._CapitionLogo; }
      set
      {
        this._CapitionLogo = value;
        base.Invalidate(new Rectangle(0, 0, this.Width, this.CaptionHeight));
      }
    }

    [Category("YProperties")]
    [DefaultValue(typeof(Size), "26,26")]
    [Description("图标大小")]
    public Size LogoSize
    {
      get { return this._LogoSize; }
      set
      {
        this._LogoSize = value;
        base.Invalidate(this.LogoRect);
      }
    }

    [Category("YProperties")]
    [DefaultValue(3)]
    [Description("窗体圆角值")]
    public int CornerRadius
    {
      get { return this._CornerRadius; }
      set
      {
        this._CornerRadius = value > 0 ? value : 0;
        base.Invalidate();
      }
    }

    [Category("YProperties")]
    [DefaultValue(true)]
    [Description("是否允许客户调整窗体大小")]
    public bool ResizeEnable
    {
      get { return this._ResizeEnable; }
      set { this._ResizeEnable = value; }
    }

    [Category("YProperties")]
    [DefaultValue(25)]
    [Description("窗口标题高度，为0则为无标题栏窗体")]
    public int CaptionHeight
    {
      get { return this._CaptionHeight; }
      set
      {
        if (value == 0)
        {
          this._CaptionHeight = 0;
          this.ControlBox = false;
        }
        else
        {
          this._CaptionHeight = value > this._BorderWidth ? value : this._BorderWidth;
        }

        base.Invalidate();
      }
    }

    [Category("YProperties")]
    [DefaultValue(typeof(Font), "CaptionFont")]
    [Description("窗口标题字体")]
    public Font CaptionFont
    {
      get { return this._CaptionFont; }
      set
      {
        if (value == null)
        {
          this._CaptionFont = new Font("微软雅黑", 18);
        }
        else
        {
          this._CaptionFont = value;
        }

        base.Invalidate(new Rectangle(0, 0, this.Width, this.CaptionHeight));
      }
    }

    [Category("YProperties")]
    [DefaultValue(typeof(Color), "White")]
    [Description("窗口标题字体颜色")]
    public Color CaptionColor
    {
      get { return this._CaptionColor; }
      set
      {
        this._CaptionColor = value;
        base.Invalidate(new Rectangle(0, 0, this.Width, this.CaptionHeight));
      }
    }

    [Category("YProperties")]
    [DefaultValue(typeof(Size), "32, 18")]
    [Description("窗体控制按钮大小")]
    public Size ControlBoxSize
    {
      get { return this._ControlBoxSize; }
      set { this._ControlBoxSize = value; base.Invalidate(new Rectangle(0, 0, this.Width, this.CaptionHeight)); }
    }

    [Category("YProperties")]
    [DefaultValue(typeof(Point), "8,0")]
    [Description("窗体标题栏内容与边框的偏移量")]
    public Point Offset
    {
      get { return this._Offset; }
      set { this._Offset = value; base.Invalidate(new Rectangle(0, 0, this.Width, this.CaptionHeight)); }
    }

    [Category("YProperties")]
    [DefaultValue(0)]
    [Description("边框宽度")]
    public int BorderWidth
    {
      get { return this._BorderWidth; }
      set { this._BorderWidth = value > 1 ? value : 1; }
    }

    [Category("YProperties")]
    [DefaultValue(typeof(Padding), "0")]
    public new Padding Padding
    {
      get { return this._Padding; }
      set
      {
        this._Padding = value;
        base.Padding = new Padding(this._BorderWidth + this._Padding.Left,
            this._CaptionHeight + this._Padding.Top,
            this._BorderWidth + this._Padding.Right,
            this._BorderWidth + this._Padding.Bottom);
        base.Invalidate();
      }
    }

    [Category("YProperties")]
    public override string Text
    {
      get
      {
        return base.Text;
      }
      set
      {
        base.Text = value;
        base.Invalidate(new Rectangle(0, 0, this.Width, this._CaptionHeight + 1));
      }
    }
    /// <summary>
    /// 标题栏区域
    /// </summary>
    protected Rectangle CaptionRect
    {
      get
      {
        return new Rectangle(0, 0, this.Width - this.Offset.X, this.CaptionHeight);
      }
    }
    /// <summary>
    /// 工作区域
    /// </summary>
    protected Rectangle WorkRectangle
    {
      get
      {
        return new Rectangle(this.Padding.Left,
            this.CaptionHeight + this.Padding.Top,
            this.Width - this.Padding.Left - this.Padding.Right,
            this.Height - this.CaptionHeight - this.Padding.Top - this.Padding.Bottom);
      }
    }

    protected override Padding DefaultPadding
    {
      get
      {
        return new Padding(this._BorderWidth, this._CaptionHeight, this._BorderWidth, this._BorderWidth);
      }
    }

    #endregion
    #region 重载方法
    //protected override CreateParams CreateParams
    //{
    //  get
    //  {
    //    CreateParams ret = base.CreateParams;
    //    ret.ExStyle = (int)Enums.WindowStyle.WS_THICKFRAME;
    //    //   (int)Enums.WindowStyle.WS_CHILD;
    //    ret.ExStyle |= (int)Enums.WindowStyleEx.WS_EX_NOACTIVATE;
    //    //   (int)Enums.WindowStyleEx.WS_EX_TOOLWINDOW;
    //    return ret;
    //  }
    //}
    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams cp = base.CreateParams;
        if (!DesignMode)
        {
          //cp.Style |= (int)Enums.WindowStyle.WS_SIZEBOX;
          //cp.Style |= (int)Enums.WindowStyle.WS_THICKFRAME;
          //cp.ExStyle |= (int)Enums.WindowStyleEx.WS_EX_NOACTIVATE | (int)Enums.WindowStyleEx.WS_EX_TOPMOST;

          if (ControlBox)
          {
            cp.Style |= (int)Enums.WindowStyle.WS_SYSMENU;
          }

          if (MinimizeBox)
          {
            cp.Style |= (int)Enums.WindowStyle.WS_MINIMIZEBOX;
          }

          if (!MaximizeBox)
          {
            cp.Style &= ~(int)Enums.WindowStyle.WS_MAXIMIZEBOX;
          }

          if (this._inPosChanged)
          {
            cp.Style &= ~((int)Enums.WindowStyle.WS_THICKFRAME |
                (int)Enums.WindowStyle.WS_SYSMENU);
            cp.ExStyle &= ~((int)Enums.WindowStyleEx.WS_EX_DLGMODALFRAME |
                (int)Enums.WindowStyleEx.WS_EX_WINDOWEDGE);
          }
        }

        return cp;
      }
   }

    protected override void OnCreateControl()
    {
      this.ResetRegion();
      base.OnCreateControl();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      if (this.Created)
      {
        this.ResetRegion();
        this.Invalidate();
      }
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      this.ProcessMouseMove(e.Location);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      this.ProcessMouseDown(e.Location);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      this.ProcessMouseUp(e.Location);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      this.ProcessMouseLeave(PointToClient(MousePosition));
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
      base.OnKeyPress(e);
      if (e.KeyChar == (char)27)
      {
        this.Close();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      GDIHelper.InitializeGraphics(g);
      this.DrawFormBackGround(g);
      this.DrawCaption(g);
      this.DrawFormBorder(g);
    }

    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case (int)WindowMessages.WM_NCHITTEST:
          WmNcHitTest(ref m);
          break;
        case (int)WindowMessages.WM_NCPAINT:
        case (int)WindowMessages.WM_NCCALCSIZE:
          break;
        case (int)WindowMessages.WM_WINDOWPOSCHANGED:
          _inPosChanged = true;
          base.WndProc(ref m);
          _inPosChanged = false;
          break;
        case (int)WindowMessages.WM_GETMINMAXINFO:
          WmMinMaxInfo(ref m);
          break;
        case (int)WindowMessages.WM_LBUTTONDBLCLK:

        default:
          base.WndProc(ref m);
          break;
      }
    }

    #endregion
    #region 窗体私有方法

    /// <summary>
    /// 设置窗口区域
    /// </summary>
    private void ResetRegion()
    {
      if (base.Region != null)
      {
        base.Region.Dispose();
      }

      Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
      RoundRectangle roundRect = new RoundRectangle(rect, new System.Win32.CornerRadius(this._CornerRadius));
      using (System.Drawing.Drawing2D.GraphicsPath path = roundRect.ToGraphicsBezierPath())
      {
        path.CloseFigure();
        base.Region = new Region(path);
      }

      //这种方式设置窗口圆角，边框不好控制
      //int rgn = System.Win32.Win32.CreateRoundRectRgn(0, 0,
      //    this.Size.Width, this.Size.Height,
      //    this._CornerRadius + 1, this._CornerRadius);
      //System.Win32.Win32.SetWindowRgn(this.Handle, rgn, true);
    }
    #endregion
  }
}
