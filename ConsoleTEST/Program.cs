using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servers;
using Autofac;
using System.Reflection;
using Y.Core.Interface;
using Y.Core.Dao;

namespace ConsoleTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().init();

            StudentServer Server = new StudentServer();
            List<Student> studentList = new List<Student>();
            Console.WriteLine("正在填充数据。。。");
            var student = new Student {
            ID=1,Name="hahah",Gender="男"};
            for (int i = 0; i < 10; i++)
            {
                studentList.Add(student);
            }
            Console.WriteLine("填充王弼");
            Server.Insert(studentList);
            
           
        }
        /// <summary>
        /// 初始化自动依赖注入
        /// </summary>
        protected void init()
        {
            var builder = new ContainerBuilder();
            var baseType = typeof(IDependency);
            var asseasse = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterGeneric(typeof(IDao<>)).As(typeof(SqlSugarDao<>)).InstancePerLifetimeScope();
            builder.Build();
            
        }
    }
}
