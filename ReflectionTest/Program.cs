using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {

            refection();

        }

        /// <summary>
        /// 反射测试
        /// </summary>
        public static void refection()
        {
            var model = new Model() { FildID = 1, FildName = "字段1" };

            Type type = model.GetType();
            FieldInfo[] fileds = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo[] ps = type.GetProperties();

            foreach (var item in fileds)
            {
                //var name = item.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                var filedName = item.FieldType.ToString();
                var filedValue = item.GetValue(model);
                Console.WriteLine(filedName + filedValue);
            }
            foreach (var item in ps)
            {
                var name = item.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                var filedName = item.Name;
                var filedValue = item.GetValue(model);

                Console.WriteLine(name + filedName + filedValue);
            }
        }
    }

    [DisplayName("Model类")]
    public class Model
    {
        [DisplayName("ID值")]
        public int FildID { get; set; }
        [DisplayName("Name值")]
        public string FildName { get; set; }
    }
}
