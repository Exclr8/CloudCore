using System.Web.Mvc;

namespace CloudCore.Web.Core.Areas.Core
{
    public class CoreAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Core";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Core",
                "Core/{controller}/{action}/{id}",
                new { controller = "", action = "", area="Core", id = UrlParameter.Optional },
                new string[] { "CloudCore.Web.Core.Areas.Core.Controllers" } 
            );
        }
    }
}
