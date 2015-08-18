 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TemplateGenerationTest.Models;



namespace TemplateGenerationTest.Controllers
{
    public class DeleteDeleteController : Controller
    {
        public ActionResult Delete()
        {
            var model = new DeleteModel();
            return View(model);
        }

		public ActionResult Delete(DeleteModel model)
        {
			return View(model);
        }
	}
}