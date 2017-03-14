using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathWatch
{
    /// <summary>
    /// 要移动的文件信息
    /// </summary>
    [Serializable]
    public  class FileMoveInfor
    {
        /// <summary>
        /// 本地目录
        /// </summary>
        public string LocalFile { get; set; }
        /// <summary>
        /// 目标目录
        /// </summary>
        public string TargetFile { get; set; }

        public bool IsCheck { get; set; }
    }
}
