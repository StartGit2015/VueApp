using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Y.Core.WinForm.FormEx
{
  public partial class LoadForm : BaseForm
  {
    private Control.LabelEx labelEx1;

    public LoadForm()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      Y.Core.WinForm.SKin.SkinThemeDefault skinThemeDefault1 = new Y.Core.WinForm.SKin.SkinThemeDefault();
      this.labelEx1 = new Y.Core.WinForm.Control.LabelEx();
      this.SuspendLayout();
      // 
      // labelEx1
      // 
      this.labelEx1.AutoSize = true;
      skinThemeDefault1.BackGroundImage = null;
      skinThemeDefault1.BackGroundImageEnable = false;
      skinThemeDefault1.BackGroundImageOpacity = 0.8F;
      skinThemeDefault1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeDefault1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
      skinThemeDefault1.CaptionFontColor = System.Drawing.Color.Black;
      skinThemeDefault1.ControlBoxFlagColor = System.Drawing.Color.White;
      skinThemeDefault1.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
      skinThemeDefault1.OuterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(182)))), ((int)(((byte)(240)))));
      skinThemeDefault1.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeDefault1.ThemeName = "系统默认";
      skinThemeDefault1.ThemeStyle = Y.Core.WinForm.SKin.EnumTheme.Default;
      skinThemeDefault1.UselessColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
      this.labelEx1.ControlTheme = skinThemeDefault1;
      this.labelEx1.Location = new System.Drawing.Point(172, 145);
      this.labelEx1.Name = "labelEx1";
      this.labelEx1.Size = new System.Drawing.Size(137, 12);
      this.labelEx1.TabIndex = 0;
      this.labelEx1.Text = "正在运行，请稍等。。。";
      // 
      // LoadForm
      // 
      this.CaptionHeight = 3;
      this.ClientSize = new System.Drawing.Size(500, 350);
      this.ControlBox = false;
      this.Controls.Add(this.labelEx1);
      this.Name = "LoadForm";
      this.Opacity = 0.5D;
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
      this.PerformLayout();

    }
  }
}
