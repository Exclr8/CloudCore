using System;
using System.Web.Mvc;
using System.Web.UI;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Web.Areas.CUI.Models;

namespace CloudCore.Web.Controllers
{
    public class MainController : InternalAuthenticatedController
    {

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            switch (SessionInfo.ActiveTab)
            {
                case 0: return RedirectToAction("Dashboard", "Main");
                case 1: return RedirectToAction("Menu", "Main");
                case 2: return RedirectToAction("Standard", "Tasklist");
                default:
                    return RedirectToAction("Dashboard", "Main");
            }
        }

        public ActionResult Dashboard()
        {
            SessionInfo.ActiveTab = 0;
            var userId = CloudCoreIdentity.UserId;
            var model = new DashboardModel(userId);
            model.LoadUserDashboardTiles(Url);
            return View(model);
        }

        [HttpPost]
        public JsonResult RemoveDashboardItem(RemoveDashboardItem model)
        {
            var isSuccess = true;

            try
            {
                model.DeleteUserDashboardAllocation();
            }
            catch (Exception)
            {
                isSuccess = false;   
            }

            return Json(new { success = isSuccess });
        }
        
        public ActionResult Menu()
        {
            SessionInfo.ActiveTab = 1;
            return View();
        }

//        public ActionResult SystemAdmin()
//        {
//            
//        }
    }
}
