using System.Web.Mvc;

namespace CloudCore.Web.Core.Areas.Activities
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
                name: AreaName + "_default",
                url: AreaName + "/{controller}/{action}/{id}",
                defaults: new { controller = "Main", action = "Index", area = AreaName, id = UrlParameter.Optional },
                namespaces: new[] { "CloudCore.Activities.Controllers" }
            );
        }
    }
}