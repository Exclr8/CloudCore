using System.Text;
using System.Web.Mvc;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static partial class FrameworkExtensions
    {
        public static MvcHtmlString InternalFrameworkAssets(this HtmlHelper helper, bool isPopUp = false)
        {
            var assetsScript = new StringBuilder();
            
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            if (!isPopUp)
            {
                AppendUserAndApplicationFrameworkAssets(urlHelper, assetsScript);
            }            
            
            return new MvcHtmlString(assetsScript.ToString());
        }

        private static void AppendUserAndApplicationFrameworkAssets(UrlHelper urlHelper, StringBuilder assetsScript, bool isPopUp = false)
        {
            assetsScript.Append(ScriptTag(urlHelper.ApplicationProfile()));
            assetsScript.Append(ScriptTag(urlHelper.UserProfile()));
            assetsScript.Append(ScriptTag(urlHelper.UserState()));
            assetsScript.Append(ScriptTag(urlHelper.SessionProtectionReference()));
        }
    }
}