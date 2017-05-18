using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Core.WinForm.Control;
using Y.Core.WinForm.SKin;

namespace Y.Core.WinForm.FormEx
{
  public partial class SkinManageForm : BaseForm
  {
    public SkinManageForm()
    {
      InitializeComponent();
      BindTheme();
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    private void BindTheme()
    {
      ckb_Optickty.Checked = SkinManager.CurrentSkin.BackGroundImageEnable;
      pib_backgimg.BackgroundImage = SkinManager.CurrentSkin.BackGroundImage;
      trackOpacity.Value = (int)(SkinManager.CurrentSkin.BackGroundImageOpacity * 100);

      foreach (var item in Controls)
      {
        if (item is Button )
        {
          var btn = (ButtonEx)item;
          if (btn.Tag == null) continue;
          var them = btn.Tag.ToString().ToInt();
          var sKinThem = SkinManager.GetSkinTeme(them.ToEnumByValue<EnumTheme>());
          btn.BackgroundImage = sKinThem.BackGroundImage;
          btn.Click += (o, e) =>
          {
            ApplyTheme();
            SaveTheme(btn);
          };

        }
      }
    }
    /// <summary>
    /// 设置皮肤
    /// </summary>
    private void ApplyTheme()
    {
      foreach (Form item in Application.OpenForms)
      {
        item.Invalidate();
      }
    }

    /// <summary>
    /// 保存主题
    /// </summary>
    private void SaveTheme(Button btn)
    {
      int themEmnu = btn.Tag.ToString().ToInt();
      var img= (Bitmap)pib_backgimg.BackgroundImage;
      SkinManager.SettingSkinTeme(themEmnu.ToEnumByValue<EnumTheme>());
      if (img != null) SkinManager.CurrentSkin.BackGroundImageEnable = ckb_Optickty.Checked;
      SkinManager.CurrentSkin.BackGroundImageOpacity = trackOpacity.Value / 100F;
      if(img != null)SkinManager.CurrentSkin.BackGroundImage = (Bitmap)pib_backgimg.BackgroundImage;
      SkinManager.Save();
    }
    /// <summary>
    /// 关闭
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btn_Close_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void pib_backgimg_Click(object sender, EventArgs e)
    {
      OpenFileDialog fd = new OpenFileDialog();
      fd.Filter = "(所有文件)|*.*|(jpg图片)|*.jpg|(jpeg)|*.jpeg|(gif图片)|*.gif";
      fd.Multiselect = false;
      if (fd.ShowDialog() == DialogResult.OK)
      {
        pib_backgimg.BackgroundImage = Image.FromFile(fd.FileName);
      }
    }
  }
}
