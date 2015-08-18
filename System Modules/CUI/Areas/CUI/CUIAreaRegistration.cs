using System.Web.Mvc;

namespace CloudCore.Web
{
    public class CuiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CUI";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CUI_default",
                "CUI/{controller}/{action}/{id}",
                 new { controller = "Main", action = "Index", area = "CUI", id = UrlParameter.Optional },
                 new[] { "CloudCore.Web.Controllers" }
            );
        }
    }
}
