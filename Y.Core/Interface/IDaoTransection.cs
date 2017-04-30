using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Core.Interface
{
    /// <summary>
    /// 数据访问层事物基础接口
    /// </summary>
    public interface IDaoTransection 
    {
        void BeginTran();

        void CommitTran();

        void RollbackTran();
    }
}
