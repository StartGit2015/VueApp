using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Y.Core.Interface;
using SqlSugarRepository;
using System.Configuration;
using System.Data;

namespace Y.Core.Dao
{
    public class SqlSugarDao<TEntity> :IDisposable, IDao<TEntity> where TEntity : class,new()
    {
        /// <summary>
        /// 数据访问对象
        /// </summary>
        public ISqlSugarClient db = null;

        /// <summary>
        /// 是否书写日志
        /// </summary>
        public bool IsWriteLog { get => db.IsEnableLogEvent; set => db.IsEnableLogEvent = value; }
        /// <summary>
        /// 构造函数 创建DB实例
        /// </summary>
        ///<param name="constr">数据库连接</param>
        public SqlSugarDao(string conStr = "DefaultConnection")
        {
            var connect = ConfigurationManager.ConnectionStrings[conStr].ConnectionString;
            var providerName = ConfigurationManager.ConnectionStrings[conStr].ProviderName;

            var DbType = SqlSugarRepository.DbType.SqlServer;
            switch (providerName)
            {
                case "SqlServer":
                    DbType = SqlSugarRepository.DbType.SqlServer;
                    break;
                case "Sqlite":
                    DbType = SqlSugarRepository.DbType.Sqlite;
                    break;
                case "Oracle":
                    DbType = SqlSugarRepository.DbType.Oracle;
                    break;
                case "MySql":
                    DbType = SqlSugarRepository.DbType.MySql;
                    break;
                default:
                    throw new Exception("未在配置文件中指名数据库类型！");
            }
            db = DbRepository.GetInstance(DbType, connect);
        }
        
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
            return db.Delete(model);
        }
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public bool Deletes(List<TEntity> entitys)
        {
            return db.Delete(entitys);
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

        public IEnumerable<TEntity> QueryList(Expression<Func<TEntity, bool>> select)
        {
            return db.Queryable<TEntity>().Where<TEntity>(select).ToList();
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

        public int ExecuteCommand(string sql)
        {
            return db.ExecuteCommand(sql);
        }

        public List<TEntity> ExecuteCommand<TEntity>(string sql)
        {
            return db.SqlQuery<TEntity>(sql);
        }
    }
}
