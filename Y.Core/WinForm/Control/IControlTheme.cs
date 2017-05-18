using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Core.WinForm.SKin;

namespace Y.Core.WinForm.Control
{
  /// <summary>
  /// 扩展控件主题接口
  /// </summary>
  internal interface IControlTheme
  {
    /// <summary>
    /// 主题选择
    /// </summary>
    EnumTheme ControlThemeEnum { get; set; }
    SkinTheme ControlTheme { get; set; }
    /// <summary>
    /// 绘制背景和边框等
    /// </summary>
    /// <param name="g"></param>
    void DrawBackGround(Graphics g);
  }
}
