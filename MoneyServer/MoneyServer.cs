using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyEntity;

using Y.Core;
using Y.Core.Interface;

namespace MoneyServer
{
    /// <summary>
    /// 用户使用类
    /// </summary>
    public class UserHourseServer : ServiceBase<UserHourse>, IDao<UserHourse>
    {
    }
    /// <summary>
    /// 明细类
    /// </summary>
    public class MoneyDetailServer : ServiceBase<MoneyDetail>, IDao<MoneyDetail>
    {
    }
}
