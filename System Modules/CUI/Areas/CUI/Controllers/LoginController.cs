using CloudCore.Domain;
using System;
using System.Security;
using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Web.Models;
using CloudCore.Web.Core.ActionResults;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Security.Authentication;
using CloudCore.Web.Core.Security.Authentication.Exceptions;

using CloudCore.Data;
using System.Linq;
using CloudCore.Domain.Security;
namespace CloudCore.Web.Controllers
{
    public class LoginController : AnonymousController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new LogOnModel();
            if (HttpContext.Request.IsAuthenticated)
            {
                ViewBag.AlreadyLoggedIn = true;
                ViewBag.UserFullName = CloudCoreIdentity.Fullname;
            }
            else
            {
                ViewBag.AlreadyLoggedIn = false;
            }

            ViewBag.Title = "System Login";
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LogOnModel model, string returnUrl = "")
        {
            ViewBag.AlreadyLoggedIn = false;

            try
            {
                if (ModelState.IsValid)
                {

                    CloudAuthentication.Login(model.UserName, model.Password, model.RememberMe, true, false);
                    return ResumeBrowsing(returnUrl);
                }
            }
            catch (DuplicateLoginException)
            {
                ViewBag.AlreadyLoggedIn = true;
                ViewBag.UserFullName = CloudCoreIdentity.Fullname;
            }
            catch (LoginException ex)
            {
                ShowErrorMessage(string.Format("<br />{0}<br />", ex.Message));
            }

            return View(model);
        }

        private ActionResult ResumeBrowsing(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
            {
                return Redirect(returnUrl);
            }

            return new RedirectToRouteResult(new RouteValueDictionary(new
            {
                action = "Index",
                controller = "Main",
                area = "CUI"
            }));
        }

        public ActionResult SignOut()
        {
            CloudAuthentication.Logout(Session, Response);
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View(new ForgotPassword());
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.RequestResetPassword(Url);
                    ShowSuccessMessage("Email sent successfully.");
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);

                }
            }
            return View(model);
        }

        public ActionResult ResetPassword(string Reference)
        {
            var model = new PasswordResetModel { ReferenceId = Reference };

            try
            {
                model.GetUserDetails( Guid.Parse(Reference));
            }
            catch (SecurityException ex)
            {
                ShowErrorMessage(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult ResetPassword(PasswordResetModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var refGuid = new Guid(model.ReferenceId);
                    var user = CloudCoreDB.Context.Cloudcore_User.Where(usr => usr.ReferenceGuid.Equals(model.ReferenceId)).Select(r => r).SingleOrDefault();
          
                    CloudCoreDB.Context.Cloudcore_UserPasswordUpdate(user.UserId, Password.CreatePasswordHash(user.UserId, model.NewPassword));
     
                    ShowSuccessMessage("Password Saved Successfully.");
                    return RedirectToAction("Index", "Login", new { Area = "CUI" });
                }
            }
            catch (SecurityException ex)
            {
                ShowErrorMessage(ex.Message);
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult IdentificationError(string errorMessage)
        {
            ViewBag.Message = errorMessage;
            return View();
        }

        [HttpPost]
        public ActionResult IdentificationError(string btnMainSite, string btnSignOut)
        {
            if (string.IsNullOrEmpty(btnMainSite))
            {
                CloudAuthentication.Logout(Session, Response);
                return new RedirectToLogin();
            }

            return new RedirectToDefault();
        }
    }
}
