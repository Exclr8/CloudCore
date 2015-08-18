using System.Web.Mvc;
using CloudCore.Web.Core.LayoutAttributes;
using CloudCore.Web.Core.Security.Authentication;


namespace CloudCore.Web.Core.BaseControllers
{
    [AuthenticatedPopupLayout]
    [CloudCoreAuthenticated]
    public abstract class AuthenticatedPopupController : PopupController
    {
    }
}
