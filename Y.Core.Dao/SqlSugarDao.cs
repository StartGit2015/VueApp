using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Y.Core.Interface;
using SqlSugarRepository;
using System.Configuration;

namespace Y.Core.Dao
{
    public class SqlSugarDao<TEntity> :IDisposable, IDao<TEntity> where TEntity : class,new()
    {
        /// <summary>
        /// 构造函数 创建DB实例
        /// </summary>
        public SqlSugarDao()
        {
            var connect = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var DbType = SqlSugarRepository.DbType.SqlServer;
            db = DbRepository.GetInstance(DbType, connect);
        }
        /// <summary>
        /// 数据访问对象
        /// </summary>
        public ISqlSugarClient db = null;

        /// <summary>
        /// 是否书写日志
        /// </summary>
        public bool IsWriteLog { get => db.IsEnableLogEvent; set => db.IsEnableLogEvent=value; }
        public ILog Log { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count(Expression<Func<TEntity, bool>> spec)
        {
            return db.Queryable<TEntity>().Where(spec).Count();
        }
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public bool Delete(Expression<Func<TEntity, bool>> func)
        {
            return db.Delete<TEntity>(func);
        }
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public bool Delete(TEntity model)
        {
            return db.Delete<TEntity>(model);
        }
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public bool Deletes(List<TEntity> entitys)
        {
            return db.Delete<TEntity>(entitys);
        }

        public bool Exist(object id)
        {
            return db.Queryable<TEntity>().Where(String.Format("ID = {0}",id)).Count() > 0 ? true : false;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> func)
        {
            return db.Queryable<TEntity>().Where(func).SingleOrDefault();
        }

        public TEntity Get(object id)
        {
           return db.Queryable<TEntity>().Where(String.Format("ID = {0}", id)).SingleOrDefault();
        }

        public int GetMaxValue(Expression<Func<TEntity, int>> selector)
        {
            return db.Queryable<TEntity>().Select(selector).ToList().Max();
        }

        public void Insert(List<TEntity> list)
        {
            db.InsertRange(list);
        }

        public object Insert(TEntity model)
        {
            return db.Insert(model);
        }

        public IEnumerable<TEntity> QueryAll()
        {
            return db.Queryable<TEntity>().ToList();
        }

        public void Update(TEntity model)
        {
            db.Update(model);
        }
        /// <summary>
        /// 记录及监控日志
        /// </summary>
        public void WriteTransLog()
        {
            db.IsEnableLogEvent = true;
            db.LogEventStarting = (sql, parms) =>
            {
                Console.WriteLine(sql);
            };
        }

        /// <summary>
        /// 释放对象
        /// </summary>
        public void Dispose()
        {
            if(db!=null)
            {
                db.Dispose();
            }
        }

        public void BeginTran()
        {
            db.BeginTran();
        }

        public void CommitTran()
        {
            db.CommitTran();
        }

        public void RollbackTran()
        {
            db.RollbackTran();
        }
    }
}
