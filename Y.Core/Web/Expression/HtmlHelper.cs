using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Y.Core.Web.Expression
{
    public static class HtmlHelperEx
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel">model元数据</typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString RadioFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            string format = null;
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            return htmlHelper.TextBoxFor(expression, format);
        }
        /// <summary>
        /// 生成导航树
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="navTree">值</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString NavTree(this HtmlHelper htmlHelper, NavTree navTree, object htmlAttributes = null)
        {
            TagBuilder li = new TagBuilder("li");
            if (navTree.IsExpend)
            {
                li.AddCssClass("layui-nav-item  layui-nav-itemed");
            }
            else
            {
                li.AddCssClass("layui-nav-item");
            }

            li.InnerHtml += String.Format("<a href=\"javascript:; \">{0}</a><span class=\"layui-nav-more\"></span>", navTree.Name);

            //子菜单
            if (navTree.ChildNav.Count > 0)
            {
                li.InnerHtml += "<dl class=\"layui-nav-child\">";

                foreach (NavTree item in navTree.ChildNav)
                {
                    li.InnerHtml += String.Format(" <dd><a href=\"javascript:; \" data-url=\"{0}\" data-id = \"{1}\" data-frame=\"{2}\">{3}</a></dd>",item.DataUrl,item.DataId,item.DataFrame,item.Name);
                }
                li.InnerHtml += "</dl>";
            }
            return new MvcHtmlString(li.ToString());
        }

    public static MvcHtmlString NavTree( NavTree navTree, object htmlAttributes = null)
    {
      TagBuilder li = new TagBuilder("li");
      if (navTree.IsExpend)
      {
        li.AddCssClass("layui-nav-item  layui-nav-itemed");
      }
      else
      {
        li.AddCssClass("layui-nav-item");
      }

      li.InnerHtml += String.Format("<a href=\"javascript:; \">{0}</a>", navTree.Name);

      //子菜单
      if (navTree.ChildNav.Count > 0)
      {
        li.InnerHtml += "< dl class=\"layui-nav-child\">";

        foreach (NavTree item in navTree.ChildNav)
        {
          li.InnerHtml += String.Format(" <dd><a href=\"javascript:; \" data-url=\"{0}\" data-id = \"{1}\" data-frame=\"{2}\">{3}</a></dd>", item.DataUrl, item.DataId, item.DataFrame, item.Name);
        }
        li.InnerHtml += "<\\dl>";
      }
      return new MvcHtmlString(li.ToString());
    }
  }
}
