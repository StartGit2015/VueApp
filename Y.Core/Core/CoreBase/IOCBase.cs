using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Y.Core.Dao;
using Y.Core.Interface;

namespace Y.Core
{
    /// <summary>
    /// AutoFac IOC管理器
    /// </summary>
    public static class IOCBase
    {
        /// <summary>
        ///获取对象管理器
        /// </summary>
        private static IContainer InstanceContainer { get; set; }
        /// <summary>
        /// 获取对象注册器
        /// </summary>
        private static ContainerBuilder Builder { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public static void IOCBaseIni()
        {
            if(Builder == null)
            {
                Builder = new ContainerBuilder();
                CoreIOCReg();
                InstanceContainer = Builder.Build(Autofac.Builder.ContainerBuildOptions.None);  
            }
        }
        /// <summary>
        /// 核心容器注册 数据处理方法
        /// </summary>
        private static void CoreIOCReg()
        {
          Builder.RegisterGeneric(typeof(SqlSugarDao<>)).As(typeof(IDao<>)).InstancePerLifetimeScope();
        }
        /// <summary>
        /// 注册唯一不共享接口实例
        /// </summary>
        /// <typeparam name="T">实现</typeparam>
        /// <typeparam name="K">接口</typeparam>
        public static void Regsiter<T,K>()where T :class where K :class  {
            IOCBaseIni();
            Builder.RegisterType<T>().As<K>().PropertiesAutowired().InstancePerDependency();
        }
        /// <summary>
        /// 获取指定接口实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="prms">参数 new NamedParameter("参数名称", "参数值"）</typeparam>
        /// <returns></returns>
        public static T GetInstance<T>(Autofac.Core.Parameter prms = null) where T :class
            {
                IOCBaseIni();
                var server = (T)InstanceContainer.Resolve(typeof(T),prms);
                return server;
            }
        /// <summary>
        /// 获取指定接口实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="prms">参数 new NamedParameter("参数名称", "参数值"）</typeparam>
        /// <returns></returns>
        public static T GetInstance<T>(bool IsGeneric,Autofac.Core.Parameter prms = null) where T : class
        {
          try
          {
            IOCBaseIni();
            var server = (T)InstanceContainer.Resolve(typeof(T), prms);
            return server;
          }
          catch(Exception ex)
          {
            throw ex;  
          }
            
        }
    }

}
