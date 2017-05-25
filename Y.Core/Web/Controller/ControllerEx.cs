using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Y.Core.Web
{
  /// <summary>
  /// MVC控制器基类
  /// </summary>
  public class ControllerEx : Controller
  {
    /// <summary>
    /// 授权调用方法
    /// </summary>
    /// <param name="filterContext"></param>
    protected override void OnAuthorization(AuthorizationContext filterContext)
    {
      base.OnAuthorization(filterContext);
    }
    /// <summary>
    /// 调用Action方法前调用
    /// </summary>
    /// <param name="filterContext"></param>
    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      base.OnActionExecuting(filterContext);
    }
  }
}
