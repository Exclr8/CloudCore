 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TemplateGenerationTest.Models;

namespace TemplateGenerationTest.Controllers
{
    public class DetailsDetailsController : Controller
    {
        public ActionResult Details()
        {
            var model = new DetailsModel();
            return View(model);
        }

		public ActionResult Details(DetailsModel model)
        {
			return View(model);
        }
	}
}