using System.Web.Mvc;

namespace CloudCore.WebModuleTest.Areas.Bleep
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get 
            {
                return "Test";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Test_default",
                "Test/{controller}/{action}/{id}",
                new { controller = "Main", action = "Index", area = "Test", id = UrlParameter.Optional },
                new[] { "CloudCore.WebModuleTest.Areas.Test.Controllers" }
            );
        }
    }
}