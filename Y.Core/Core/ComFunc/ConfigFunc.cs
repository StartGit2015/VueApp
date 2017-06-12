using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Core.ComFunc
{
    /// <summary>
    /// AppSettings、connecttinon下配置文件帮助类
    /// </summary>
    public class ConfigFunc
    {
        #region 字段和初始化
        /// <summary>
        /// 配置文件目录
        /// </summary>
        private static string file = System.Windows.Forms.Application.ExecutablePath;
        /// <summary>
        /// 初始化新配置文件目录
        /// </summary>
        /// <param name="_file"></param>
        public ConfigFunc(string _file)
        {
            file = _file;
        }
        #endregion
        #region connecttinon 操作
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="connecttionName">连接名称</param>
        /// <returns></returns>
        public static string GetConnecttion(string connectionName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            return config.ConnectionStrings.ConnectionStrings[connectionName].ConnectionString;
        }
        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="connecttionName">连接名称</param>
        /// <param name="newConString">字符串值</param>
        /// <param name="newProviderName">数据提供程序名称</param>
        /// <returns></returns>
        public static void SetConnecttion(string connectionName,string newConString, string newProviderName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            if (config.ConnectionStrings.ConnectionStrings[connectionName] != null)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(connectionName);
            }
            //新建一个连接字符串实例  
            ConnectionStringSettings mySettings =
                new ConnectionStringSettings(connectionName, newConString, newProviderName);
            // 将新的连接串添加到配置文件中.  
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存对配置文件所作的更改  
            config.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节  
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }
        #endregion
        #region AppSeting操作
        /// <summary>
        /// AppSeting操作 根据Key取Value值
        /// </summary>
        /// <param name="key"></param>
        public static string GetAppSetValue(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            return config.AppSettings.Settings[key].ToString().Trim();
        }
        /// <summary>
        /// AppSeting操作根据Key修改Value
        /// </summary>
        /// <param name="key">要修改的Key</param>
        /// <param name="value">要修改为的值</param>
        public static void SetAppSetValue(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            if (config.AppSettings.Settings[key] != null)
            {
                config.AppSettings.Settings.Remove(key);
            }
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        #endregion
    }
}
