using System.Configuration;
using System.Text;
using CloudCore.Configuration.ConfigFile;
using CloudCore.Logging;
using CloudCore.Web.Core.Caching;
using CloudCore.Web.Core.Extensions;
using CloudCore.Web.Core.Security.Authentication;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class UrlExtensions
    {
        public static string Asset(this System.Web.Mvc.UrlHelper helper, string reference)
        {
            string area = helper.RequestContext.HttpContext.Request.QueryString["area"];
            
            if (string.IsNullOrWhiteSpace(area))
                area = (string)helper.RequestContext.RouteData.DataTokens["area"];

            return Asset(helper, reference, area);
        }

        public static string Asset(this System.Web.Mvc.UrlHelper helper, string reference, string area)
        {
            return helper.Action("ByHash", "Asset", new { area = "Core", id = AssetResolver.GetVirtualCode(reference, area) });
        }

        public static string UserProfile(this System.Web.Mvc.UrlHelper helper)
        {
            return helper.Action("UserProfile", "Asset", new { area = "Core", ver = Web.Core.Caching.UserProfile.GetCacheGuid() });
        }

        public static string UserState(this System.Web.Mvc.UrlHelper helper)
        {
            return helper.Action("UserState", "Asset", new { area = "Core", ver = Web.Core.Caching.UserState.GetCacheGuid() });
        }

        public static string Logo(this System.Web.Mvc.UrlHelper helper)
        {
            return helper.Action("Logo", "Asset", new { area = "Core", ver = Web.Core.Caching.ApplicationProfile.GetCacheGuid() });
        }

        public static string ApplicationProfile(this System.Web.Mvc.UrlHelper helper)
        {
            return helper.Action("ApplicationProfile", "Asset", new { area = "Core", ver = Web.Core.Caching.ApplicationProfile.GetCacheGuid() });
        }


        public static string Menus(this System.Web.Mvc.UrlHelper helper)
        {
            return helper.Action("MenuData", "Asset", new { area = "Core", ver = MenuData.GetCacheGuid() });
        }

        public static string LoginReference(this System.Web.Mvc.UrlHelper helper)
        {
            return helper.Action("LoginReference", "Asset", new { area = "Core", sessionid = helper.RequestContext.HttpContext.Session.SessionID, uid = CloudCoreIdentity.UserId });
        }

        public static string SessionProtectionReference(this System.Web.Mvc.UrlHelper helper)
        {
            return helper.Action("SessionProtectionScript", "Asset", new { area = "Core", loginguid = CloudCoreIdentity.Email });
        }

        public static string ActionNoEncode(this System.Web.Mvc.UrlHelper helper, string actionName, string controllerName, object routeValues = null)
        {
             
            var nAction = helper.Action(actionName, controllerName);
            
            var sb = new StringBuilder(nAction);

            if (routeValues != null)
                if (routeValues.GetType().GetProperties().GetLength(0) > 0)
                {
                    sb.Append("?");

                    foreach (var rV in routeValues.GetType().GetProperties())
                        sb.Append(string.Format("{0}={1}&", rV.Name, rV.GetValue(routeValues, null)));
                }
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
             
        }
    }


}
