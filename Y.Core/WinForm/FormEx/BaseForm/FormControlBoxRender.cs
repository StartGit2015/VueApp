using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using Y.Core.WinForm.Enums;
using Y.Core.WinForm.SKin;
using System.Win32;
namespace Y.Core.WinForm.FormEx
{
  //绘制窗体控制按钮
  internal class FormControlBoxRender
  {
    #region 窗体控制按钮绘制 path

    #region 绘制关闭按钮

    /// <summary>
    /// 关闭图标
    /// Creates the close flag points.
    /// </summary>
    /// <param name="rect">The rect.</param>
    /// <returns>
    /// Return a data(or instance) of GraphicsPath.
    /// </returns>
    public GraphicsPath CreateCloseFlagPoints(Rectangle rect)
    {
      PointF centerPoint = new PointF(
          rect.X + rect.Width / 2.0f,
          rect.Y + rect.Height / 2.0f);
      GraphicsPath path = new GraphicsPath();
      path.AddLine(
          centerPoint.X,
          centerPoint.Y - 2,
          centerPoint.X - 2,
          centerPoint.Y - 4);
      path.AddLine(
          centerPoint.X - 2,
          centerPoint.Y - 4,
          centerPoint.X - 6,
          centerPoint.Y - 4);
      path.AddLine(
          centerPoint.X - 6,
          centerPoint.Y - 4,
          centerPoint.X - 2,
          centerPoint.Y);
      path.AddLine(
          centerPoint.X - 2,
          centerPoint.Y,
          centerPoint.X - 6,
          centerPoint.Y + 4);
      path.AddLine(
          centerPoint.X - 6,
          centerPoint.Y + 4,
          centerPoint.X - 2,
          centerPoint.Y + 4);
      path.AddLine(
          centerPoint.X - 2,
          centerPoint.Y + 4,
          centerPoint.X,
          centerPoint.Y + 2);
      path.AddLine(
          centerPoint.X,
          centerPoint.Y + 2,
          centerPoint.X + 2,
          centerPoint.Y + 4);
      path.AddLine(
         centerPoint.X + 2,
         centerPoint.Y + 4,
         centerPoint.X + 6,
         centerPoint.Y + 4);
      path.AddLine(
        centerPoint.X + 6,
        centerPoint.Y + 4,
        centerPoint.X + 2,
        centerPoint.Y);
      path.AddLine(
       centerPoint.X + 2,
       centerPoint.Y,
       centerPoint.X + 6,
       centerPoint.Y - 4);
      path.AddLine(
       centerPoint.X + 6,
       centerPoint.Y - 4,
       centerPoint.X + 2,
       centerPoint.Y - 4);
      path.CloseFigure();
      return path;
    }

    #endregion

    #region 绘制最小化按钮

    public GraphicsPath CreateMinimizeFlagPath(Rectangle rect)
    {
      PointF centerPoint = new PointF(
          rect.X + rect.Width / 2.0f,
          rect.Y + rect.Height / 2.5f);

      GraphicsPath path = new GraphicsPath();

      path.AddRectangle(new RectangleF(
          centerPoint.X - 6,
          centerPoint.Y + 1,
          12,
          2));
      return path;
    }

    #endregion

    #region 绘制最大化按钮

    public GraphicsPath CreateMaximizeFlafPath(
        Rectangle rect, bool maximize)
    {
      PointF centerPoint = new PointF(
         rect.X + rect.Width / 2.0f,
         rect.Y + rect.Height / 1.9f);

      GraphicsPath path = new GraphicsPath();

      if (maximize)
      {
        path.AddLine(
            centerPoint.X - 3,
            centerPoint.Y - 2,
            centerPoint.X - 6,
            centerPoint.Y - 2);
        path.AddLine(
            centerPoint.X - 6,
            centerPoint.Y - 3,
            centerPoint.X - 6,
            centerPoint.Y + 5);
        path.AddLine(
            centerPoint.X - 6,
            centerPoint.Y + 5,
            centerPoint.X + 3,
            centerPoint.Y + 5);
        path.AddLine(
            centerPoint.X + 3,
            centerPoint.Y + 5,
            centerPoint.X + 3,
            centerPoint.Y + 1);
        path.AddLine(
            centerPoint.X + 3,
            centerPoint.Y + 1,
            centerPoint.X + 6,
            centerPoint.Y + 1);
        path.AddLine(
            centerPoint.X + 6,
            centerPoint.Y + 1,
            centerPoint.X + 6,
            centerPoint.Y - 6);
        path.AddLine(
            centerPoint.X + 6,
            centerPoint.Y - 6,
            centerPoint.X - 3,
            centerPoint.Y - 6);
        path.CloseFigure();

        path.AddRectangle(new RectangleF(
            centerPoint.X - 4,
            centerPoint.Y,
            5,
            3));

        path.AddLine(
            centerPoint.X - 1,
            centerPoint.Y - 4,
            centerPoint.X + 4,
            centerPoint.Y - 4);
        path.AddLine(
            centerPoint.X + 4,
            centerPoint.Y - 4,
            centerPoint.X + 4,
            centerPoint.Y - 1);
        path.AddLine(
            centerPoint.X + 4,
            centerPoint.Y - 1,
            centerPoint.X + 3,
            centerPoint.Y - 1);
        path.AddLine(
            centerPoint.X + 3,
            centerPoint.Y - 1,
            centerPoint.X + 3,
            centerPoint.Y - 3);
        path.AddLine(
            centerPoint.X + 3,
            centerPoint.Y - 3,
            centerPoint.X - 1,
            centerPoint.Y - 3);
        path.CloseFigure();
      }
      else
      {
        path.AddRectangle(new RectangleF(
            centerPoint.X - 6,
            centerPoint.Y - 4,
            12,
            8));
        path.AddRectangle(new RectangleF(
            centerPoint.X - 5,
            centerPoint.Y - 1,
           10,
            4));
      }

      return path;
    }

