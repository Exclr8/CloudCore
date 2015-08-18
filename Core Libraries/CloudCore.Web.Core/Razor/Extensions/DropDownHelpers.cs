using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using CloudCore.Web.Core.UIHints;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class DropDownHelpers
    {
        internal static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> enumerableType, string textPropertyName, string valuePropertyName)
        {
            var list = new List<SelectListItem>();

            foreach (var item in enumerableType)
            {
                string value = null;
                string text = string.Empty;
                Type enumeratedType = item.GetType();

                PropertyInfo valueInfo = enumeratedType.GetProperty(valuePropertyName);
                if (valueInfo != null)
                {
                    value = Convert.ToString(valueInfo.GetValue(item, null));
                }

                PropertyInfo textInfo = enumeratedType.GetProperty(textPropertyName);
                if (textInfo != null)
                {
                    text = Convert.ToString(textInfo.GetValue(item, null));
                }

                list.Add(new SelectListItem { Text = text, Value = value });
            }

            return list;
        }

        public static IEnumerable<SelectListItem> SetSelected(this IEnumerable<SelectListItem> selectList, object selectedValue)
        {
            selectList = selectList ?? new List<SelectListItem>();
            if (selectedValue == null)
                return selectList;
            var value = selectedValue.ToString();
            return selectList
                .Select(m => new SelectListItem
                {
                    Selected = string.Equals(value, m.Value),
                    Text = m.Text,
                    Value = m.Value
                });
        }

        public static IEnumerable<SelectListItem> GetAutomatedList<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                                      Expression<Func<TModel, TProperty>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var viewDataKey = "DDKey_" + metadata.PropertyName;

            if (htmlHelper.ViewData[viewDataKey] == null)
            {
                Type modelType = metadata.ContainerType; //htmlHelper.ViewData.ModelMetadata.ModelType;
                MemberInfo[] mInfo = modelType.GetMember(metadata.PropertyName);

                var att = (CloudCoreDropDownAttribute)Attribute.GetCustomAttribute(mInfo[0], typeof(CloudCoreDropDownAttribute));
                if (att != null)
                {
                    htmlHelper.ViewData[viewDataKey] = att.GetMethodResult();
                }
            }
            return ((IEnumerable<SelectListItem>)htmlHelper.ViewData[viewDataKey]);
        }
    }
}