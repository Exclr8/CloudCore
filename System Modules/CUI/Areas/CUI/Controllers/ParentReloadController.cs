using System.Web.Mvc;

namespace CloudCore.Web.Controllers
{
    public class ParentReloadController : Controller
    {
        public ActionResult DoParentReload(string redirectUrl)
        {
            this.ViewBag.RedirectUrl = redirectUrl;
            return View();
        }

    }
}