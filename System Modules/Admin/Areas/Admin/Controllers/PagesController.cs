using System.Web.Mvc;
using CloudCore.Admin.Models;
using CloudCore.Web.Core.BaseControllers;


namespace CloudCore.Admin.Controllers
{
    public class PagesController : InternalAuthenticatedController
    {
        public ActionResult Search()
        {
            var model = new PagesSearchModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(PagesSearchModel model)
        {
            model.Search();
            return View(model);
        }

        public ActionResult Details(int actionId)
        {
            var model = new PagesModel();
            model.ActionId = actionId;
            model.LoadAccessPools();
            return View(model);
        }

        public ActionResult RemoveAccessPoolFromPage(int actionId, int accessPoolId)
        {
            var model = new PagesModel { ActionId = actionId };
            model.RemovePageFromPool(accessPoolId);

            ShowSuccessMessage("Access Pool removed successfully.");
            return RedirectToAction("Details", "Pages", new { actionId = model.ActionId });
        }

        public ActionResult ShowWithoutRights()
        {
            var model = new PageWithoutRightsModel();
            model.Search();
            return View(model);
        }
    }
}
