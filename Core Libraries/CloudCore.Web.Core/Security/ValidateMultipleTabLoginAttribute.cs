using System;
using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Web.Core.Security.Authentication;

namespace CloudCore.Web.Core.Security
{
    public class ValidateMultipleTabLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                ValidateToken(filterContext);
            }
            base.OnActionExecuting(filterContext);
        }

        private static void ValidateToken(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.HttpContext.Request.Form != null)
            {
                var token = filterContext.HttpContext.Request.Form["__ccsession"];
                if (!string.IsNullOrEmpty(token) && !string.Equals(token, CloudCoreIdentity.Email, StringComparison.CurrentCultureIgnoreCase))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                            {
                                                { "client", filterContext.RouteData.Values[ "client" ] },
                                                { "area", "CUI" },
                                                { "controller", "Login" },
                                                { "action",  "IdentificationError" },
                                                { "errorMessage", string.Format("The action that you requested cannot be completed because it was intended for a different user session. You are currently logged in as {0}.", CloudCoreIdentity.Fullname) }
                                            });
                }
            }
        }
    }
}
