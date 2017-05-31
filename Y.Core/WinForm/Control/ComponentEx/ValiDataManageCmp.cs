using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Core.ComFunc;

namespace CFW.WinFormBase.Controls
{
    /// <summary>
    /// 为控件提供数据验证规则扩展属性
    /// </summary>
    [Description("为菜单项或控件提供描述扩展属性")]
    [ProvideProperty("Verify", typeof(Control))]
    [ProvideProperty("VerifyMsg", typeof(Control))]
    public class ControlVerify : Component, IExtenderProvider
    {
        /// <summary>
        /// 存储所服务的控件及其验证规则
        /// </summary>
        readonly Dictionary<Control, Validata> dic;
        /// <summary>
        /// 存储所服务的控件及其验证提示信息
        /// </summary>
        readonly Dictionary<Control, string> msgDic;
        /// <summary>
        /// 错误验证提示类
        /// </summary>
        public ErrorProvider errTip;
        /// <summary>
        /// 创建一个Verify类
        /// </summary>
        public ControlVerify()
        {
            dic = new Dictionary<Control, Validata>();
            msgDic = new Dictionary<Control, string>();
            errTip = new ErrorProvider();
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        /// <param name="ct">验证控件所在容器 null为全部</param>
        public bool VerifyData(Control ct = null)
        {
            //errTip.Clear();
            var ret = true;
            foreach (var item in dic)
            {
                var data = item.Key.Text;//数据
                var verify = item.Value;//验证规则

                if (ct != null && item.Key.Parent != ct)
                {
                    errTip.SetError(item.Key, "");
                    continue;
                }
                if (DataVali(data,verify))
                {
                    errTip.SetError(item.Key, "");
                }
                else
                {

                    errTip.SetError(item.Key, msgDic[item.Key].Length == 0?"": "请输入正确的数据");
                    ret = false;
                }
                
            }
            return ret;
        }
        /// <summary>
        /// 清除验证提示
        /// </summary>
        public void ClearVerify()
        {
            errTip.Clear();
        }
        private bool DataVali(string data,Validata vali)
        {
            bool ret = false;
            var _data = data.Trim();
            switch (vali)
            {
                case Validata.无:
                    ret = true;
                    break;
                case Validata.Require:
                    if (_data.Length > 0)
                        ret = true;
                    break;
                case Validata.AgeValue:
                    if (!_data.IsNullOrEmpty() && !_data.IsMatch("^[0 - 9] + $"))
                    {
                        ret = false;
                    }
                    else
                    {
                        ret = true;
                    }

                    break;
                case Validata.DateValue:
                    ret = _data.IsMatch(@"^(\d{2}|\d{4})((0[1-9])|(1[0-2]))((0[1-9])|((1|2)[0-9])|30|31)$");
                    break;
                case Validata.NumberValue:
                    ret = _data.IsMatch(@"^[0 - 9] + $");
                    break;
                case Validata.TelValue:
                    ret = _data.IsPhone();
                    break;
                case Validata.IntValue:
                    int parse = 0;
                    ret = int.TryParse(_data,out parse);
                    break;
                case Validata.IdCardValue:
                    ret = _data.IsIdCard();
                    break;
                default:
                    break;
            }
            return ret;
        }
        /// <summary>
        /// 获取菜单项描述
        /// </summary>
        [Description("设置验证规则")] //虽然方法为Get，但在VS中显示为“设置”才符合理解
        [DefaultValue(Validata.无)]
        public Validata GetVerify(Control item)
        {
            //从集合中取出该item的描述
            Validata value;
            dic.TryGetValue(item, out value);
            msgDic[item] = "";
            return value;
        }

        /// <summary>
        /// 设置验证规则描述
        /// </summary>
        public void SetVerify(Control item, Validata value)
        {
            if (item == null) { return; }
            
            if (value == Validata.无)
            {
                //从集合中移除该item，并取消其相关事件绑定
                dic.Remove(item);
                msgDic.Remove(item);
            }
            else
            {
                //添加或更改该item的描述
                dic[item] = value;//这种写法对于dic中不存在的Key，会自动添加
                msgDic[item] = "";
            }
        }

        /// <summary>
        /// 获取菜单项描述
        /// </summary>
        [Description("设置验证提示")] //虽然方法为Get，但在VS中显示为“设置”才符合理解
        [DefaultValue("")]
        public string GetVerifyMsg(Control item)
        {
            //从集合中取出该item的描述
            string value;
            msgDic.TryGetValue(item, out value);
            return value;
        }

        /// <summary>
        /// 设置验证规则提示信息
        /// </summary>
        public void SetVerifyMsg(Control item, string value)
        {
            if (item == null) { return; }

            if (value == "")
            {
                //从集合中移除该item，并取消其相关事件绑定
                msgDic.Remove(item);
            }
            else
            {
                //添加或更改该item的描述
                msgDic[item] = value;//这种写法对于dic中不存在的Key，会自动添加
            }
        }

        /// <summary>
        /// 是否可为某对象扩展属性
        /// </summary>
        public bool CanExtend(object extendee)
        {
            return true;
        }
    }
    public enum Validata
    {
        无,
        Require,
        AgeValue,
        DateValue,
        NumberValue,
        TelValue,
        IntValue,
        IdCardValue,
    }
}
