using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 核心基类接口
/// </summary>
namespace Y.Core.Interface
{
    /// <summary>
    /// 数据访问层的基础接口
    /// </summary>
    /// <typeparam name="TEntity">操作对象</typeparam>
    public interface IDao<TEntity>:IDaoTransection,IDependency where TEntity : class
    {
        
        /// <summary>
        /// 日志对象属性，设置后才能自动写日志
        /// </summary>
        ILog Log { get; set; }
        /// <summary>
        /// 通过主键返回对象
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        TEntity Get(object id);

        //IDaoQuery<TEntity> GetDaoQuery();

        /// <summary>
        /// 通过指定主键返回对象
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        TEntity Get(Expression<Func<TEntity, bool>> func);


        /// <summary>
        /// 插入对象
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        object Insert(TEntity model);


        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="list">对象集合</param>
        void Insert(List<TEntity> list);

        /// <summary>
        /// 更新对象
        /// </summary>
        void Update(TEntity model);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="model">实体</param>
        bool Delete(TEntity model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="func"></param>
        bool Delete(Expression<Func<TEntity, bool>> func);

        /// <summary>
        /// 批量删除（主键名必须为ID）
        /// </summary>
        /// <param name="ids">主键集合，用","号格开</param>
        bool Deletes(List<TEntity> entitys);

        /// <summary>
        /// 对象是否存储在
        /// </summary>
        /// <param name="id">对象id</param>
        /// <returns></returns>
        bool Exist(object id);
        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> QueryAll();
        /// <summary>
        /// 获取指定列最大值
        /// </summary>
        /// <param name="field">列名称</param>
        /// <returns></returns>
        int GetMaxValue(Expression<Func<TEntity, int>> selector);

        /// <summary>
        /// 获取数据行数
        /// </summary>
        /// <param name="spec">条件表达式</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> spec);
        /// <summary>
        /// 是否写操作日志
        /// </summary>
        bool IsWriteLog { get; set; }
        /// <summary>
        /// 最后保存事物中的对象日志
        /// </summary>
        void WriteTransLog();
    }
}
