 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TemplateGenerationTest.Models;



namespace TemplateGenerationTest.Controllers
{
    public class CreateCreateController : Controller
    {
        public ActionResult Create()
        {
            var model = new CreateModel();
            return View(model);
        }

		public ActionResult Create(CreateModel model)
        {
			return View(model);
        }
	}
}