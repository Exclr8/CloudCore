using System.Web.Mvc;
using CloudCore.Web.Core.Areas.ApiHelp.App_Start;

namespace CloudCore.Web.Core.Areas.ApiHelp
{
    public class ApiHelpAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ApiHelp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HelpPage_Default",
                "api/Help/{action}/{apiId}",
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(System.Web.Http.GlobalConfiguration.Configuration);
        }
    }
}
