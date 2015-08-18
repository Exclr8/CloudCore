using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;

namespace CloudCore.Web.Core.BaseViews
{
    /// <summary>
    /// Let your LookUp views inherit this page to use built in cloud core helpers
    /// </summary>
    public abstract class LookupView<T> : CoreView<T>
    {
        public MvcHtmlString SetLookUpControlValuesAsJavascript(string idValue, string nameValue)
        {
            var idName = Request.QueryString["idName"];
            var valueName = Request.QueryString["valueName"];

            return new MvcHtmlString(string.Format("parent.setLookUpControlValues('{0}', '{1}', '{2}', '{3}');", idName, idValue, valueName, nameValue));
        }

        public MvcHtmlString SetLookUpControlValuesAsHref(string idValue, string nameValue, string hrefText)
        {
            return new MvcHtmlString(string.Format(@"<a href=""#"" onclick=""{0}"">{1}</a>", SetLookUpControlValuesAsJavascript(idValue, nameValue), hrefText));
        }

        public MvcHtmlString AddHrefToSetLookupValue(string idName, string idValue, string valueName, string nameValue, string hrefText)
        {
            var href = string.Format(@"<a href=""#"" onclick=""parent.setLookUpControlValues('{0}', '{1}', '{2}', '{3}');"">{4}</a>", idName, idValue, valueName, nameValue, hrefText);
            return new MvcHtmlString(href);
        }

        public MvcHtmlString AddHrefToSetLookupValue(T model, Expression<Func<T, string>> idExpression, Expression<Func<T, string>> valueExpression, string idValue, string nameValue, string hrefText)
        {
            PropertyInfo idProp = ((MemberExpression) idExpression.Body).Member as PropertyInfo;
            PropertyInfo valueProp = ((MemberExpression)valueExpression.Body).Member as PropertyInfo;
            var idName = idProp.GetValue(model);
            var valueName = valueProp.GetValue(model);

            var href = string.Format(@"<a href=""#"" onclick=""parent.setModalLookUpControlValues('{0}', '{1}', '{2}', '{3}');"">{4}</a>", idName, idValue, valueName, nameValue, hrefText);
            return new MvcHtmlString(href);
        }

        public MvcHtmlString AddHrefToSetLookupValue(PropertyInfo idProperty, PropertyInfo valueProperty, string hrefText)
        {
            var idName = idProperty.Name;
            var idValue = idProperty.GetConstantValue();
            var valueName = valueProperty.Name;            
            var nameValue = valueProperty.GetConstantValue();

            var href = string.Format(@"<a href=""#"" onclick=""parent.setLookUpControlValues('{0}', '{1}', '{2}', '{3}');"">{4}</a>", idName, idValue, valueName, nameValue, hrefText);
            return new MvcHtmlString(href);
        }

        private TProperty GetValue<TProperty>(MemberExpression member)
        {
            var objectMember = Expression.Convert(member, typeof(TProperty));
            var getterLambda = Expression.Lambda<Func<TProperty>>(objectMember);
            var getter = getterLambda.Compile();

            return getter();
        }
    }
}
