using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Xml.Serialization;

namespace Y.Core.Web.Expression
{
    public static class HtmlHelper
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
    }
}
