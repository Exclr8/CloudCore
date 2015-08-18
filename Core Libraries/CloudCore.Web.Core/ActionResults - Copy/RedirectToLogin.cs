using System.Web.Mvc;
using System.Web.Routing;

namespace CloudCore.Web.Core.ActionResults
{
    public class RedirectToLogin : RedirectToRouteResult
    {
        public RedirectToLogin(string returnUrl = "")
            : base(new RouteValueDictionary(
                         new
                         {
                             controller = WebApplication.Configuration.WebSettings.LoginAction.Controller,
                             action = WebApplication.Configuration.WebSettings.LoginAction.Action,
                             area = WebApplication.Configuration.WebSettings.LoginAction.Area,
                             returnUrl = returnUrl
                         }))
        { }
    }
}