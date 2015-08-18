using System.Web.Mvc;
using CloudCore.Core.Serialization;
using CloudCore.Web.Core.BaseControllers;


namespace CloudCore.Web.Controllers
{
    public class AccessController : AuthenticatedController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Denied()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Undefined(string displayText)
        {
            dynamic displayItem = new Expando();
            displayItem.Text = displayText;
            return View(displayItem);
        }

    }
}
