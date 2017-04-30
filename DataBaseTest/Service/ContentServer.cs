using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Core;
using Y.Core.Interface;
using DataBaseTest.Model;

namespace DataBaseTest
{
    //内容管理
    public class ContentServer : ServiceBase<Content>, IDao<Content>
    {
        public ContentServer(string con= null) :base(con)
        {
        }
    }
}
