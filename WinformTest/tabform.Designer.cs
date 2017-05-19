namespace WinformTest
{
  partial class tabform
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
      Y.Core.WinForm.SKin.SkinThemeDefault skinThemeDefault2 = new Y.Core.WinForm.SKin.SkinThemeDefault();
      this.tabControlEx1 = new Y.Core.WinForm.Control.TabControlEx();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.buttonEx1 = new Y.Core.WinForm.Control.ButtonEx();
      this.comboBoxEx1 = new CFW.WinFormBase.Controls.ComboBoxEx();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.textBoxEx1 = new Y.Core.WinForm.Controls.TextBoxEx();
      this.controlVerify1 = new CFW.WinFormBase.Controls.ControlVerify();
      this.tabControlEx1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControlEx1
      // 
      this.tabControlEx1.BaseTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
      this.tabControlEx1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
      this.tabControlEx1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.tabControlEx1.CheckedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
      this.tabControlEx1.Controls.Add(this.tabPage1);
      this.tabControlEx1.Controls.Add(this.tabPage2);
      skinThemeDefault2.BackGroundImage = null;
      skinThemeDefault2.BackGroundImageEnable = false;
      skinThemeDefault2.BackGroundImageOpacity = 0.8F;
      skinThemeDefault2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeDefault2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
      skinThemeDefault2.CaptionFontColor = System.Drawing.Color.Black;
      skinThemeDefault2.ControlBoxFlagColor = System.Drawing.Color.White;
      skinThemeDefault2.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
      skinThemeDefault2.OuterBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(182)))), ((int)(((byte)(240)))));
      skinThemeDefault2.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
      skinThemeDefault2.ThemeName = "系统默认";
      skinThemeDefault2.ThemeStyle = Y.Core.WinForm.SKin.EnumTheme.Default;
      skinThemeDefault2.UselessColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
      this.tabControlEx1.ControlTheme = skinThemeDefault2;
      this.tabControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControlEx1.HeightLightTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
      this.tabControlEx1.Location = new System.Drawing.Point(3, 27);
      this.tabControlEx1.Name = "tabControlEx1";
      this.tabControlEx1.SelectedIndex = 0;
      this.tabControlEx1.Size = new System.Drawing.Size(781, 497);
      this.tabControlEx1.TabCornerRadius = 3;
      this.tabControlEx1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.buttonEx1);
      this.tabPage1.Controls.Add(this.comboBoxEx1);
      this.tabPage1.Location = new System.Drawing.Point(4, 33);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(773, 460);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // buttonEx1
      // 
      this.buttonEx1.ControlTheme = skinThemeDefault2;
      this.buttonEx1.ControlThemeEnum = Y.Core.WinForm.SKin.EnumTheme.Default;
      this.buttonEx1.Image = null;
      this.buttonEx1.Location = new System.Drawing.Point(204, 61);
      this.buttonEx1.Name = "buttonEx1";
      this.buttonEx1.Size = new System.Drawing.Size(182, 69);
      this.buttonEx1.TabIndex = 1;
      this.buttonEx1.Text = "buttonEx1";
      this.buttonEx1.UseVisualStyleBackColor = true;
      // 
      // comboBoxEx1
      // 
      this.comboBoxEx1.BackColor = System.Drawing.Color.Transparent;
      this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
      this.comboBoxEx1.FormattingEnabled = true;
      this.comboBoxEx1.Location = new System.Drawing.Point(57, 61);
      this.comboBoxEx1.Name = "comboBoxEx1";
      this.comboBoxEx1.Size = new System.Drawing.Size(121, 26);
      this.comboBoxEx1.TabIndex = 0;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.textBoxEx1);
      this.tabPage2.Location = new System.Drawing.Point(4, 33);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(773, 460);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // textBoxEx1
      // 
      this.textBoxEx1.BackColor = System.Drawing.Color.Transparent;
      this.textBoxEx1.Location = new System.Drawing.Point(80, 31);
      this.textBoxEx1.Name = "textBoxEx1";
      this.textBoxEx1.RButtonIcon = "";
      this.textBoxEx1.Size = new System.Drawing.Size(106, 25);
      this.textBoxEx1.TabIndex = 0;
      this.textBoxEx1.TextValue = "";
      // 
      // tabform
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(787, 527);
      this.Controls.Add(this.tabControlEx1);
      this.Name = "tabform";
      this.Text = "选项卡窗口";
      this.tabControlEx1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private Y.Core.WinForm.Control.TabControlEx tabControlEx1;
    private System.Windows.Forms.TabPage tabPage1;
    private Y.Core.WinForm.Control.ButtonEx buttonEx1;
    private CFW.WinFormBase.Controls.ComboBoxEx comboBoxEx1;
    private System.Windows.Forms.TabPage tabPage2;
    private Y.Core.WinForm.Controls.TextBoxEx textBoxEx1;
    private CFW.WinFormBase.Controls.ControlVerify controlVerify1;
  }
}