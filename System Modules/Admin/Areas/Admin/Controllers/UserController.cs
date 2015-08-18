using System;
using System.Data.SqlClient;
using System.Web.Helpers;
using System.Web.Mvc;
using CloudCore.Admin.Models;
using CloudCore.Domain;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Security.Authentication;

using Frameworkone.ThirdParty.PostageApp;

namespace CloudCore.Admin.Controllers
{
    public class UserController : InternalAuthenticatedController
    {
        public ActionResult Details(int userId)
        {
            var model = new UserContextModel() { UserId = userId };
            return View(model);
        }

        #region Modify User
        public ActionResult Update(int userId)
        {
            var model = new UserContextModel() { UserId = userId };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UserContextModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     var image = WebImage.GetImageFromRequest();
                      model.Update();
                    model.UpdateImage(image);

                }

                throw new AggregateException(Common.GetErrorListFromModelState(ModelState));
            }
            catch (Exception error)
            {
                ShowErrorMessage(error.Message);
            }



            return View(model);
        }

        #endregion

        #region Access Pools
        public void DeleteAccessPoolFromUser(int accessPoolId, int userId)
        {
            var model = new UserContextModel() { Key = userId };
            try
            {
                if (ModelState.IsValid)
                {
                    model.UserId = userId;
                    model.RemoveUserFromAccessPool(accessPoolId);

                    ShowSuccessMessage("AccessPool has been successfully removed.");

                    RedirectToAction("Details", new { userId }).ExecuteResult(ControllerContext);
                }
                else
                {
                    ShowErrorMessage(Common.GetErrorListFromModelState(ModelState));
                }
            }
            catch (SqlException sqlError)
            {
                ShowErrorMessage(sqlError.Message);
            }
        }

        #endregion

        #region Search
        public ActionResult Search()
        {
            var model = new UserSearchModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(UserSearchModel model)
        {
            model.Search();
            return View(model);
        }

        #endregion

        #region Create New
        public ActionResult Create()
        {
            var model = new UserContextModel();
            model.CreateNew();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserContextModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Insert();
                    ShowSuccessMessage("User created successfully.");
                    // TODO: The "password reset" mail template is not the correct welcoming mail for a new user.
                    RequestPasswordReset(model);
                    return RedirectToAction("Details", "User", new { userId = model.UserId });
                }

                ShowErrorMessage(Common.GetErrorListFromModelState(ModelState));

            }
            catch (SqlException sqlError)
            {
                ShowErrorMessage(sqlError.Message);
            }

            return View();
        }

        #endregion

        #region User Access
        public ActionResult UserAccessStatus(int userId)
        {
            var model = new UserContextModel() { UserId = userId };
            ShowMessage("If the internal and the external access is deactivated the user will not be able to log into the system. All reporting and work done on the system will still reflect against the user.");
            return View(model);
        }

        [HttpPost]
        public ActionResult UserAccessStatus(UserContextModel model)
        {
            try
            {
                model.UpdateUserAccess();
                ShowSuccessMessage(model.InternalAccess || model.ExternalAccess ? "User access has been changed." : "User has been deactivated.");

                return View(model);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }

            return View();
        }

        private void RequestPasswordReset(UserContextModel model)
        {
            var passwordResetReferenceGuid = model.GetPasswordResetGuid();

            var mailMan = new PostageAppClient();
            mailMan.SendResetPasswordEmail(
                model.Email,
                HttpContext.Request.Url.Scheme,
                HttpContext.Request.Url.Authority,
                passwordResetReferenceGuid);
        }

        #endregion

        #region Password Management
        public ActionResult UserResetPassword(int userId)
        {
            var model = new UserContextModel() { UserId = userId };
            return View(model);
        }

        [HttpPost]
        public ActionResult UserResetPassword(UserContextModel model)
        {
            try
            {
                RequestPasswordReset(model);
                ShowSuccessMessage("A password reset e-mail has been sent to this user successfully.");
                return RedirectToAction("Details", new { userId = model.UserId });
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }

            return View(model);
        }

        #endregion
    }
}


