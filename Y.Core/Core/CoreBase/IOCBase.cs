using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Core.Dao;
using Y.Core.Interface;

namespace Y.Core
{
    ///AutoFac IOC管理器
    public static class IOCBase
    {
        /// <summary>
        ///获取对象管理器
        /// </summary>
        internal static IContainer InstanceContainer { get; set; }
        /// <summary>
        /// 获取对象注册器
        /// </summary>
        public static ContainerBuilder Builder { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public static void IOCBaseIni()
        {
            if(Builder == null)
            {
                Builder = new ContainerBuilder();
                InstanceContainer = Builder.Build(Autofac.Builder.ContainerBuildOptions.None);
                CoreIOCReg();
            }
        }
        /// <summary>
        /// 核心容器注册
        /// </summary>
        public static void CoreIOCReg()
        {
            Builder.RegisterGeneric(typeof(SqlSugarDao<>)).As(typeof(IDao<>));
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
        /// <returns></returns>
        public static T GetInstance<T>() where T :class
        {
            IOCBaseIni();
            var server = (T)InstanceContainer.Resolve(typeof(T));
            return server;
        }
        /// <summary>
        /// 获取指定接口实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetInstance<T>(bool IsGeneric = true) where T : class
        {
            IOCBaseIni();
            var server = (T)InstanceContainer.Resolve<T>();
            return server;
        }
    }

}
