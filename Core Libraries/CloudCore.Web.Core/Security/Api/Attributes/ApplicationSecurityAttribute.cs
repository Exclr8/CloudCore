using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using CloudCore.Core.Security.Api;
using CloudCore.Web.Core.Security.Api.Identity;

namespace CloudCore.Web.Core.Security.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ApplicationSecurityAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            IEnumerable<string> apiKeyHeaderValues;
            if (actionContext.Request.Headers.TryGetValues("APP_TOKEN_KEY", out apiKeyHeaderValues))
            {
                var secretToken = apiKeyHeaderValues.First();

                if (secretToken != null)
                {
                    if (String.IsNullOrWhiteSpace(secretToken))
                    {
                        throw new ArgumentNullException("actionContext");
                    }

                    // TODO: Get rid of this when we have a better way of doing it
                    //var cacheProvider = ObjectFactory.GetInstance<ICacheProvider>();
                    var accessToken = AccessToken.ReadFromCache(secretToken);

                    if (accessToken == null)
                    {
                        throw new SecurityException("Valid APP_TOKEN_KEY not found or has expired.");
                    }

                    var identity = new CloudCoreApiIdentity();
                    identity.AddClaim(new Claim("ApplicationId", accessToken.ApplicationId.ToString()));
                    identity.AddClaim(new Claim("UserId", "0")); // user is the "system"

                    var principal = new ClaimsPrincipal(identity);

                    Thread.CurrentPrincipal = principal;
                    HttpContext.Current.User = principal;
                }
            }
            else
            {
                throw new SecurityException("Valid APP_TOKEN_KEY not found.");
            }
        }
    }
}