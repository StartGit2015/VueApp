using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Y.Core.ComFunc;
using Y.Core.Model;
using Y.Core.Web;

namespace WebTest.Controllers
{
    public class LogInController : ControllerEx
  {
        // GET: LogIn
        public ActionResult Index(string code = "")
        {
            var rq = Request;
            var name = rq.QueryString["name"];
            ViewBag.Message = "请输入信息！！";
            return View();
        }
        public JsonResult LogIn()
        {
          Thread.Sleep(3000);
          return Json(new { state="200",message="操作成功！"});
        }
        public ActionResult ValiCode()
        {
          var img = new YZMFunc();
          Session["code"] = img.Text;
          MemoryStream ms = new MemoryStream();
          img.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
          return File( ms.ToArray(),"image/jpeg");
        }
        public JsonResult loginUser()
        {
          List<object> obj = new List<object>();
          for (int i = 0; i < 10; i++)
          {
            var item = new { name = "name_" + i.ToString() + base.pageInfor.pageNumber.ToString(), dept = "dept_" + i.ToString() };
            obj.Add(item);
          }
          return Json(new PageInfor{ totalPage = 10, pageNumber= pageInfor.pageNumber, list=obj});
        }
    }
}