using System;
using System.Web;
using System.Web.Mvc;

namespace CloudCore.Web.Core.Extensions
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class PermanentCacheAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
            cache.SetExpires(DateTime.UtcNow.AddYears(1));
            cache.SetLastModified(DateTime.UtcNow);
            cache.SetCacheability(HttpCacheability.Public);
        }

    }
}
