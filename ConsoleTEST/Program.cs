
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyEntity;
using MoneyServer;
using Autofac;
using System.Reflection;
using Y.Core.Interface;
using Y.Core.Dao;

namespace ConsoleTEST
{
    class Program
    {
        public static IContainer containt { get; set; }
        static void Main(string[] args)
        {

            //new Program().init();

            var Server = new UserHourseServer();
            List<UserHourse> modelLsit = new List<UserHourse>();
            Console.WriteLine("正在填充数据。。。");
            var m = new UserHourse
            {
            Id=1,HourseName="402",UserName="yan",UserSpellShort="y"};
            for (int i = 0; i < 10; i++)
            {
                modelLsit.Add(m);
            }
            Console.WriteLine("填充完毕");
            Server.Insert(modelLsit);
            Console.WriteLine("插入完毕！");
            Console.ReadLine();


        }
        /// <summary>
        /// 初始化自动依赖注入
        /// </summary>
        //protected void init()
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterGeneric(typeof(SqlSugarDao<>)).As(typeof(IDao<>)).InstancePerDependency();
        //    containt = builder.Build(Autofac.Builder.ContainerBuildOptions.None);
        //}
    }
}
