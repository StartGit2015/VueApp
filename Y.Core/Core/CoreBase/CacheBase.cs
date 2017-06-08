using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Y.Core.Interface;
using Y.Core.Dao;
using System.Web;
using System.Reflection;
using System.Web.Caching;

namespace Y.Core
{
  /// <summary>
  /// HttpRuntime.Cache缓存管理
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class CacheBase
    {
    private static readonly Object _locker = new object();
    /// <summary>
    /// 获取缓存对象
    /// </summary>
    /// <typeparam name="T">缓存实体对象</typeparam>
    /// <param name="cacheKey">缓存关键字</param>
    /// <param name="action">实体数据获取方法</param>
    /// <param name="cacheDuration">缓存时间(分钟)</param>
    /// <param name="objs">实体数据获取参 </param>
    /// <returns>参数T </returns>
    public static T GetCacheData<T>(string cacheKey,Action action, int cacheDuration, params object [] objs)
    {

      if (HttpRuntime.Cache.Get(cacheKey) == null)
      {
        lock (_locker)
        {
          string assemblyName = action.Target.GetType().Assembly.FullName;
          string typeName = action.Target.GetType().FullName;
          object instance = Assembly.Load(assemblyName).CreateInstance(typeName);
          MethodInfo methodInfo = action.Method;
          T result = (T)methodInfo.Invoke(instance, objs);
          HttpRuntime.Cache.Add(cacheKey, result, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(cacheDuration), CacheItemPriority.NotRemovable, null);
        }
      }
      return (T)HttpRuntime.Cache[cacheKey];
    }
    
  }
}
