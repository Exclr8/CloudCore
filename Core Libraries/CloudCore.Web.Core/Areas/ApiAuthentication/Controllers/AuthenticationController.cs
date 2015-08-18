using System;
using System.Data;
using System.Linq;
using System.Security;
using System.Web.Http;
using CloudCore.Api.Models;
using CloudCore.Core.Security;
using CloudCore.Core.Security.Api;
using CloudCore.Domain;
using CloudCore.Domain.Security;
using CloudCore.Domain.Specifications;
using CloudCore.Web.Core.Areas.ApiAuthentication.Models.Request;
using CloudCore.Web.Core.Areas.ApiAuthentication.Models.Response;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Security.Api.Attributes;
using CloudCore.Web.Core.Security.Api.Filters;

using CloudCore.Data;
using System.Data.Linq;
using Frameworkone.ThirdParty.PostageApp;

namespace CloudCore.Web.Core.Areas.ApiAuthentication.Controllers
{
    [CloudCoreExceptionFilter]
    public class AuthenticationController : CloudCoreApiController
    {
      //  private readonly ICacheProvider cacheProvider;

        public AuthenticationController()//, ICacheProvider cacheProvider)
            : base()
        {
            //this.cacheProvider = cacheProvider;
        }

        private ApiToken CreateSecretToken(int applicationId, int userId, string tokenKeyName)
        {
            var accessToken = new AccessToken( applicationId, userId);//, cacheProvider);
            
            accessToken.UpdateUserLogin();
            accessToken.WriteToCache();
            
            return new ApiToken
            {
                TokenKey = accessToken.Secret,
                TokenKeyName = tokenKeyName,
                ExpiryUtc = accessToken.Expiry.ToUniversalTime().ToString(@"o")
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public ApiToken Authorize([FromBody]ApplicationAuthorization data)
        {
            var app = CloudCoreDB.Context.Cloudcore_SystemApplication.Where(sa => sa.ApplicationGuid == Guid.Parse(data.ApplicationKey)).FirstOrDefault();

            if (app == null)
            {
                throw new SecurityException("Unidentified application or application key invalid.");
            }

            if (!app.Enabled)
            {
                throw new SecurityException("This application is no longer enabled for access.");
            }

            return CreateSecretToken((int)app.ApplicationId, 0, "APP_TOKEN_KEY");
        }

        [HttpPost]
        [ApplicationSecurity]
        public ApiToken Login([FromBody]UserAuthorization data)
        {
            var user = (from u in CloudCoreDB.Context.Cloudcore_User
                        where (u.Login == data.UserName)
                        select u).SingleOrDefault();

            if (user == null)
            {
                throw new SecurityException("User does not exist or username is invalid.");
            }

            if (!(user.ExtAccess || user.IntAccess))
            {
                throw new SecurityException("User is not enabled for access to this system.");
            }

            string hashedPassword = new Password(data.Password).CreatePasswordHash((int)user.UserId);

            if (user.PasswordHash != hashedPassword)
            {
                throw new SecurityException("Invalid username or password.");
            }

            return CreateSecretToken(ApiCaller.ApplicationId, (int)user.UserId, "USER_TOKEN_KEY");
        }

        [HttpPost]
        [AllowAnonymous]
        public SingleAuthenticationResponseModel SingleAuthenticate([FromBody]SingleAuthenticationRequestModel data)
        {
            var applicationToken = Authorize(data.ApplicationData);

            InitialiseApiCaller(applicationToken);

            return new SingleAuthenticationResponseModel
            {
                ApplicationToken = applicationToken,
                UserToken = Login(data.UserData)
            };
        }

        private void InitialiseApiCaller(ApiToken applicationToken)
        {
            var applicationSecurityAttribute = new ApplicationSecurityAttribute();
            var actionContext = new System.Web.Http.Controllers.HttpActionContext();

            Request.Headers.Add(applicationToken.TokenKeyName, applicationToken.TokenKey);

            actionContext.ControllerContext = this.ControllerContext;
            applicationSecurityAttribute.OnActionExecuting(actionContext);
        }

        [HttpPost]
        [UserSecurity]
        public ApiToken ChangePassword([FromBody]PasswordChange data)
        {
            var user = CloudCoreDB.Context.Cloudcore_User.First(u => u.UserId == ApiCaller.UserId);

            string oldPasswordHash = Password.CreatePasswordHash(user.UserId, data.OldPassword);

            if (user.PasswordHash != oldPasswordHash)
            {
                throw new SecurityException("Old password specified is not correct.");
            }

            if (data.NewPassword == data.OldPassword)
            {
                throw new SecurityException("New password may not be the same as the old password.");
            }



            CloudCoreDB.Context.Cloudcore_UserPasswordUpdate(user.UserId, Password.CreatePasswordHash(user.UserId, data.NewPassword));


            return CreateSecretToken(ApiCaller.ApplicationId, ApiCaller.UserId, "USER_TOKEN_KEY");
        }

        [HttpPost]
        [ApplicationSecurity]
        public void ResetPassword([FromBody]ResetPassword data)
        {
            Guid? passwordResetReferenceGuid = null;
            CloudCoreDB.Context.Cloudcore_UserResetPasswordRequest(data.LoginOrEmail, ref passwordResetReferenceGuid);
            var mailMan = new PostageAppClient();
            mailMan.SendResetPasswordEmail(data.LoginOrEmail, Request.RequestUri.Scheme, Request.RequestUri.Authority, passwordResetReferenceGuid.Value);
        }

        [HttpGet]
        [UserSecurity]
        public UserDetails UserDetails()
        {

            return (from usr in CloudCoreDB.Context.Cloudcore_User
                    where usr.UserId == this.ApiCaller.UserId
                    select new UserDetails
                    {
                        Firstname = usr.Firstnames,
                        Surname = usr.Surname,
                        Email = usr.Email,
                        CellNo = usr.CellNo,
                        LastPasswordChangeUTC = usr.PasswordChanged.ToUniversalTime().ToString(@"o")
                    }).SingleOrDefault();
        }

        [HttpGet]
        [ApplicationSecurity]
        public ApplicationDetails ApplicationDetails()
        {
            return (from app in CloudCoreDB.Context.Cloudcore_SystemApplication
                    where app.ApplicationId == this.ApiCaller.ApplicationId
                    select new ApplicationDetails
                    {
                        ApplicationName = app.ApplicationName,
                        CompanyName = app.CompanyName,
                        ContactNumber = app.ContactNumber,
                        ContactPerson = app.ContactPerson

                    }).SingleOrDefault();
        }
    }
}