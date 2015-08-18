using CloudCore.Web.Core.LayoutAttributes;


namespace CloudCore.Web.Core.BaseControllers
{
    /// <summary>
    /// Should be inherited by your controllers for external actions, non-popups.
    /// Provides notification and notification redirect functionality.
    /// Includes external layout for unauthorised and non-authenticated users
    /// All views loaded by this controller will use the external (logged-out state) layout
    /// </summary>
    [LoggedOutCloudCoreLayout]
    public abstract class AnonymousController : CoreController
    {
    }
}
