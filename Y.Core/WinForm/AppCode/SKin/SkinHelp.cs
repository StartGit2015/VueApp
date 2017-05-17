using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Reflection;
using System.Drawing;

namespace Y.Core.WinForm.SKin
{
    public abstract class SkinHelp
    {
        private static SkinColor _currentSkinColor = SkinColor.Default;
        private static BackgroundStripe _currentStripe = BackgroundStripe.Default;
        private static Assembly _assemblyWinUI = null;
        private static Bitmap drawButton = null;
        private static Bitmap scrollbarButton = null;
        private static Color defalutborder = ControlBorderBackColor;
        private static Color defaultGridviewUpColor = Color.YellowGreen;
        private static Color defaultcontextMenuColor;

        public static Color DefaultcontextMenuColor
        {
            get
            {
                Bitmap bitmap = new Bitmap(bxyztSkin.Properties.Resources.borderbm);
                return bitmap.GetPixel(1, 3);
            }
        }

        public static Color DefaultGridviewUpColor
        {
            get { return SkinHelp.defaultGridviewUpColor; }
            set { SkinHelp.defaultGridviewUpColor = value; }
        }

        public static Color Defalutborder
        {
            get { return SkinHelp.defalutborder; }
            set { SkinHelp.defalutborder = value; }
        }

        public static Assembly AssemblyWinUI
        {
            get
            {
                if (_assemblyWinUI == null)
                {
                    _assemblyWinUI = Assembly.Load("bxyztSkin");
                }

                return _assemblyWinUI;
            }
        }

        public static SkinColor CurrentSkinColor
        {
            get { return _currentSkinColor; }
            set { _currentSkinColor = value; }
        }

        public static BackgroundStripe CurrentBackgroundStripe
        {
            get { return _currentStripe; }
            set { _currentStripe = value; }
        }

        public static Color ControlBorderBackColor
        {
            get
            {
                Bitmap bitmap = new Bitmap(bxyztSkin.Properties.Resources.borderbm);
                return bitmap.GetPixel(1, 3);
            }
        }

        public static Color FontColor
        {
            get { return Color.FromArgb(22, 61, 101); }
        }

        public static Bitmap ScrollBarButton
        {
            get
            {
                if (scrollbarButton == null)
                {
                    scrollbarButton = new Bitmap(bxyztSkin.Properties.Resources.scroll);
                }
                return scrollbarButton;
            }
        }

        public static Image ScrollBarUpButton
        {
            get { return ScrollBarButton.Clone(new Rectangle(0, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Bitmap DrawButton
        {
            get
            {
                if (drawButton == null)
                {
                    drawButton = new Bitmap(bxyztSkin.Properties.Resources.arrow);
                }
                return drawButton;
            }
        }

        public static Image NomalDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(0, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Image MouseDownDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(16, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Image MouseMoveDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(32, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Image NotEnableDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(48, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        #region ChangeSkinColor

        #endregion

        #region FlushMemory
        public static void GarbageCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public static void FlushMemory()
        {
            GarbageCollect();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Win32.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        #region Suspend / Resume Redraw

        internal static void SuspendRedraw(Control control)
        {
            if (!control.IsHandleCreated) return;

            IntPtr hWnd = control.Handle;
            IntPtr eventMask = IntPtr.Zero;

            // Stop redrawing:
            Win32.SendMessage(hWnd, Win32.WM_SETREDRAW, 0, 0);

            // Stop sending of events:
            Win32.SendMessage(hWnd, Win32.EM_GETEVENTMASK, 0, 0);
        }

        internal static void ResumeRedraw(Control control)
        {
            if (!control.IsHandleCreated) return;

            IntPtr hWnd = control.Handle;
            IntPtr eventMask = IntPtr.Zero;

            // turn on events
            Win32.SendMessage(hWnd, Win32.EM_SETEVENTMASK, 0, eventMask.ToInt32());

            // turn on redrawing
            Win32.SendMessage(hWnd, Win32.WM_SETREDRAW, 1, 0);

            control.Invalidate(true);
        }

        internal static void LockWindowUpdate(Form form, bool lockUpdate)
        {
            if (lockUpdate)
            {
                Win32.LockWindowUpdate(form.Handle);
            }
            else
            {
                Win32.LockWindowUpdate(IntPtr.Zero);
                form.Invalidate(true);
                form.Update();
            }
        }
        #endregion
        /// <summary>
            /// 修改控件或窗体的边框，例如Textbox或是Form窗体
            /// </summary>
            /// <param name="m">消息</param>
            /// <param name="control">控件对象</param>
            /// <param name="Nwidth">边框像素</param>
            /// <param name="objcolor">边框颜色</param>
        internal static void ResetBorderColor(Message m, Control control, int Nwidth, Color objcolor)
        {
            //根据颜色和边框像素取得一条线
            System.Drawing.Pen pen = pen = new Pen(objcolor, Nwidth);
            //得到当前的句柄
            IntPtr hDC = Win32.GetWindowDC(m.HWnd);
            if (hDC.ToInt32() == 0)
            {
                return;
            }

            if (pen != null)
            {
                //绘制边框 
                System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawRectangle(pen, 0, 0, control.Width - Nwidth, control.Height - Nwidth);
                pen.Dispose();
            }

            //释放 
            Win32.ReleaseDC(m.HWnd, hDC);
        }
    }

    public enum SkinColor
    {
        Default,
        草莓,
        橘子,
        青草,
        灰蓝,
        紫罗兰,
        巧克力,
        OFFICE,
        Undefault
    }

    public enum BackgroundStripe
    {
        Default,
        淡淡墨绿,
        芙蓉轻粉,
        荷叶嫩绿,
        橘黄雪花,
        清雅幽兰,
        空灵淡蓝,
        柔和雅灰,
        腊梅飘香
    }
}
