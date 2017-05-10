using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Y.Core.ComFunc
{
    /// <summary>
	///   一个强类型的资源类，用于查找本地化的字符串等。
	/// </summary>
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
    internal class Resources
    {
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                bool flag = Resources.resourceMan == null;
                if (flag)
                {
                    ResourceManager resourceManager = new ResourceManager("CFW.INF.WinForm.Properties.Resources", typeof(Resources).Assembly);
                    Resources.resourceMan = resourceManager;
                }
                return Resources.resourceMan;
            }
        }
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return Resources.resourceCulture;
            }
            set
            {
                Resources.resourceCulture = value;
            }
        }
        /// <summary>
        ///   查找 System.Drawing.Bitmap 类型的本地化资源。
        /// </summary>
        internal static Bitmap first
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("first", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }
        /// <summary>
        ///   查找 System.Byte[] 类型的本地化资源。
        /// </summary>
        internal static byte[] fontawesome_webfont
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("fontawesome_webfont", Resources.resourceCulture);
                return (byte[])@object;
            }
        }
        /// <summary>
        ///   查找 System.Drawing.Bitmap 类型的本地化资源。
        /// </summary>
        internal static Bitmap last
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("last", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }
        /// <summary>
        ///   查找 System.Drawing.Bitmap 类型的本地化资源。
        /// </summary>
        internal static Bitmap next
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("next", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }
        /// <summary>
        ///   查找 System.Drawing.Bitmap 类型的本地化资源。
        /// </summary>
        internal static Bitmap prev
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("prev", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }
        internal Resources()
        {
        }
    }
}
