using System.Web;
using System.Web.Http;
using CloudCore.Web.Core.Security.Api.Identity;


namespace CloudCore.Web.Core.BaseControllers
{
    [AllowAnonymous]
    public abstract class CloudCoreApiController : ApiController
    {
    

        protected virtual CloudCoreApiIdentity ApiCaller
        {
            get { return HttpContext.Current.User.Identity as CloudCoreApiIdentity; }
        }
    }
}
