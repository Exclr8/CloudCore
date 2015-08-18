using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class FilterEdits
    {
        public static MvcHtmlString FilterEdit<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, Expression<Func<TModel, TProperty>> filter, object ddlHtmlAttributes, object text_htmlAttributes)
        {
            var html = new StringBuilder();
            var model = new FilterEditModel();

            var textHtmlAttributesDictionary = new RouteValueDictionary(text_htmlAttributes);
            var ddlHtmlAttributesDictionary = new RouteValueDictionary(ddlHtmlAttributes);

            textHtmlAttributesDictionary.Add("class", "filter-edit-input form-control");
            ddlHtmlAttributesDictionary.Add("class", "form-control");

            html.Append("<div class=\"filter-edit input-group\" >");
            html.Append("<div class=\"input-group-btn\">");
            html.Append(helper.DropDownListFor(filter, model.FilterOptions, ddlHtmlAttributesDictionary));
            html.Append("</div>");
            html.Append(helper.TextBoxFor(expression, textHtmlAttributesDictionary));
            html.Append("</div>");

            return new MvcHtmlString(html.ToString());
        }

        public static MvcHtmlString FilterEdit<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, Expression<Func<TModel, TProperty>> filter)
        {
            return FilterEdit(helper, expression, filter, null, null);
        }
    }
}
