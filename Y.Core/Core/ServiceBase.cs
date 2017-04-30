using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Y.Core.Interface;
using Y.Core.Dao;

namespace Y.Core
{
    public class ServiceBase<T> :IDao<T> where T : class, new()
    {
        private IDao<T> dao;
        public IDao<T> Dao { get { return dao; } set { dao = value; } }

        //无参构造函数
        public ServiceBase(string conStr=null)
        {
           //dao = IOCBase.GetInstance<IDao<T>>(true);
            dao = new SqlSugarDao<T>(conStr);
        }
        //可注入构造函数
        public ServiceBase(IDao<T> dao)
        {
            if(dao != null)
                this.dao = dao;
        }
        
        public bool IsWriteLog { get ; set; }
        public ILog Log { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count(Expression<Func<T, bool>> spec)
        {
            return dao.Count(spec);
        }

        public bool Delete(Expression<Func<T, bool>> func)
        {
            return dao.Delete(func);
        }

        public bool Delete(T model)
        {
            return dao.Delete(model);
        }

        public bool Deletes(List<T> entitys)
        {
            return dao.Deletes(entitys);
        }

        public bool Exist(object id)
        {

            return dao.Exist(id);
        }

        public T Get(Expression<Func<T, bool>> func)
        {
            return dao.Get(func);
        }

        public T Get(object id)
        {
            return dao.Get(id);
        }

        public int GetMaxValue(Expression<Func<T, int>> selector)
        {
            return dao.GetMaxValue(selector);
        }

        public void Insert(List<T> list)
        {
            dao.Insert(list);
        }

        public object Insert(T model)
        {
            return dao.Insert(model);
        }

        public IEnumerable<T> QueryList(Expression<Func<T, bool>> select)
        {
            return dao.QueryList(select);
        }

        public void Update(T model)
        {
            dao.Update(model);
        }

        public void WriteTransLog()
        {
            throw new NotImplementedException();
        }

        public void BeginTran()
        {
            dao.BeginTran();
        }

        public void CommitTran()
        {
            dao.CommitTran();
        }

        public void RollbackTran()
        {
            dao.RollbackTran();
        }
    }
}
