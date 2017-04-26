using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueEntity;
using Y.Core;
using Y.Core.Interface;

namespace VueServer
{
    public class UserVeliDataServer: ServiceBase<UserVeliData>, IDao<UserVeliData>
    {
    }
}
