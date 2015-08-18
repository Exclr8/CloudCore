using System;
using System.Web.Mvc;
using CloudCore.Admin.Models;
using CloudCore.Web.Core.BaseControllers;


namespace CloudCore.Admin.Controllers
{
    public class SystemValuesController : InternalAuthenticatedController
    {
        public ActionResult Create()
        {
            var model = new SystemValueCategoryCreateModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(SystemValueCategoryCreateModel model)
        {
            model.CreateCategory();
            return RedirectToAction("Details", new { CategoryId = model.CategoryId });
        }

        public ActionResult Search()
        {
            var model = new SystemValueCategorySearchModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(SystemValueCategorySearchModel model)
        {
            model.Search();
            return View(model);
        }


        public ActionResult Details(int categoryId)
        {
            var model = new SystemValueCategoryDetailsModel();
            model.CategoryId = categoryId;
            model.GetSystemValues();
            return View(model);
        }

        public ActionResult AddSystemValue(int CategoryId)
        {
            var model = new SystemValueCreateModel();
            model.CategoryId = CategoryId;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSystemValue(SystemValueCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddSystemValue();
                    ShowSuccessMessage("System Value sucessfully added.");
                    return RedirectToAction("Details", new { CategoryId = model.CategoryId });
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
            return View(model);
        }

        public ActionResult ModifySystemValue(int ValueId)
        {
            var model = new SystemValueUpdateModel();
            model.ValueId = ValueId;
            return View(model);
        }

        [HttpPost]
        public ActionResult ModifySystemValue(SystemValueUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Update();
                    ShowSuccessMessage("System Value sucessfully updated.");
                    return RedirectToAction("Details", new { CategoryId = model.SystemValue.CategoryId });
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
            return View(model);
        }

    }
}
