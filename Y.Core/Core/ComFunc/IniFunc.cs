using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Y.Core
{
    /// <summary>
    /// Ini读写函数
    /// </summary>
    public class InIFunc
    {
        public string path;

        InIFunc(string INIPath)
        {
            path = INIPath;
        }
        /// <summary>
        /// 写入Ini值
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary>
        /// 获取Ini值
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <param name="retVal"></param>
        /// <param name="size"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 获取Ini值
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defVal"></param>
        /// <param name="retVal"></param>
        /// <param name="size"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);


        /// <summary>  
        /// 写INI文件  
        /// </summary>  
        /// <param name="Section"></param>  
        /// <param name="Key"></param>  
        /// <param name="Value"></param>  
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        /// <summary>  
        /// 读取INI文件  
        /// </summary>  
        /// <param name="Section"></param>  
        /// <param name="Key"></param>  
        /// <returns></returns>  
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }
        /// <summary>
        /// 获取节、键值
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public byte[] IniReadValues(string section, string key)
        {
            byte[] temp = new byte[255];
            int i = GetPrivateProfileString(section, key, "", temp, 255, this.path);
            return temp;

        }


        /// <summary>  
        /// 删除ini文件下所有段落  
        /// </summary>  
        public void ClearAllSection()
        {
            IniWriteValue(null, null, null);
        }
        /// <summary>  
        /// 删除ini文件下personal段落下的所有键  
        /// </summary>  
        /// <param name="Section"></param>  
        public void ClearSection(string Section)
        {
            IniWriteValue(Section, null, null);
        }
    }
}
