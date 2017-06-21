using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Core.Web;
using Y.Core.Web.Expression;
using System.Web.Mvc.Razor;
using System.Web.Mvc;

namespace ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var data = Program.GetData();
      string htm = "";
      foreach (var item in data)
      {
        htm += HtmlHelperEx.NavTree(item).ToString();
      }
      Console.WriteLine(htm);
      Console.ReadKey();
    }

    private static List<NavTree> GetData()
    {
      List<NavTree> trees = new List<NavTree>();

      for (int i = 0; i < 4; i++)
      {
        var tree = new NavTree
        {
          ID = i,
          DataId = i.ToString(),
          DataUrl = "action/sss",
          Name = "主菜单_" + i.ToString(),
          ChildNav = new List<NavTree>()
        };
        for (int j = 0; j < 4; j++)
        {
          var treec = new NavTree
          {
            ID = i,
            DataId = i.ToString(),
            DataUrl = "action/sss",
            Name = "子菜单_" + i.ToString() + j.ToString(),
          };

          tree.ChildNav.Add(treec);
        }
        trees.Add(tree);
      }

      return trees;
    }
  }
}
