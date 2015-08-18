using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Configuration.ConfigFile;

namespace CloudCore.Web.Core.Configuration
{
    public static class RouteConfig
    {
        public static void RegisterDefaultRoutes(RouteCollection routes, CloudCoreWebSection configuration)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("Core/Assets/{*pathInfo}");
            routes.IgnoreRoute("public/{resource}.ashx");

            var defaultroute = routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new
                {
                    area = configuration.WebSettings.DefaultAction.Area,
                    controller = configuration.WebSettings.DefaultAction.Controller,
                    action = configuration.WebSettings.DefaultAction.Action,
                    id = UrlParameter.Optional,
                    
                },
                new[] { configuration.WebSettings.DefaultAction.Namespace }
            );

            defaultroute.DataTokens.Add("area", configuration.WebSettings.DefaultAction.Area);

            var notFoundRoute = routes.MapRoute(
                "NotFound",
                "{*url}",
                new { area = "CUI", controller = "Error", action = "NotFound" }
            );
            notFoundRoute.DataTokens.Add("area", configuration.WebSettings.DefaultAction.Area);

            var errorRoute = routes.MapRoute(
                "Error",
                "{*url}",
                new { area = "CUI", controller = "Error", action = "GenericError" }
            );
            errorRoute.DataTokens.Add("area", configuration.WebSettings.DefaultAction.Area);
        }
    }
}
