﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Win32;
using Y.Core.WinForm.SKin;
using Y.Core.WinForm.Utility;
using System.Windows.Forms;

namespace Y.Core.WinForm.FormEx
{
  /// <summary>
  /// 基类窗体的绘制处理类
  /// </summary>
  partial class BaseForm
  {
    #region 状窗体控制按钮区域

    /// <summary>
    /// 图标的矩形区域
    /// </summary>
    protected virtual Rectangle LogoRect
    {
      get
      {
        Rectangle rect = new Rectangle();
        if (base.ShowIcon && this.CapitionLogo != null)
        {
          int w = this._LogoSize.Width;
          int h = this._LogoSize.Height;
          rect = new Rectangle(this._Offset.X, this._CaptionHeight / 2 - h / 2 + 1, w, h);
        }

        return rect;
      }
    }

    /// <summary>
    /// 关闭按钮的矩形区域
    /// </summary>
    protected Rectangle CloseBoxRect
    {
      get
      {
        if (base.ControlBox)
        {
          return new Rectangle(base.Width - 1 - this._ControlBoxSize.Width,
               0, this._ControlBoxSize.Width, this._ControlBoxSize.Height);
        }

        return Rectangle.Empty;
      }
    }

    /// <summary>
    /// 最大化按钮的矩形区域
    /// </summary>
    protected Rectangle MaximizeBoxRect
    {
      get
      {
        if (base.ControlBox && base.MaximizeBox)
        {
          return new Rectangle(base.Width - 1 - this._ControlBoxSize.Width - this.CloseBoxRect.Width,
             0, this._ControlBoxSize.Width, this._ControlBoxSize.Height);
        }

        return Rectangle.Empty;
      }
    }

    /// <summary>
    /// 最小化的矩形区域
    /// </summary>
    protected Rectangle MinimizeBoxRect
    {
      get
      {
        if (base.ControlBox && base.MinimizeBox)
        {
          return new Rectangle(base.Width - 1 - this._ControlBoxSize.Width - this.CloseBoxRect.Width - this.MaximizeBoxRect.Width,
               0, this._ControlBoxSize.Width, this._ControlBoxSize.Height);
        }

        return Rectangle.Empty;
      }
    }

    #endregion

    #region 窗体背景边框绘制方法

    /// <summary>
    /// 绘制窗体背景
    /// </summary>
    /// <param name="g">The g.</param>
    private void DrawFormBackGround(Graphics g)
    {
      Rectangle rect = new Rectangle(0, 0, this.Width - 2, this.Height - 2);
      if (SkinManager.CurrentSkin.BackGroundImageEnable)
      {
        GDIHelper.DrawImage(g, rect, SkinManager.CurrentSkin.BackGroundImage, SkinManager.CurrentSkin.BackGroundImageOpacity);
        //GDIHelper.DrawImage(g, rect, SkinManager.CurrentSkin.BackGroundImage);
      }
      else
      {
        GDIHelper.FillRectangle(g, rect, SkinManager.CurrentSkin.ThemeColor);
      }
    }

    /// <summary>
    /// 绘制窗体边框
    /// </summary>
    /// <param name="g">The g.</param>
    private void DrawFormBorder(Graphics g)
    {
      if (this.WindowState == FormWindowState.Maximized)
      {
        return;
      }

      Rectangle rect = new Rectangle(0, 0, this.Width - 2 , this.Height - 2);
      RoundRectangle roundRect = new RoundRectangle(rect, new CornerRadius(this.CornerRadius));
      //GDIHelper.DrawPathBorder(g, roundRect);
      using (GraphicsPath path = this._CornerRadius == 0 ? roundRect.ToGraphicsBezierPath() : roundRect.ToGraphicsArcPath())
      {
        using (Pen pen = new Pen(SkinManager.CurrentSkin.BorderColor))
        {
          g.DrawPath(pen, path);
        }
      }
    }

    #endregion

    #region 标题栏区域绘制

    /// <summary>
    /// 绘制标题栏内容
    /// </summary>
    /// <param name="g">The g.</param>
    protected virtual void DrawCaption(Graphics g)
    {
      if (this._CaptionHeight > 0)
      {
        this.DrawCaptionBackGround(g);
        this.DrawCaptionLogo(g);
        this.DrawCaptionText(g);
        this.DrawControlBox(g);
      }
    }

    /// <summary>
    /// 绘制窗体Logo图标
    /// </summary>
    /// <param name="g">The g.</param>
    protected void DrawCaptionLogo(Graphics g)
    {
      if (base.ShowIcon && this.CapitionLogo != null)
      {
        GDIHelper.DrawImage(g, this.LogoRect, this._CapitionLogo, this.LogoSize);
      }
    }

