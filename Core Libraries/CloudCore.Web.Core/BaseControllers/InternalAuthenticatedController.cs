using CloudCore.Web.Core.LayoutAttributes;
using CloudCore.Web.Core.Security;

namespace CloudCore.Web.Core.BaseControllers
{
    [LoggedInCloudCoreLayout]
    [ValidateMultipleTabLogin]
    public abstract class InternalAuthenticatedController : AuthenticatedController
    {
    }
}
