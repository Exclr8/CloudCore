using System;
using System.Security;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CloudCore.Core.Security.Api;
using CloudCore.Web.Core.Security.Api.Identity;


namespace CloudCore.Web.Core.Security.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class UserSecurityAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var secretToken = actionContext.HttpContext.Request.Headers["USER_TOKEN_KEY"];
            if (secretToken != null)
            {
                if (String.IsNullOrWhiteSpace(secretToken))
                {
                    throw new Exception("USER_TOKEN_KEY was not found in the HTTP request headers.");
                }

                // TODO: Get rid of this when we have a better way of doing it
                //var cacheProvider = ObjectFactory.GetInstance<ICacheProvider>();
                var accessToken = AccessToken.ReadFromCache(secretToken);//, null);

                if (accessToken == null)
                {
                    throw new SecurityException("Application Not Authorised.");
                }

                var identity = new CloudCoreApiIdentity();
                identity.AddClaim(new Claim("ApplicationId", accessToken.ApplicationId.ToString()));
                identity.AddClaim(new Claim("UserId", accessToken.UserId.ToString()));

                var principal = new ClaimsPrincipal(identity);

                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
            }
            else
            {
                throw new SecurityException("Valid USER_TOKEN_KEY not found.");
            }
        }
    }
}