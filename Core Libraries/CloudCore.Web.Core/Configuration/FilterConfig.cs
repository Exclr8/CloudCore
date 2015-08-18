using CloudCore.Web.Core.MvcFilters;
using System.Web.Mvc;

namespace CloudCore.Web.Core.Configuration
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalExceptionFilter());
        }
    }
}
