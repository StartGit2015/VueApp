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
        public static T GetCache<T>(string cacheKey,Action action, int cacheDuration, params object [] objs)
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
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="cacheObj"></param>
        public static void SetCache(string cacheKey,object cacheObj)
        {
            HttpRuntime.Cache[cacheKey] = cacheObj;
        }
        /// <summary>
        /// 设置缓存 带失效时间
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="cacheObj"></param>
        /// <param name="Timeout">失效时间</param>
        public static void SetCache(string cacheKey, object cacheObj, TimeSpan Timeout)
        {
            HttpRuntime.Cache.Insert(cacheKey, cacheObj, null, DateTime.MaxValue, Timeout,CacheItemPriority.NotRemovable, null);
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string cacheKey)
        {
            return HttpRuntime.Cache[cacheKey];
        }
        /// <summary>
        /// 移除指定缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        public static void RemoveCache(string cacheKey)
        {
           if (HttpRuntime.Cache.Get(cacheKey) == null)
           {
                return;
           }
           HttpRuntime.Cache.Remove(cacheKey);
        }
  }
}
