using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyEntity
{
    /// <summary>
    /// 消费明细类
    /// </summary>
    public class MoneyDetail
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal Money { get; set; }
    }
}
