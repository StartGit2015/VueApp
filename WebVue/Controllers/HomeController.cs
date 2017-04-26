using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueEntity;
using VueServer;

namespace WebVue.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 内容管理服务类
        /// </summary>
        ContentServer contentServer = new ContentServer();
        /// <summary>
        /// 登录验证服务
        /// </summary>
        UserVeliDataServer veliDataServer = new UserVeliDataServer();
        /// <summary>
        /// 网站首页 包含验证内容
        /// </summary>
        /// <returns></returns>
        public ActionResult Home(string enterCode,string deviceInfor)
        {
            if (Session["username"] != null) {
                ViewBag.title = "欢迎您，" + deviceInfor;
                ViewBag.model = contentServer.QueryAll().ToList();
                return RedirectToAction("Index");
            }
            if (string.IsNullOrWhiteSpace(enterCode))
            {
                return View();
            }

            var isVelidata = veliDataServer.Count(o => o.VelidataValue == enterCode);
            if(isVelidata > 0)
            {
                Session["username"] = deviceInfor;
                ViewBag.title = "欢迎您，" + deviceInfor;
                ViewBag.model = contentServer.QueryAll().ToList();
                return RedirectToAction("Index");
            }
            return View();
        }
        /// <summary>
        /// 网站内容页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Home");
            }
            ViewBag.title = Session.SessionID + "欢迎您，" + Session["username"].ToString();
            ViewBag.model = contentServer.QueryAll().ToList();
            return View();
        }
        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddContent(Content model)
        {
            ViewBag.title = "欢迎您，" + Session["username"].ToString();

            if (model.ContentValue !=null)
            {
                model.CreateDate = DateTime.Now;
                model.ID = contentServer.Count(o => true);
                contentServer.Insert(model);
            }
            return View();
        }

        //请求Tree数据
        [HttpGet]
        public JsonResult Del(int id = 0)
        {
            if (contentServer.Delete(o => o.ID == id)) {
                return Json(@"{'ret':'true','msg':'删除成功'}", JsonRequestBehavior.AllowGet);
            };
            return  Json(@"{'ret':'false','msg':'删除没有成功'}", JsonRequestBehavior.AllowGet);
        }
    }
}
