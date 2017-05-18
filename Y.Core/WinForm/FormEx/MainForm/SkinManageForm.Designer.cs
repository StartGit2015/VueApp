using Y.Core.WinForm.SKin;

namespace Y.Core.WinForm.FormEx
{
  partial class SkinManageForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkinManageForm));
      Y.Core.WinForm.SKin.SkinThemeDefault skinThemeDefault3 = new Y.Core.WinForm.SKin.SkinThemeDefault();
      Y.Core.WinForm.SKin.SkinThemeKissOfAngel skinThemeKissOfAngel3 = new Y.Core.WinForm.SKin.SkinThemeKissOfAngel();
      Y.Core.WinForm.SKin.SkinThemeNoFlower skinThemeNoFlower3 = new Y.Core.WinForm.SKin.SkinThemeNoFlower();
      Y.Core.WinForm.SKin.SkinThemeSunsetRed skinThemeSunsetRed3 = new Y.Core.WinForm.SKin.SkinThemeSunsetRed();
      Y.Core.WinForm.SKin.SkinThemeBlueSea skinThemeBlueSea3 = new Y.Core.WinForm.SKin.SkinThemeBlueSea();
      Y.Core.WinForm.SKin.SkinThemeBlueSea skinThemeBlueSea4 = new Y.Core.WinForm.SKin.SkinThemeBlueSea();
      this.btn_Defult = new Y.Core.WinForm.Control.ButtonEx();
      this.btn_天使之吻 = new Y.Core.WinForm.Control.ButtonEx();
      this.btn_似水年华 = new Y.Core.WinForm.Control.ButtonEx();
      this.trackOpacity = new System.Windows.Forms.TrackBar();
      this.btn_落日黄昏 = new Y.Core.WinForm.Control.ButtonEx();
      this.lb_opactity = new Y.Core.WinForm.Control.LabelEx();
      this.pib_backgimg = new System.Windows.Forms.PictureBox();
      this.ckb_Optickty = new Y.Core.WinForm.Control.CheckBoxEx();
      this.btn_Close = new Y.Core.WinForm.Control.ButtonEx();
      this.btn_面朝大海 = new Y.Core.WinForm.Control.ButtonEx();
      ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pib_backgimg)).BeginInit();
      this.SuspendLayout();
      // 
      // btn_Defult
      // 
      resources.ApplyResources(this.btn_Defult, "btn_Defult");
      skinThemeDefault3.BackGroundImage = null;
      skinThemeDefault3.BackGroundImageEnable = false;
      skinThemeDefault3.BackGroundImageOpacity = 0.8F;
      skinThemeDefault3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeDefault3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
      skinThemeDefault3.CaptionFontColor = System.Drawing.Color.Black;
      skinThemeDefault3.ControlBoxFlagColor = System.Drawing.Color.White;
      skinThemeDefault3.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
      skinThemeDefault3.OuterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(182)))), ((int)(((byte)(240)))));
      skinThemeDefault3.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeDefault3.ThemeName = "系统默认";
      skinThemeDefault3.ThemeStyle = Y.Core.WinForm.SKin.EnumTheme.Default;
      skinThemeDefault3.UselessColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
      this.btn_Defult.ControlTheme = skinThemeDefault3;
      this.btn_Defult.Name = "btn_Defult";
      this.btn_Defult.Tag = "0";
      this.btn_Defult.UseVisualStyleBackColor = true;
      // 
      // btn_天使之吻
      // 
      resources.ApplyResources(this.btn_天使之吻, "btn_天使之吻");
      skinThemeKissOfAngel3.BackGroundImage = null;
      skinThemeKissOfAngel3.BackGroundImageEnable = false;
      skinThemeKissOfAngel3.BackGroundImageOpacity = 0.8F;
      skinThemeKissOfAngel3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeKissOfAngel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(85)))), ((int)(((byte)(171)))));
      skinThemeKissOfAngel3.CaptionFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(255)))));
      skinThemeKissOfAngel3.ControlBoxFlagColor = System.Drawing.Color.White;
      skinThemeKissOfAngel3.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
      skinThemeKissOfAngel3.OuterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(3)))), ((int)(((byte)(123)))));
      skinThemeKissOfAngel3.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeKissOfAngel3.ThemeName = "天使之吻";
      skinThemeKissOfAngel3.ThemeStyle = Y.Core.WinForm.SKin.EnumTheme.KissOfAngel;
      skinThemeKissOfAngel3.UselessColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
      this.btn_天使之吻.ControlTheme = skinThemeKissOfAngel3;
      this.btn_天使之吻.ControlThemeEnum = Y.Core.WinForm.SKin.EnumTheme.KissOfAngel;
      this.btn_天使之吻.Name = "btn_天使之吻";
      this.btn_天使之吻.Tag = "2";
      this.btn_天使之吻.UseVisualStyleBackColor = true;
      // 
      // btn_似水年华
      // 
      resources.ApplyResources(this.btn_似水年华, "btn_似水年华");
      skinThemeNoFlower3.BackGroundImage = null;
      skinThemeNoFlower3.BackGroundImageEnable = false;
      skinThemeNoFlower3.BackGroundImageOpacity = 0.8F;
      skinThemeNoFlower3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeNoFlower3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
      skinThemeNoFlower3.CaptionFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(255)))));
      skinThemeNoFlower3.ControlBoxFlagColor = System.Drawing.Color.White;
      skinThemeNoFlower3.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
      skinThemeNoFlower3.OuterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
      skinThemeNoFlower3.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeNoFlower3.ThemeName = "如花美眷，似水流年";
      skinThemeNoFlower3.ThemeStyle = Y.Core.WinForm.SKin.EnumTheme.NoFlower;
      skinThemeNoFlower3.UselessColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
      this.btn_似水年华.ControlTheme = skinThemeNoFlower3;
      this.btn_似水年华.ControlThemeEnum = Y.Core.WinForm.SKin.EnumTheme.NoFlower;
      this.btn_似水年华.Name = "btn_似水年华";
      this.btn_似水年华.Tag = "3";
      this.btn_似水年华.UseVisualStyleBackColor = true;
      // 
      // trackOpacity
      // 
      resources.ApplyResources(this.trackOpacity, "trackOpacity");
      this.trackOpacity.BackColor = System.Drawing.Color.White;
      this.trackOpacity.Maximum = 100;
      this.trackOpacity.Name = "trackOpacity";
      this.trackOpacity.TickFrequency = 5;
      this.trackOpacity.Value = 20;
      // 
      // btn_落日黄昏
      // 
      resources.ApplyResources(this.btn_落日黄昏, "btn_落日黄昏");
      skinThemeSunsetRed3.BackGroundImage = null;
      skinThemeSunsetRed3.BackGroundImageEnable = false;
      skinThemeSunsetRed3.BackGroundImageOpacity = 0.8F;
      skinThemeSunsetRed3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeSunsetRed3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
      skinThemeSunsetRed3.CaptionFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(255)))));
      skinThemeSunsetRed3.ControlBoxFlagColor = System.Drawing.Color.White;
      skinThemeSunsetRed3.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
      skinThemeSunsetRed3.OuterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(3)))), ((int)(((byte)(123)))));
      skinThemeSunsetRed3.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeSunsetRed3.ThemeName = "夕阳西下，明月天涯";
      skinThemeSunsetRed3.ThemeStyle = Y.Core.WinForm.SKin.EnumTheme.SunsetRed;
      skinThemeSunsetRed3.UselessColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
      this.btn_落日黄昏.ControlTheme = skinThemeSunsetRed3;
      this.btn_落日黄昏.ControlThemeEnum = Y.Core.WinForm.SKin.EnumTheme.SunsetRed;
      this.btn_落日黄昏.Name = "btn_落日黄昏";
      this.btn_落日黄昏.Tag = "4";
      this.btn_落日黄昏.UseVisualStyleBackColor = true;
      // 
      // lb_opactity
      // 
      resources.ApplyResources(this.lb_opactity, "lb_opactity");
      this.lb_opactity.BackColor = System.Drawing.Color.Transparent;
      skinThemeBlueSea3.BackGroundImage = null;
      skinThemeBlueSea3.BackGroundImageEnable = false;
      skinThemeBlueSea3.BackGroundImageOpacity = 0.8F;
      skinThemeBlueSea3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeBlueSea3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(157)))), ((int)(((byte)(212)))));
      skinThemeBlueSea3.CaptionFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
      skinThemeBlueSea3.ControlBoxFlagColor = System.Drawing.Color.White;
      skinThemeBlueSea3.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
      skinThemeBlueSea3.OuterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(111)))), ((int)(((byte)(201)))));
      skinThemeBlueSea3.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeBlueSea3.ThemeName = "面朝大海，春暖花开";
      skinThemeBlueSea3.ThemeStyle = Y.Core.WinForm.SKin.EnumTheme.BlueSea;
      skinThemeBlueSea3.UselessColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
      this.lb_opactity.ControlTheme =skinThemeBlueSea3;
      this.lb_opactity.ControlThemeEnum = Y.Core.WinForm.SKin.EnumTheme.BlueSea;
      this.lb_opactity.Name = "lb_opactity";
      // 
      // pib_backgimg
      // 
      resources.ApplyResources(this.pib_backgimg, "pib_backgimg");
      this.pib_backgimg.BackColor = System.Drawing.Color.Transparent;
      this.pib_backgimg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pib_backgimg.Name = "pib_backgimg";
      this.pib_backgimg.TabStop = false;
      this.pib_backgimg.Click += new System.EventHandler(this.pib_backgimg_Click);
      // 
      // ckb_Optickty
      // 
      resources.ApplyResources(this.ckb_Optickty, "ckb_Optickty");
      this.ckb_Optickty.BackColor = System.Drawing.Color.Transparent;
      this.ckb_Optickty.Name = "ckb_Optickty";
      this.ckb_Optickty.UseVisualStyleBackColor = false;
      // 
      // btn_Close
      // 
      resources.ApplyResources(this.btn_Close, "btn_Close");
      this.btn_Close.ControlTheme = skinThemeDefault3;
      this.btn_Close.Name = "btn_Close";
      this.btn_Close.UseVisualStyleBackColor = true;
      this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
      // 
      // btn_面朝大海
      // 
      resources.ApplyResources(this.btn_面朝大海, "btn_面朝大海");
      skinThemeBlueSea4.BackGroundImage = null;
      skinThemeBlueSea4.BackGroundImageEnable = false;
      skinThemeBlueSea4.BackGroundImageOpacity = 0.8F;
      skinThemeBlueSea4.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeBlueSea4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(157)))), ((int)(((byte)(212)))));
      skinThemeBlueSea4.CaptionFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
      skinThemeBlueSea4.ControlBoxFlagColor = System.Drawing.Color.White;
      skinThemeBlueSea4.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
      skinThemeBlueSea4.OuterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(111)))), ((int)(((byte)(201)))));
      skinThemeBlueSea4.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeBlueSea4.ThemeName = "面朝大海，春暖花开";
      skinThemeBlueSea4.ThemeStyle = Y.Core.WinForm.SKin.EnumTheme.BlueSea;
      skinThemeBlueSea4.UselessColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
      this.btn_面朝大海.ControlTheme = skinThemeBlueSea4;
      this.btn_面朝大海.ControlThemeEnum = Y.Core.WinForm.SKin.EnumTheme.BlueSea;
      this.btn_面朝大海.Name = "btn_面朝大海";
      this.btn_面朝大海.Tag = "1";
      this.btn_面朝大海.UseVisualStyleBackColor = true;
      // 
      // SkinManageForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CaptionHeight = 0;
      this.ControlBox = false;
      this.Controls.Add(this.btn_面朝大海);
      this.Controls.Add(this.btn_Close);
      this.Controls.Add(this.ckb_Optickty);
      this.Controls.Add(this.pib_backgimg);
      this.Controls.Add(this.lb_opactity);
      this.Controls.Add(this.btn_落日黄昏);
      this.Controls.Add(this.trackOpacity);
      this.Controls.Add(this.btn_似水年华);
      this.Controls.Add(this.btn_天使之吻);
      this.Controls.Add(this.btn_Defult);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SkinManageForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pib_backgimg)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Control.ButtonEx btn_Defult;
    private Control.ButtonEx btn_天使之吻;
    private Control.ButtonEx btn_似水年华;
    private System.Windows.Forms.TrackBar trackOpacity;
    private Control.ButtonEx btn_落日黄昏;
    private Control.LabelEx lb_opactity;
    private System.Windows.Forms.PictureBox pib_backgimg;
    private Control.CheckBoxEx ckb_Optickty;
    private Control.ButtonEx btn_Close;
    private Control.ButtonEx btn_面朝大海;
  }
}