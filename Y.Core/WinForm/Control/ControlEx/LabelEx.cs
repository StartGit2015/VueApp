using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Win32;
using System.Windows.Forms;
using Y.Core.WinForm.SKin;
using Y.Core.WinForm.Utility;

namespace Y.Core.WinForm.Control
{
  public class LabelEx : Label, IControlTheme
  {
    /// <summary>
    /// 控件主题
    /// </summary>
    private SkinTheme _theme;
    private EnumTheme _themeEnum;

    #region 构造函数

    /// <summary>
    /// (构造函数).Initializes a new instance of the <see cref="TXButton"/> class.
    /// </summary>
    public LabelEx()
    {
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.Size = new Size(100, 28);
      _theme = SkinManager.GetSkinTeme(_themeEnum);
    }
    #endregion


    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      base.OnPaintBackground(e);
      Graphics g = e.Graphics;
      GDIHelper.InitializeGraphics(g);
      DrawBackGround(g);
      this.DrawContent(g);
    }
    [Category("YProperties")]
    [Description("控件主题")]
    [DefaultValue(EnumTheme.Default)]
    public EnumTheme ControlThemeEnum
    {
      get { return _themeEnum; }
      set
      {
        _themeEnum = value;
        _theme = SkinManager.GetSkinTeme(_themeEnum);
        this.Invalidate();
      }
    }
    [Browsable(false)]
    public SkinTheme ControlTheme
    {
      get { return _themeEnum == 0 ? SkinManager.CurrentSkin : _theme; }
      set
      {
        _theme = value;
        this.Invalidate();
      }
    }
    private void DrawBackGround(Graphics g)
    {
      GDIHelper.InitializeGraphics(g);
      Rectangle rect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

      GDIHelper.FillRectangle(g, rect, _theme.DefaultControlColor);
    }

    /// <summary>
    /// 绘制按钮的内容：图标和文字
    /// </summary>
    /// <param name="g">The Graphics.</param>
    private void DrawContent(Graphics g)
    {
      Rectangle textRect = new Rectangle(0,0,Width,Height);
      TextRenderer.DrawText(g, this.Text, this.Font, textRect, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
  }
}
