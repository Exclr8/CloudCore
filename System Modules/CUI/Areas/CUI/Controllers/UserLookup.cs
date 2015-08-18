using System.Web.Mvc;
using CloudCore.Web.Models;

namespace CloudCore.Web.Controllers
{
    public partial class CUIPopupController
    {
        public ActionResult UserLookup(string idName, string valueName)
        {
            UserLookupModel model = new UserLookupModel
            {
                LookupInputId = idName,
                LookupInputIdValue = valueName
            };
            
            return PartialView("UserLookup", model);
        }

        [HttpPost]
        public ActionResult UserLookup(UserLookupModel model)
        {
            model.Search();
            return PartialView("UserLookup", model);
        }

    }
}
