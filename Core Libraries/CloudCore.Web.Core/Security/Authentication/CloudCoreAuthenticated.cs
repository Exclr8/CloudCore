using System;
using System.IdentityModel.Services;
using System.Web;
using System.Web.Mvc;
using CloudCore.Web.Core.ActionResults;

namespace CloudCore.Web.Core.Security.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class CloudCoreAuthenticatedAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsAuthenticated)
            {
                try
                {
                    return CloudCoreIdentity.InternalAccess;
                }
                catch (NullReferenceException)
                {
                    CloudAuthentication.Logout(httpContext.Session, httpContext.Response);
                }
            }

            return base.AuthorizeCore(httpContext);
        }
        
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);

            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                const string authorizeErrorHtml = "<b>HTTP Error Code 403 - Forbidden:</b> Sorry, you do not have access to this part of the system."; 
                Common.GenerateHttpResponse(filterContext.HttpContext.Response, 403, authorizeErrorHtml);
            }
            else
            {
                filterContext.Result = new RedirectToLogin(filterContext.HttpContext.Request.RawUrl);
            }
        }
    }
}
