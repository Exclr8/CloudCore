using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace CloudCore.Web.Core.BaseControllers
{
    public abstract class PopupController : CoreController
    {
        public ActionResult ClosePopUpResult()
        {
            return RedirectToActionPermanent("DoParentReload", "ParentReload", new { area = "CUI", redirectUrl = "parent.window.document.location.href" });
        }

        public ActionResult ClosePopUpResult(string actionName, string controllerName, object routeValues = null)
        {
            var redirectUrl = CreateRedirectParentUrl(actionName, controllerName, routeValues);
            return RedirectToActionPermanent("DoParentReload", "ParentReload", new { area = "CUI", redirectUrl = string.Format("'{0}'", redirectUrl) });
        }

        private string CreateRedirectParentUrl(string actionName, string controllerName, object routeValues)
        {
            var urlHelper = new UrlHelper(Request.RequestContext);
            var reloadParentUrl = urlHelper.Action(actionName, controllerName, routeValues);

            return reloadParentUrl;
        }
    }
}
