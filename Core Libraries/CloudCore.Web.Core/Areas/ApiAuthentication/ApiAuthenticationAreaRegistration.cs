using System.Web.Mvc;
using CloudCore.Api;
using CloudCore.Web.Core.Api.AreaRegistration;

namespace CloudCore.Web.Core.Areas.ApiAuthentication
{
    public sealed class ApiAuthenticationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ApiAuthentication";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapHttpRoute(
                name: "CloudCore.Authentication.ResetPassword",
                routeTemplate: ApiPaths.Application.UserResetPassword,
                defaults: new { area = AreaName, controller = "Authentication", action = "ResetPassword" });

            context.MapHttpRoute(
                name: "CloudCore.Authentication.ChangePassword",
                routeTemplate: ApiPaths.User.ChangePassword,
                defaults: new { area = AreaName, controller = "Authentication", action = "ChangePassword" });

            context.MapHttpRoute(
                name: "CloudCore.Authentication.Login",
                routeTemplate: ApiPaths.Application.UserLogin,
                defaults: new { area = AreaName, controller = "Authentication", action = "Login" });

            context.MapHttpRoute(
                name: "CloudCore.Authentication.Authorize",
                routeTemplate: ApiPaths.Application.Authorize,
                defaults: new { area = AreaName, controller = "Authentication", action = "Authorize" });

            context.MapHttpRoute(
                name: "CloudCore.Authentication.UserDetails",
                routeTemplate: ApiPaths.User.Details,
                defaults: new { area = AreaName, controller = "Authentication", action = "UserDetails" });

            context.MapHttpRoute(
                name: "CloudCore.Authentication.ApplicationDetails",
                routeTemplate: ApiPaths.Application.Details,
                defaults: new { area = AreaName, controller = "Authentication", action = "ApplicationDetails" });

            context.MapHttpRoute(
                name: "CloudCore.Authentication.SingleAuthenticate",
                routeTemplate: ApiPaths.SingleAuthenticate,
                defaults: new { area = AreaName, controller = "Authentication", action = "SingleAuthenticate" });
        }
    }
}
