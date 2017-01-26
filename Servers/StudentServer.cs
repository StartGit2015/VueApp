using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;
using Y.Core;
using Y.Core.Interface;

namespace Servers
{
    public class StudentServer : ServiceBase<Student> ,IDao<Student> 
    {
    }
}
