 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TemplateGenerationTest.Models;



namespace TemplateGenerationTest.Controllers
{
    public class SearchModifyController : Controller
    {
        public ActionResult Modify()
        {
            var model = new ModifyModel();
            return View(model);
        }

		public ActionResult Modify(ModifyModel model)
        {
			return View(model);
        }
	}
}