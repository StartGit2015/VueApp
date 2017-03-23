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
        public ActionResult Index()
        {
            ViewBag.model = contentServer.QueryAll().ToList();
            return View();
        }

        public ActionResult AddContent(Content model)
        {
            if(model.ContentValue !=null)
            {
                contentServer.Insert(model);
            }
            return View();
        }

        //请求Tree数据
        [HttpGet]
        public JsonResult GetTree(int patentId = 0)
        {
            var data = contentServer.QueryAll().Where(m => m.ParentId == patentId)
                .Select(o => new { name = o.TitleName, id = o.ID }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
