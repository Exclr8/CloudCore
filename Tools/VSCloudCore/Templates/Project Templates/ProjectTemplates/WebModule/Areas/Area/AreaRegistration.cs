using System.Web.Mvc;

namespace $safeprojectname$.Areas.$webmodule.areaname$
{
    public class $webmodule.areaname$AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "$webmodule.areaname$";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "$webmodule.areaname$_default",
                "$webmodule.areaname$/{controller}/{action}/{id}",
                new { controller = "Main", action = "Index", area = this.AreaName, id = UrlParameter.Optional },
                new string[] { "$safeprojectname$.Areas.$webmodule.areaname$.Controllers" }
            );
        }
    }
}