    /// <summary>
    /// 绘制窗口标题（绘制到中间位置）
    /// Draws the caption text.
    /// </summary>
    /// <param name="g">The g.</param>
    private void DrawCaptionText(Graphics g)
    {
      Rectangle rect = new Rectangle(0, 0, base.Width, this._CaptionHeight);
      TextRenderer.DrawText(g, this.Text, this._CaptionFont, rect, SkinManager.CurrentSkin.CaptionFontColor, TextFormatFlags.VerticalCenter |
          TextFormatFlags.HorizontalCenter |
          TextFormatFlags.SingleLine |
          TextFormatFlags.WordEllipsis);
    }

    /// <summary>
    /// 绘制窗体标题栏
    /// </summary>
    /// <param name="g">The g.</param>
    private void DrawCaptionBackGround(Graphics g)
    {
      Rectangle rect = new Rectangle(0, 0, this.Width, this.CaptionHeight);
      Rectangle exRect = new Rectangle(rect.Left, rect.Bottom, rect.Width, 1);
      g.SetClip(exRect, CombineMode.Exclude);
      GDIHelper.FillRectangle(g, rect, SkinManager.CurrentSkin.CaptionColor);
      g.ResetClip();
    }

    #endregion

    #region 绘制控制按钮

    #region 绘制控制按钮

    /// <summary>
    /// 绘制控制按钮.
    /// </summary>
    /// <param name="g">The Graphics.</param>
    protected virtual void DrawControlBox(Graphics g)
    {
      Rectangle closeRect = this.CloseBoxRect;
      Rectangle maxRect = this.MaximizeBoxRect;
      Rectangle minRect = this.MinimizeBoxRect;
      this.DrawCloseBox(g, closeRect, maxRect, minRect);
      this.DrawMaxBox(g, maxRect, minRect);
      this.DrawMinBox(g, minRect);
    }
    #endregion

    #region 绘制关闭控制按钮

    /// <summary>
    /// 绘制关闭控制按钮.
    /// </summary>
    /// <param name="g">The Graphics.</param>
    private void DrawCloseBox(Graphics g, Rectangle closeRect, Rectangle rectMax, Rectangle rectMin)
    {
      if (closeRect != Rectangle.Empty)
      {
        this.ControlBoxRender.DrawCloseBox(g, closeRect, this._CloseBoxState, this.CornerRadius);
        using (Pen pen = new Pen(SkinManager.CurrentSkin.ControlBoxFlagColor, 2))
        {
          PointF centerPoint = new PointF(
      closeRect.X + closeRect.Width / 2.0f,
      closeRect.Y + closeRect.Height / 2.0f);
          g.DrawLine(pen, centerPoint.X - 5, centerPoint.Y - 4, centerPoint.X + 3, centerPoint.Y + 4);
          g.DrawLine(pen, centerPoint.X - 5, centerPoint.Y + 4, centerPoint.X + 3, centerPoint.Y - 4);
        }
      }
    }
    #endregion

    #region 绘制最大化控制按钮
    /// <summary>
    /// 绘制最大化控制按钮.
    /// </summary>
    /// <param name="g">The Graphics.</param>
    private void DrawMaxBox(Graphics g, Rectangle maxRect, Rectangle rectMin)
    {
      if (maxRect != Rectangle.Empty)
      {
        this.ControlBoxRender.DrawControlBox(g, maxRect, this._MaxBoxState);
        using (Brush brush = new SolidBrush(SkinManager.CurrentSkin.ControlBoxFlagColor))
        {
          g.FillPath(brush, this.ControlBoxRender.CreateMaximizeFlafPath(maxRect, this.WindowState == FormWindowState.Maximized ? true : false));
        }
      }
    }
    #endregion

    #region 绘制最小化控制按钮
    /// <summary>
    /// 绘制最小化控制按钮.
    /// </summary>
    /// <param name="g">The Graphics.</param>
    private void DrawMinBox(Graphics g, Rectangle minRect)
    {
      if (minRect != Rectangle.Empty)
      {
        this.ControlBoxRender.DrawControlBox(g, minRect, this._MinBoxState);
        using (Brush brush = new SolidBrush(SkinManager.CurrentSkin.ControlBoxFlagColor))
        {
          g.FillPath(brush, this.ControlBoxRender.CreateMinimizeFlagPath(minRect));
        }
      }
    }
    #endregion

    #endregion
  }
}
