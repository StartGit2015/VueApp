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
  public partial class LogForm : BaseForm
  {
    private RichTextBox richTextBox;

    protected override CreateParams CreateParams {
     get
      {
        var cp = base.CreateParams;
        cp.ExStyle |= (int)Enums.WindowStyleEx.WS_EX_NOACTIVATE | (int)Enums.WindowStyleEx.WS_EX_TOPMOST;
        return cp;
      }
    }

    public LogForm()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      this.richTextBox = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // richTextBox
      // 
      this.richTextBox.BackColor = System.Drawing.SystemColors.InfoText;
      this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richTextBox.ForeColor = System.Drawing.Color.White;
      this.richTextBox.Location = new System.Drawing.Point(3, 10);
      this.richTextBox.Name = "richTextBox";
      this.richTextBox.Size = new System.Drawing.Size(224, 418);
      this.richTextBox.TabIndex = 0;
      this.richTextBox.Text = "";
      // 
      // LogForm
      // 
      this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.CaptionHeight = 15;
      this.ClientSize = new System.Drawing.Size(230, 431);
      this.ControlBox = false;
      this.Controls.Add(this.richTextBox);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LogForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.TopMost = true;
      this.TransparencyKey = System.Drawing.Color.Transparent;
      this.ResumeLayout(false);

    }

    public void ShowLog(string message)
    {
      richTextBox.Text += "\r\n";
      richTextBox.Text += DateTime.Now.ToString() + " :" + message;
      
      richTextBox.Select(richTextBox.TextLength, 0);
      richTextBox.ScrollToCaret();
    }
  }
}
