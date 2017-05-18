using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Core.WinForm.Utility
{
  /// <summary>
  ///按钮点击事件
  /// </summary>
  public class BtnEventArgs : EventArgs
  {
    private Rectangle _Bounds;

    public BtnEventArgs(Rectangle bounds)
        : base()
    {
      this._Bounds = bounds;
    }
    /// <summary>
    /// 获取按钮的区域
    /// </summary>
    /// <value>The bounds.</value>
    /// User:Ryan  CreateTime:2011-08-12 16:26.
    public Rectangle Bounds
    {
      get
      {
        return this._Bounds;
      }
    }
  }
}
