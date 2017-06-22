using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y.Core.ComFunc;

namespace WebTest.Controllers
{
    public class LogInController : Controller
    {
        public ActionResult LogIn()
    {
      return View();
    }
        // GET: LogIn
        public ActionResult Index(string code = "")
        {
            var rq = Request;
      var name = rq.QueryString["name"];
            ViewBag.Message = "请输入信息！！";
            return View();
        }
        
        public ActionResult ValiCode()
        {
          var img = new YZMFunc();
          Session["code"] = img.Text;
          MemoryStream ms = new MemoryStream();
          img.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
          return File( ms.ToArray(),"image/jpeg");
        }
    }
}