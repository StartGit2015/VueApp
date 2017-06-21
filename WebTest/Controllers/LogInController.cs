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
        // GET: LogIn
        public ActionResult Index(string code = "")
        {
          var sessionCode = Session["code"] == null ? "" : Session["code"].ToString();
          if (code != "" && sessionCode == code)
          {
            ViewBag.Message = "验证码正确！";
          }
          else
          {
            ViewBag.Message = "验证码不正确！";
          }
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