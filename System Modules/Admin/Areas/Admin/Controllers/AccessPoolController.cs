using System.Web.Mvc;
using CloudCore.Admin.Models;
using CloudCore.Web.Core.BaseControllers;

namespace CloudCore.Admin.Controllers
{
    public class AccessPoolController : InternalAuthenticatedController
    {
        public ActionResult Create()
        {
            var model = new AccessPoolContextModel();
            model.CreateNew();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AccessPoolContextModel model)
        {
            if (ValidateAndExecute(model.Insert, string.Format("Access Pool {0} Created Successfully", model.AccessPoolName)))
                return RedirectToAction("Details", "AccessPool", new { accesspoolId = model.AccessPoolId });

            return View(model);
        }

        public ActionResult Modify(int accesspoolId)
        {
            var model = new AccessPoolContextModel { AccessPoolId = accesspoolId };
            return View(model);
        }

        [HttpPost]
        public ActionResult Modify(AccessPoolContextModel model)
        {
            ValidateAndExecute(model.Modify, string.Format("Access Pool {0} updated successfully", model.AccessPoolName));
            return View(model);
        }

        public ActionResult Search()
        {
            var model = new AccessPoolSearchModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(AccessPoolSearchModel model)
        {
            model.Search();
            return View(model);
        }

        public ActionResult Details(int accesspoolId)
        {
            var model = new AccessPoolContextModel { AccessPoolId = accesspoolId };
            return View(model);
        }

        public ActionResult Remove(int accesspoolId, int userId)
        {
            ValidateAndExecute(() =>
            {
                var model = new AccessPoolContextModel { AccessPoolId = accesspoolId };
                model.RemoveUserFromPool(userId);
            }, "User has been removed from the Access Pool successfully.");

            return RedirectToAction("Details", "AccessPool", new { accesspoolId });
        }
    }
}
