using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Core.Model
{
  /// <summary>
  /// 分页模型
  /// </summary>
  public class PageInfor
  {
    /// <summary>
    /// 总页数
    /// </summary>
    public int totalPage { get { return 1; } set { } }
    /// <summary>
    /// 当前页
    /// </summary>
    public int pageNumber { get { return 1; } set { } }

    /// <summary>
    /// 当前数据集合
    /// </summary>
    public IList list { get; set; }

    /// <summary>
    /// 查询参数
    /// </summary>
    public object queryParam { get; set; }
  }
}
