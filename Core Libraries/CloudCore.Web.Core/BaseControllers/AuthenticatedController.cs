using CloudCore.Web.Core.Security.Authentication;

namespace CloudCore.Web.Core.BaseControllers
{
    [CloudCoreAuthenticated]
    public abstract class AuthenticatedController : CoreController
    {        
    }
}
