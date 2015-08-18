using System.Web.Mvc;

namespace $safeprojectname$.Areas.Activities
{
    public class ActivitiesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Activities";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "$safeprojectname$_activities_default",
                "Activities/{controller}/{action}/{instanceId}",
                new { controller = "Tasklist", action = "Index", area = "CUI", id = UrlParameter.Optional },
                new string[] { "$safeprojectname$.Controllers", "CloudCore.CUI.Controllers" }
            );
        }
    }
}
