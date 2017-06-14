using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Core.WinForm.SKin;
using Y.Core.WinForm.Utility;

namespace Y.Core.WinForm.Control
{
    public partial class TreeViewEx : TreeView
    {
        /// <summary>
        /// 控件主题
        /// </summary>
        private SkinTheme _theme { get; set; }
        private EnumTheme _themeEnum;

        Color drawTextColor = Color.FromArgb(81, 81, 81);

        public TreeViewEx()
        {
            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.FullRowSelect = true;
            this.ItemHeight = 23;
            this.HotTracking = true;
            this.ShowLines = true;
            _theme = _theme ?? SkinManager.GetSkinTeme(_themeEnum);
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);
            Graphics g = e.Graphics;
            GDIHelper.InitializeGraphics(g);
            Rectangle rec = e.Bounds;

            if(e.Node.Level > 0)
            {
                rec = new Rectangle(12, e.Bounds.Y, e.Bounds.Width - 12, e.Bounds.Height);
            }
            //节点背景绘制
            if (e.Node.IsSelected)
            {
                GDIHelper.FillRectangle(g, rec, _theme.HeightLightControlColor);
            }
            else if ((e.State & TreeNodeStates.Hot) != 0)//|| currentMouseMoveNode == e.Node)
            {
                GDIHelper.FillRectangle(g, rec, _theme.FocusedControlColor);
            }
            else
            {
                GDIHelper.FillRectangle(g, rec, _theme.BaseColor);
            }

            //节点头图标绘制
            //if (e.Node.IsExpanded)
            //{
            //    e.Graphics.FillRectangle(Brushes.LightGreen, e.Node.Bounds.X - 12, e.Node.Bounds.Y + 6,12,6);
            //}
            //else if (e.Node.IsExpanded == false && e.Node.Nodes.Count > 0)
            //{
            //    e.Graphics.FillRectangle(Brushes.LightGreen, e.Node.Bounds.X - 12, e.Node.Bounds.Y + 6, 12, 6);
            //}

            //文本绘制
            using (Font foreFont = new Font(this.Font, FontStyle.Regular))
            using (Brush drawTextBrush = new SolidBrush(drawTextColor))
            {
                e.Graphics.DrawString(e.Node.Text, foreFont, drawTextBrush, e.Node.Bounds.Left + 5, e.Node.Bounds.Top + 5);
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            TreeNode tn = this.GetNodeAt(e.Location);
            //调整【点击测试区域】大小，包括图标
            Rectangle bounds = new Rectangle(tn.Bounds.Left - 12, tn.Bounds.Y, tn.Bounds.Width - 5, tn.Bounds.Height);
            if (tn != null && bounds.Contains(e.Location) == false)
            {
                if (tn.IsExpanded == false)
                    tn.Expand();
                else
                    tn.Collapse();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            TreeNode tn = this.GetNodeAt(e.Location);
            this.SelectedNode = tn;
        }

        TreeNode currentNode = null;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            TreeNode tn = this.GetNodeAt(e.Location);
            Graphics g = this.CreateGraphics();
            if (currentNode != tn)
            {
                //绘制当前节点的hover背景
                if (tn != null)
                    OnDrawNode(new DrawTreeNodeEventArgs(g, tn, new Rectangle(0, tn.Bounds.Y, this.Width, tn.Bounds.Height), TreeNodeStates.Hot));

                //取消之前hover的节点背景
                if (currentNode != null)
                    OnDrawNode(new DrawTreeNodeEventArgs(g, currentNode, new Rectangle(0, currentNode.Bounds.Y, this.Width, currentNode.Bounds.Height), TreeNodeStates.Default));
            }
            currentNode = tn;
            g.Dispose();
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //移出控件时取消Hover背景
            if (currentNode != null)
            {
                Graphics g = this.CreateGraphics();
                OnDrawNode(new DrawTreeNodeEventArgs(g, currentNode, new Rectangle(0, currentNode.Bounds.Y, this.Width, currentNode.Bounds.Height), TreeNodeStates.Default));
            }
        }
    }

}
