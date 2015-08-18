using System.Web.Mvc;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public enum ImageSize
    {
        small,
        medium,
        large
    }

    public static class PoweredByExtension
    {
        public static MvcHtmlString PoweredByCloudCore(this System.Web.Mvc.HtmlHelper helper, ImageSize imageSize)
        {
            var urlHelper = new System.Web.Mvc.UrlHelper(helper.ViewContext.RequestContext);
            
            string imageSourceUrl = urlHelper.Asset(string.Format("poweredby/{0}.png", imageSize), "CUI");

            return new MvcHtmlString(string.Format("<a href=\"http://www.exclr8.co.za/#cloudcore\" target=\"_blank\"><img style=\"border: 0\" src=\"{0}\" /></a>", imageSourceUrl));
        }
    }
}
