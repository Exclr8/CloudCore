namespace CloudCore.Web.Core.Razor.Extensions
{
    public static partial class FrameworkExtensions
    {
        public static string ScriptTag(string reference)
        {
            return string.Format("<script src=\"{0}\" type=\"text/javascript\" ></script>\r\n", reference);
        }

        public static string StyleSheetTag(string reference)
        {
            return string.Format("<link href=\"{0}\" rel=\"Stylesheet\" ></link>\r\n", reference);
        }
    }
}
