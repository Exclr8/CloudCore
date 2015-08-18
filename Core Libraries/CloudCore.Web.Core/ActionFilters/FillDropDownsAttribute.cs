using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CloudCore.Web.Core.UIHints;

namespace CloudCore.Web.Core.ActionFilters
{
    internal class FillDropDownsAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewModel = filterContext.Controller.ViewData.Model;

            if (viewModel != null)
            {
                SetLists(viewModel.GetType(), filterContext.Controller.ViewData);
            }

            base.OnResultExecuting(filterContext);
        }

        internal static void SetLists(Type viewModelType, IDictionary<string, object> viewData)
        {
            foreach (var property in viewModelType.GetProperties())
            {
                if (!(property.PropertyType.IsClass && !(property.PropertyType == typeof(string))))
                {
                    var att = (CloudCoreDropDownAttribute)GetCustomAttribute(property, typeof(CloudCoreDropDownAttribute));
                    if (att != null)
                    {
                        var viewDataKey = "DDKey_" + property.Name;
                        viewData[viewDataKey] = viewData[viewDataKey] ?? att.GetMethodResult();
                    }
                }
                else
                {
                    SetLists(property.PropertyType, viewData);
                }
            }
        }
    }
}