    #endregion

    #endregion
    #region  绘制控制按钮背景（最大化，最小化）

    #region  绘制控制按钮背景（最大化，最小化）

    /// <summary>
    /// 绘制控制按钮背景（最大化，最小化）
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="rect">The rect.</param>
    /// <param name="controlState">State of the control.</param>
    public void DrawControlBox(Graphics g, Rectangle rect, EnumControlState controlState)
    {
      SKin.GradientColor color;
      switch (controlState)
      {
        case EnumControlState.HeightLight:
          color = SkinManager.CurrentSkin.ControlBoxHeightLightColor;
          break;
        case EnumControlState.Focused:
          color = SkinManager.CurrentSkin.ControlBoxPressedColor;
          break;
        default:
          color = SkinManager.CurrentSkin.ControlBoxDefaultColor;
          break;
      }
      ////去掉底部的线
      Rectangle exRect = new Rectangle(rect.Left, rect.Bottom, rect.Width, 1);
      g.SetClip(exRect, CombineMode.Exclude);
      Utility.GDIHelper.FillRectangle(g, rect, color);
      ////绘制边线
      Color c1, c2;
      c1 = SkinManager.CurrentSkin.BorderColor;
      c2 = Color.FromArgb(10, c1);
      using (LinearGradientBrush brush = new LinearGradientBrush(rect, c1, c2, 90))
      {
        brush.Blend.Positions = color.Positions;
        brush.Blend.Factors = color.Factors;
        using (Pen pen = new Pen(brush, 1))
        {
          g.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Bottom);
        }
      }

      g.ResetClip();
    }
    #endregion

    #region 关闭按钮

    /// <summary>
    /// 绘制关闭按钮背景
    /// </summary>
    /// <param name="g">The g.</param>
    /// <param name="rect">The rect.</param>
    /// <param name="controlState">State of the control.</param>
    /// <param name="radius">The radius.</param>
    public void DrawCloseBox(Graphics g, Rectangle rect, EnumControlState controlState, int radius)
    {
      GradientColor color;
      switch (controlState)
      {
        case EnumControlState.HeightLight:
          color = SkinManager.CurrentSkin.CloseBoxHeightLightColor;
          break;
        case EnumControlState.Focused:
          color = SkinManager.CurrentSkin.CloseBoxPressedColor;
          break;
        default:
          color = SkinManager.CurrentSkin.ControlBoxDefaultColor;
          break;
      }
      Rectangle exRect = new Rectangle(rect.Left, rect.Bottom, rect.Width, 1);
      g.SetClip(exRect, CombineMode.Exclude);
      CornerRadius cr = new CornerRadius(0, radius + 2, 0, 0);
      Utility.GDIHelper.FillRectangle(g, new RoundRectangle(rect, cr), color);
      ////绘制边线
      Color c1, c2;
      c1 = SkinManager.CurrentSkin.BorderColor;
      c2 = Color.FromArgb(10, c1);
      using (LinearGradientBrush brush = new LinearGradientBrush(rect, c1, c2, 90))
      {
        brush.Blend.Positions = color.Positions;
        brush.Blend.Factors = color.Factors;
        using (Pen pen = new Pen(brush, 1))
        {
          g.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Bottom);
        }
      }

      g.ResetClip();
    }
    #endregion

    #endregion
  }
}
