using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class RadioButtonExtensions
    {
        public static MvcHtmlString RadioButtonList(this System.Web.Mvc.HtmlHelper helper, string name, IEnumerable<string> items)
        {
            var selectList = new SelectList(items);
            return RadioButtonList(helper, name, selectList, null);
        }

        public static MvcHtmlString RadioButtonList(this System.Web.Mvc.HtmlHelper helper, string name, IEnumerable<SelectListItem> items, object htmlAttributes)
        {
            IDictionary<string, object> newHtmlAttributes = htmlAttributes as IDictionary<string, object> ?? new Dictionary<string, object>();

            if (newHtmlAttributes.ContainsKey("class"))
            {
                var value = string.Format("{0} pull-right", newHtmlAttributes.Single(x => x.Key == "class").Value);
                newHtmlAttributes.Remove("class");
                newHtmlAttributes.Add("class", value);
            }
            else
            {
                newHtmlAttributes.Add("class", "pull-right");
            }

            var builder = new StringBuilder();

            foreach (var item in items)
            {
                var rbValue = item.Value ?? item.Text;
                var rbName = name + "_" + rbValue;

                string attribs = newHtmlAttributes.Aggregate(string.Empty, (current, htmlAttribute) => current + (htmlAttribute.Key + "=\"" + htmlAttribute.Value + "\" "));
                string checkedAttribute = (item.Selected ? " checked=\"checked\"" : string.Empty);                

                var radioTag = string.Format("<input type=\"radio\" id=\"{0}\" name=\"{1}\" value=\"{2}\" {3}{4} />", rbName, name, rbValue, attribs, checkedAttribute);

                var labelTag = new TagBuilder("label");
                labelTag.MergeAttribute("for", rbName);
                labelTag.MergeAttribute("id", rbName + "_label");
                labelTag.MergeAttribute("class", "radio-inline");
                labelTag.InnerHtml = string.Format("{0}{1}", radioTag, rbValue);

                builder.Append(labelTag);
            }
            return new MvcHtmlString(builder.ToString());
        }

        private static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> items, object htmlAttributes)
        {
            string html;

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException(@"Expression member cannot be evaluated in this context.", "expression");
            }

            string propertyName = string.Empty;
            string propertyValue = string.Empty;

            if (helper.ViewData.Model != null)
            {
                PropertyInfo pInfo = helper.ViewData.Model.GetType().GetProperty(memberExpression.Member.Name);
                propertyName = pInfo.Name;
                propertyValue = Convert.ToString(pInfo.GetValue(helper.ViewData.Model));
            }

            var selectListItems = items as IList<SelectListItem> ?? items.ToList();
            foreach (var item in selectListItems)
            {
                item.Selected = propertyValue == item.Value;
            }

            MvcHtmlString text = RadioButtonList(helper, propertyName, selectListItems, htmlAttributes);

            using (var sw = new StringWriter())
            {
                var w = new HtmlTextWriter(sw);
                w.Write(text);
                html = sw.GetStringBuilder().ToString();
            }

            return new MvcHtmlString(html);
        }
    }
}
