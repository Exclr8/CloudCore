using System.Web.Mvc;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseControllers;


namespace CloudCore.Web.Controllers
{
    public class OfflineController : AnonymousController
    {
        public ActionResult Index()
        {
            if (AppSettings.GetConfiguration("Offline", "false").ToLower() == "false")
                return Redirect("~/");
            else
                return View();
        }
    }
}
