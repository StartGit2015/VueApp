using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Core.ComFunc;

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
      this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, 0);
    }

    private void InitializeComponent()
    {
      this.richTextBox = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // richTextBox
      // 
      this.richTextBox.BackColor = System.Drawing.Color.Black;
      this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richTextBox.ForeColor = System.Drawing.Color.White;
      this.richTextBox.Location = new System.Drawing.Point(3, 25);
      this.richTextBox.Name = "richTextBox";
      this.richTextBox.Size = new System.Drawing.Size(360, 1014);
      this.richTextBox.TabIndex = 0;
      this.richTextBox.Text = "";
      // 
      // LogForm
      // 
      this.BackColor = System.Drawing.Color.Black;
      this.CaptionHeight = 25;
      this.ClientSize = new System.Drawing.Size(366, 1042);
      this.Controls.Add(this.richTextBox);
      this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LogForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "日志记录";
      this.TopMost = true;
      this.TransparencyKey = System.Drawing.SystemColors.ActiveCaption;
      this.ResumeLayout(false);

    }

    public void ShowLog(string message)
    {
      var line = richTextBox.Lines;

      if(line.Length > 100)
      {
        string[] newLine = new string[line.Length / 2];
        Array.Copy(line, line.Length / 2, newLine, 0, line.Length / 2);
        richTextBox.Lines = newLine;
      }
      var lenth = richTextBox.TextLength;
      richTextBox.Text += DateTime.Now.ToString() + " :" + message + "\r\n";
      
      richTextBox.Select(lenth, 0);
      richTextBox.ScrollToCaret();
    }
  }
}
