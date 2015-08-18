using System.Web.Mvc;

namespace CloudCore.Web.Core.Helpers
{
    public static class ControlWrappers
    {
        public static MvcHtmlString FileUpload(this HtmlHelper htmlHelper, string name, int width, string extension)
        {
            var script = string.Format(@"<script type=""text/javascript"">RegisterStandardFileInput('{0}')</script>", name);
            return new MvcHtmlString(string.Format("<input type=\"file\" id=\"{0}\" name=\"{0}\" style=\"width: {1}px !important;\" filetype=\"{2}\" />{3}", name, (70 + width), extension, script));
        }
    }
}
