using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Core.Web
{
    /// <summary>
    /// 树形导航菜单 数据模型
    /// </summary>
    public class NavTree
    {
        /// <summary>
        /// ID号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// data-id id值
        /// </summary>
        public string DataId {get;set;}
        /// <summary>
        /// data-Url  菜单Url地址
        /// </summary>
        public string DataUrl { get; set; }
        /// <summary>
        /// data-Frame  是否需要在Frame下打开？
        /// </summary>
        public string DataFrame { get { return "false"; } set { } }
        /// <summary>
        /// IsExpend  是否展开
        /// </summary>
        public bool IsExpend { get { return false; } set { } }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<NavTree> ChildNav { get; set; }
    }
}
