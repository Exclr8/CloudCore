using System;
using System.Web;
using System.Web.Mvc;
using CloudCore.Web.Core.Security.Authentication;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class MvcSessionProtectionReference
    {
        public static MvcHtmlString SessionProtectionReference(this System.Web.Mvc.HtmlHelper helper)
        {
            var scriptTextToReturn = string.Empty;

                var scriptBuilder = new TagBuilder("script");
                scriptBuilder.MergeAttribute("type", "text/javascript");
                scriptBuilder.MergeAttribute("src", new System.Web.Mvc.UrlHelper( helper.ViewContext.RequestContext ).SessionProtectionReference());

                scriptTextToReturn += scriptBuilder.ToString(TagRenderMode.SelfClosing);

            return new MvcHtmlString(scriptTextToReturn);
        }

    }

        public class SessionProtectionScript
        {

            private string GetTokenText()
            {
                var tokenBuilder = new TagBuilder("input");
                tokenBuilder.MergeAttribute("type", "hidden");
                tokenBuilder.MergeAttribute("id", string.Format("__ccsession{0}", GetNewRandomHtmlElementId()));
                tokenBuilder.MergeAttribute("name", "__ccsession");
                tokenBuilder.MergeAttribute("value", CloudCoreIdentity.Email);

                return tokenBuilder.ToString(TagRenderMode.SelfClosing);
            }

            private string GetNewRandomHtmlElementId()
            {
                return Guid.NewGuid().ToString().Replace("{", string.Empty).Replace("}", string.Empty).Replace("-", string.Empty);
            }

            public string GetScript()
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                else
                    return "$(document).ready(function () {" +
                       "    var sessionInputTag = '" + GetTokenText() + "';" +
                       "    $('form').append(sessionInputTag);" +
                       "});";
            }

    }
}
