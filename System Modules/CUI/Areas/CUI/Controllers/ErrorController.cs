using System.Net;
using System.Web.Mvc;

namespace CloudCore.Web.Controllers
{
    public class ErrorController : Controller
    {   
        [HttpGet]
        public ActionResult GenericError(string logRefId, string message)
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ViewBag.LogRefId = logRefId;
            ViewBag.Message = message;
            return View("Error");
        }
        
        [HttpGet]
        public ActionResult NotFound(string logRefId, string message)
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            ViewBag.LogRefId = logRefId;
            ViewBag.Message = message;
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var defaultAction = Web.Core.WebApplication.Configuration.WebSettings.DefaultAction;
            return RedirectToAction(defaultAction.Action, defaultAction.Controller, new { area = defaultAction.Area });
        }
    }
}
