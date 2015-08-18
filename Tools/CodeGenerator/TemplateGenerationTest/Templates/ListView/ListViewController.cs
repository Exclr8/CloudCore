 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TemplateGenerationTest.Models;



namespace TemplateGenerationTest.Controllers
{
    public class SearchListViewController : Controller
    {
        public ActionResult ListView()
        {
            var model = new ListViewModel();
            return View(model);
        }

		public ActionResult ListView(ListViewModel model)
        {
			return View(model);
        }
	}
}