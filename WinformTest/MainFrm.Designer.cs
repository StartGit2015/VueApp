namespace WinformTest
{
  partial class MainFrm
  {
    /// <summary>
    /// 必需的设计器变量。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 清理所有正在使用的资源。
    /// </summary>
    /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows 窗体设计器生成的代码

    /// <summary>
    /// 设计器支持所需的方法 - 不要修改
    /// 使用代码编辑器修改此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
      Y.Core.WinForm.SKin.SkinThemeSunsetRed skinThemeSunsetRed1 = new Y.Core.WinForm.SKin.SkinThemeSunsetRed();
      Y.Core.WinForm.SKin.SkinThemeDefault skinThemeDefault1 = new Y.Core.WinForm.SKin.SkinThemeDefault();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
      this.tabControlEx1 = new Y.Core.WinForm.Control.TabControlEx();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.buttonEx1 = new Y.Core.WinForm.Control.ButtonEx();
      this.textBoxEx1 = new Y.Core.WinForm.Control.ControlEx.TextBoxEx();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tabControlEx1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControlEx1
      // 
      this.tabControlEx1.BaseTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
      this.tabControlEx1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
      this.tabControlEx1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.tabControlEx1.CaptionForceColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.tabControlEx1.CheckedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
      this.tabControlEx1.Controls.Add(this.tabPage1);
      this.tabControlEx1.Controls.Add(this.tabPage2);
      skinThemeSunsetRed1.BackGroundImage = null;
      skinThemeSunsetRed1.BackGroundImageEnable = false;
      skinThemeSunsetRed1.BackGroundImageOpacity = 0.8F;
      skinThemeSunsetRed1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeSunsetRed1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
      skinThemeSunsetRed1.CaptionFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(5)))), ((int)(((byte)(255)))));
      skinThemeSunsetRed1.ControlBoxFlagColor = System.Drawing.Color.White;
      skinThemeSunsetRed1.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
      skinThemeSunsetRed1.OuterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(3)))), ((int)(((byte)(123)))));
      skinThemeSunsetRed1.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeSunsetRed1.ThemeName = "夕阳西下，明月天涯";
      skinThemeSunsetRed1.ThemeStyle = Y.Core.WinForm.SKin.EnumTheme.SunsetRed;
      skinThemeSunsetRed1.UselessColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
      this.tabControlEx1.ControlTheme = skinThemeSunsetRed1;
      this.tabControlEx1.ControlThemeEnum = Y.Core.WinForm.SKin.EnumTheme.SunsetRed;
      this.tabControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControlEx1.HeightLightTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
      this.tabControlEx1.Location = new System.Drawing.Point(1, 35);
      this.tabControlEx1.Margin = new System.Windows.Forms.Padding(4);
      this.tabControlEx1.Name = "tabControlEx1";
      this.tabControlEx1.SelectedIndex = 0;
      this.tabControlEx1.Size = new System.Drawing.Size(991, 548);
      this.tabControlEx1.TabCornerRadius = 3;
      this.tabControlEx1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.buttonEx1);
      this.tabPage1.Controls.Add(this.textBoxEx1);
      this.tabPage1.Location = new System.Drawing.Point(4, 33);
      this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
      this.tabPage1.Size = new System.Drawing.Size(983, 511);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "选项卡一";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // buttonEx1
      // 
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
      this.buttonEx1.ControlTheme = skinThemeDefault1;
      this.buttonEx1.ControlThemeEnum = Y.Core.WinForm.SKin.EnumTheme.Default;
      this.buttonEx1.Image = null;
      this.buttonEx1.Location = new System.Drawing.Point(248, 22);
      this.buttonEx1.Margin = new System.Windows.Forms.Padding(4);
      this.buttonEx1.Name = "buttonEx1";
      this.buttonEx1.Size = new System.Drawing.Size(104, 38);
      this.buttonEx1.TabIndex = 1;
      this.buttonEx1.Text = "buttonEx1";
      this.buttonEx1.UseVisualStyleBackColor = true;
      // 
      // textBoxEx1
      // 
      this.textBoxEx1.BackColor = System.Drawing.Color.Transparent;
      this.textBoxEx1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
      this.textBoxEx1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.textBoxEx1.ForeColor = System.Drawing.SystemColors.WindowText;
      this.textBoxEx1.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
      this.textBoxEx1.Image = null;
      this.textBoxEx1.ImageSize = new System.Drawing.Size(0, 0);
      this.textBoxEx1.Location = new System.Drawing.Point(8, 25);
      this.textBoxEx1.Margin = new System.Windows.Forms.Padding(4);
      this.textBoxEx1.Name = "textBoxEx1";
      this.textBoxEx1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.textBoxEx1.PasswordChar = '\0';
      this.textBoxEx1.Size = new System.Drawing.Size(232, 35);
      this.textBoxEx1.TabIndex = 0;
      this.textBoxEx1.Text = "textBoxEx1";
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 33);
      this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
      this.tabPage2.Size = new System.Drawing.Size(983, 502);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "选项卡二第二个选项卡";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // MainFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BorderWidth = 1;
      this.CapitionLogo = global::WinformTest.Properties.Resources.task;
      this.CaptionHeight = 35;
      this.ClientSize = new System.Drawing.Size(993, 584);
      this.ControlBoxSize = new System.Drawing.Size(32, 25);
      this.Controls.Add(this.tabControlEx1);
      this.CornerRadius = 0;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.IsMdiContainer = true;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainFrm";
      this.Text = "测试窗口";
      this.OnRibbonButtonClick += new System.EventHandler<Y.Core.WinForm.Utility.BtnEventArgs>(this.MainFrm_OnRibbonButtonClick);
      this.tabControlEx1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Y.Core.WinForm.Control.TabControlEx tabControlEx1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private Y.Core.WinForm.Control.ControlEx.TextBoxEx textBoxEx1;
    private Y.Core.WinForm.Control.ButtonEx buttonEx1;
  }
}

