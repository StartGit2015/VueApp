using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTest.Model
{
    //内容管理
    public class Content
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 父类 ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [DefaultValue("未分类")]
        public string TypeName { get; set; }

        /// <summary>
        /// 标题名称
        /// </summary>
        public string TitleName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string ContentValue { get; set; }


        public DateTime CreateDate { get; set; }

        public int IsDelete { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }
    }
}
