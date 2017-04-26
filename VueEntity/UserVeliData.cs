using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueEntity
{
    /// <summary>
    /// 简易验证类
    /// </summary>
    public class UserVeliData
    {
        public int ID { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 验证内容
        /// </summary>
        public string VelidataValue { get; set; }
    }
}
