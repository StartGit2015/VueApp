using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Y.Core.Model;

namespace Y.Core.Web
{
  /// <summary>
  /// MVC控制器基类
  /// </summary>
  public class ControllerEx : Controller
  {
    /// <summary>
    /// 分页数据
    /// </summary>
    public PageInfor pageInfor = new PageInfor();
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
      if (filterContext.HttpContext.Request.Form.Count > 0)
      {
        pageInfor.pageSize = filterContext.HttpContext.Request.Form["pageSize"].ToInt();
        pageInfor.totalPage = filterContext.HttpContext.Request.Form["totalPage"].ToInt();
        pageInfor.pageNumber = filterContext.HttpContext.Request.Form["pageNumber"].ToInt();
        pageInfor.queryParam = filterContext.HttpContext.Request.Form["queryParam"];
      }
      else
      {
        pageInfor.pageSize = filterContext.HttpContext.Request.QueryString["pageSize"].ToInt();
        pageInfor.totalPage = filterContext.HttpContext.Request.QueryString["totalPage"].ToInt();
        pageInfor.pageNumber = filterContext.HttpContext.Request.QueryString["pageNumber"].ToInt();
        pageInfor.queryParam = filterContext.HttpContext.Request.QueryString["queryParam"];
      }
      
      base.OnActionExecuting(filterContext);
    }
  }
}
