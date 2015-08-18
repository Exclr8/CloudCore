using System.Web.Mvc;
using System.Web.Routing;

namespace CloudCore.Web.Core.ActionResults
{
    public class RedirectToDefault : RedirectToRouteResult
    {
        public RedirectToDefault()
            : base(new RouteValueDictionary(
                         new
                         {
                             controller = WebApplication.Configuration.WebSettings.DefaultAction.Controller,
                             action = WebApplication.Configuration.WebSettings.DefaultAction.Action,
                             area = WebApplication.Configuration.WebSettings.DefaultAction.Area
                         }))
        { }
    }
}