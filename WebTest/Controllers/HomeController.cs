using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y.Core.Model;
using Y.Core.Web;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          return View();
        }

        public ActionResult About()
        {
            List<NavTree> trees = new List<NavTree>();

            for (int i = 0; i < 4; i++)
            {
              var tree = new NavTree
              {
                ID = i,
                DataId = i.ToString(),
                DataUrl = "/about",
                Name = "主菜单_" + i.ToString(),
                ChildNav = new List<NavTree>()
              };
              for (int j = 0; j < 4; j++)
              {
                var treec = new NavTree
                {
                  ID = i,
                  DataId = i.ToString(),
                  DataUrl = "home/about",
                  Name = "子菜单_" + i.ToString() + j.ToString(),
                };
                tree.ChildNav.Add(treec);
              }
              trees.Add(tree);
            }
            
            ViewBag.NavList = trees;
            ViewBag.Message = "about页面";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}