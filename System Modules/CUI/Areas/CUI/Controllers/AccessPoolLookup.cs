using System.Web.Mvc;
using CloudCore.Web.Models;

namespace CloudCore.Web.Controllers
{
    public partial class CUIPopupController
    {
        public ActionResult AccessPoolLookup(string idName = null, string valueName = null)
        {
            var model = new AccessPoolLookupModel
            {
                LookupInputId = idName,
                LookupInputIdValue = valueName
            };
            return PartialView("AccessPoolLookup", model);
        }

        [HttpPost]
        public ActionResult AccessPoolLookup(AccessPoolLookupModel model)
        {
            model.Search();
            return PartialView("AccessPoolLookup", model);
        }

    }
}
