using System.Web.Mvc;
using CloudCore.Web.Core.LayoutAttributes;


namespace CloudCore.Web.Core.BaseControllers
{
    /// <summary>
    /// Should be inherited by your controllers for non-authenticated popup actions 
    /// Provides notification functionality, no notification redirect functionality, and 
    /// uses a popup layout for non-authenticated (anonymous) users.
    /// </summary>
    [AnonymousPopupLayout]
    public abstract class AnonymousPopupController : PopupController
    {
    }
}
