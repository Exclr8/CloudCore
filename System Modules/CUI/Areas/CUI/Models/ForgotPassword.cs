using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using CloudCore.Domain;
using Frameworkone.ThirdParty.PostageApp;

using CloudCore.Data;

namespace CloudCore.Web.Models
{
    public class ForgotPassword
    {
        [Required(ErrorMessage = "Please enter Login/Email Address.")]
        [Display(Name = "Login/Email Address")]
        public string UserName { get; set; }

        internal void RequestResetPassword(UrlHelper url)
        {
   
            Guid? passwordResetReferenceGuid = null;
            CloudCoreDB.Context.Cloudcore_UserResetPasswordRequest(UserName, ref passwordResetReferenceGuid);

            var mailMan = new PostageAppClient();

            if (passwordResetReferenceGuid != null)
            {
                var response = mailMan.SendResetPasswordEmail(UserName, HttpContext.Current.Request.Url.Scheme,
                    HttpContext.Current.Request.Url.Authority, passwordResetReferenceGuid.Value);

                if (!response.ApiSuccessfullyCalled)
                    throw new Exception("An error occured while trying to send email.");
            }
        }
    }
}