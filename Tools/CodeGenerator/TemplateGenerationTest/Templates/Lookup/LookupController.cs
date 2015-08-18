 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TemplateGenerationTest.Models;



namespace TemplateGenerationTest.Controllers
{
    public class LookupLookupController : Controller
    {
        public ActionResult Lookup()
        {
            var model = new LookupModel();
            return View(model);
        }

		public ActionResult Lookup(LookupModel model)
        {
			return View(model);
        }
	}
}