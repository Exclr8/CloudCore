using System;
using System.IdentityModel.Services;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Web;
using CloudCore.Configuration.ConfigFile;
using CloudCore.Core.Security;
using CloudCore.Domain;
using CloudCore.Domain.Security;
using CloudCore.Domain.Specifications;
using CloudCore.Web.Core.Security.Authentication.Exceptions;

using CloudCore.Data;
using CloudCore.Data.Buildbase;

namespace CloudCore.Web.Core.Security.Authentication
{
    [Serializable]
    public class LoginException : ApplicationException, ISerializable
    {
        public LoginException() { }

        public LoginException(string message) : base(message) { }

        public LoginException(string message, Exception innerException) : base(message, innerException) { }
    }

    public static class CloudAuthentication
    {
        public static void Logout(HttpSessionStateBase session, HttpResponseBase response)
        {
            var module = FederatedAuthentication.SessionAuthenticationModule;
            module.DeleteSessionTokenCookie();
            module.SignOut();
            session.Abandon();
        }

        public static void LoginInternal(string username, string password, bool rememberMe)
        {
            Login(username, password, rememberMe, true, false);
        }

        public static void LoginExternal(string username, string password, bool rememberMe)
        {
            Login(username, password, rememberMe, false, true);
        }

        public static bool Login(string username, string password, bool rememberMe, bool requiresInternal, bool requiresExternal)
        {
            var dbContext = CloudCoreDB.Context;

            if (HttpContext.Current.Request.IsAuthenticated)
            {
                throw new DuplicateLoginException("You are already logged in. Please sign out first before another login attempt is made.");
            }

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                Cloudcore_User user = dbContext.Cloudcore_User.Where(r => r.Login == username || r.Email == username).SingleOrDefault();

                if (user != null)
                {
                    var encryptedPassword = new Password(password);

                    if (user.UserId != 0 && !encryptedPassword.Compare(user.UserId, user.PasswordHash))
                    {
                        throw new LoginException("The user name or password provided is incorrect.");
                    }
                }
                else
                {
                    throw new LoginException("The user name or password provided is incorrect.");
                }


                if (!user.IntAccess && !user.ExtAccess)
                {
                    throw new LoginException("Could not log you in. Your user account is not active.");
                }


                if ((requiresInternal && user.IntAccess == false) || (requiresExternal && user.ExtAccess == false))
                {
                    throw new LoginException("You are not authorized to access this part of the system.");
                }

                CreateIdentity(user);
                DateTime? lastlogin = DateTime.Now;
                dbContext.Cloudcore_LoginUpdate(user.UserId, CloudCore.Core.Modules.Environment.ApplicationId, ref lastlogin);
                return true;
            }
            else
            {
                throw new LoginException("The user name or password provided is incorrect.");
            }
        }

        internal static void CreateIdentity(Cloudcore_User user)
        {
            var principal = CloudCoreIdentity.GetClaimsPrincipal(user);
            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
            var sam = FederatedAuthentication.SessionAuthenticationModule;
            sam.DeleteSessionTokenCookie();

            var sessionTimeout = ReadConfig.SettingsOnWebApplication.WebSettings.UserSessionTimeout.TimeoutValueInMinutes;
            var token = sam.CreateSessionSecurityToken(principal, WebApplication.Configuration.WebSettings.SiteName, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(sessionTimeout), true);
            
            sam.CookieHandler.Name = Hash.Calculate(WebApplication.Configuration.WebSettings.SiteName);
            sam.WriteSessionTokenToCookie(token);
        }
    }

}
