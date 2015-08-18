using System.Configuration;
using System.Web.Mvc;
using CloudCore.Data;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Security.Authentication;
using CloudCore.Web.Models;

namespace CloudCore.Web.Controllers
{
    public class SubMenuController : InternalAuthenticatedController
    {
        public ActionResult SystemAdmin()
        {
            var model = new SystemAdminModel();
            model.LoadPages();
            return View(model);
        }        
    }
}