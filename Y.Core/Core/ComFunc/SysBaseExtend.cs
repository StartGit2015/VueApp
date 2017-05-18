using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System
{
  public static class SysBaseExtend
  {
    # region object扩展
        // System.TypeExtension
        public static string GetEnumNameByValue<T>(this object value)
        {
          Type typeFromHandle = typeof(T);
          if (typeFromHandle.IsEnum)
          {
            return Enum.GetName(typeFromHandle, value);
          }
          throw new InvalidCastException("必须是枚举类型才能获取枚举名称。");
        }
        #endregion
    #region string扩展
    /// <summary>
    /// 字符串转INT 失败返回 0
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int ToInt(this string s)
    {
      int id;
      int.TryParse(s, out id);
      return id;
    }
    /// <summary>
    /// 字符串是否为空的判断
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string s)
    {
      return string.IsNullOrEmpty(s);
    }
    /// <summary>
    /// 是否符合正则验证
    /// </summary>
    /// <param name="s"></param>
    /// <param name="pattern"></param>
    /// <returns>true 为符合</returns>
    public static bool IsMatch(this string s, string pattern)
    {
      if (s.IsNullOrEmpty()) return false;
      else return Regex.IsMatch(s, pattern);
    }

    /// <summary>
    /// 取出符合正则的字符串
    /// </summary>
    /// <param name="s"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public static string Match(this string s, string pattern)
    {
      if (s.IsNullOrEmpty()) return "";
      return Regex.Match(s, pattern).Value;
    }


    /// <summary>
    /// 身份证验证
    /// </summary>
    /// <param name="s"></param>
    /// <returns>返回true 为是</returns>
    public static bool IsIdCard(this string s)
    {
      s = s.Trim();
      if (s.IsNullOrEmpty()) return false;
      StringBuilder pattern = new StringBuilder();
      pattern.Append(@"^(11|12|13|14|15|21|22|23|31|32|33|34|35|36|37|41|42|43|44|45|46|");
      pattern.Append(@"50|51|52|53|54|61|62|63|64|65|71|81|82|91)");
      pattern.Append(@"(\d{13}|\d{15}[\dx])$");
      return new Regex(pattern.ToString()).IsMatch(s);
    }
    /// <summary>
    /// 跟据身份证获取生日
    /// </summary>
    /// <param name="s"></param>
    /// <returns>返回true 为是</returns>
    public static DateTime? GetBirthdayFromIdCard(this string s)
    {
      s = s.Trim();
      if (!s.IsIdCard()) return null;
      string data = s.Length == 18 ? s.Substring(6, 8) : "19" + s.Substring(6, 6);
      data = data.Substring(0, 4) + "-" + data.Substring(4, 2) + "-" + data.Substring(6, 2);
      return DateTime.Parse(data);
    }
    /// <summary>
    /// 手机号码验证
    /// </summary>
    /// <param name="s"></param>
    /// <returns>返回true 为是</returns>
    public static bool IsPhone(this string s)
    {
      if (s.IsNullOrEmpty()) return false;
      return new Regex("^(13|15|18)[0-9]{9}$").IsMatch(s);
    }
    #endregion

    #region datetime扩展
    /// <summary>
    /// 根据日期输出年龄参数
    /// </summary>
    /// <param name="dt">生日</param>
    /// <returns></returns>
    public static Age GetAge(this DateTime dt)
    {
      var age = new Age();
      age.Year = (DateTime.Now.Year - dt.Year).ToString();
      return age;
    }

    #region 用到的类
    /// <summary>
    /// 年龄
    /// </summary>
    public class Age
    {
      /// <summary>
      /// 年龄
      /// </summary>
      public string Year { get; set; }
      /// <summary>
      /// 月份
      /// </summary>
      public string moutn { get; set; }
      /// <summary>
      /// 天数
      /// </summary>
      public string day { get; set; }
    }
    #endregion
    #endregion

    #region Enum扩展
    /// <summary>
    /// 转为枚举
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public static T ToEnum<T>(this string name) {
      Type typeFromHandle = typeof(T);
      if (typeFromHandle.IsEnum)
      {
        return (T)((object)Enum.Parse(typeof(T), name));
      }
      throw new InvalidCastException("必须是枚举类型才能转换。");
    }
    public static T ToEnumByValue<T>(this object value) {
      return value.GetEnumNameByValue<T>().ToEnum<T>();
    }

    /// <summary>
    /// 获取枚举描述
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    //public static string GetDescription(this Enum value)
    //{
    //  string result;
    //  if (Validate.IsEmpty<Enum>(value))
    //  {
    //    result = string.Empty;
    //  }
    //  else
    //  {
    //    string text = value.ToString();
    //    System.Reflection.FieldInfo field = value.GetType().GetField(text);
    //    if (field == null)
    //    {
    //      result = text;
    //    }
    //    else
    //    {
    //      object obj = field.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault<object>();
    //      if (Validate.IsEmpty(obj))
    //      {
    //        result = text;
    //      }
    //      else
    //      {
    //        DescriptionAttribute descriptionAttribute = (DescriptionAttribute)obj;
    //        result = descriptionAttribute.Description;
    //      }
    //    }
    //  }
    //  return result;
    //}

    #endregion
  }
}
