using System;
using System.Text;
using System.Web.Mvc;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class Images
    {
        private const string ImagePlaceHolderName = "0.png";
        private const string Area = "CUI";

        public static MvcHtmlString UploadImageNoThumb(this System.Web.Mvc.HtmlHelper helper, string name)
        {
            return helper.UploadImage(name, null, null, null);
        }

        public static MvcHtmlString UploadImage(this System.Web.Mvc.HtmlHelper helper, string name, byte[] DisplayImage, int? thumbWidth, int? thumbHeight)
        {
            var tbMainSpan = new TagBuilder("span");
            var uploadFile = string.Format(@"<input type=""file"" name=""{0}"" />", name);
            string imageDisplay = string.Empty;

            if (DisplayImage != null)
                imageDisplay = helper.Image(DisplayImage, thumbWidth, thumbHeight).ToString();

            tbMainSpan.InnerHtml = uploadFile + imageDisplay;

            return new MvcHtmlString(tbMainSpan.ToString());
        }

        public static MvcHtmlString Image(this System.Web.Mvc.HtmlHelper helper, byte[] dbImage, int? width, int? height)
        {
            var imageString = BuildImage(helper, dbImage, width, height);
            BuildImage(helper, dbImage, width, height);
            return new MvcHtmlString(imageString);
        }

        private static string BuildImage(System.Web.Mvc.HtmlHelper helper, byte[] dbImage, int? width, int? height)
        {
            var imageString = new StringBuilder();
            imageString.Append(@"<img class=""uploadimage"" ");
            AppendSrc(helper, dbImage, imageString);
            AppendWidth(width, imageString);
            AppendHeight(height, imageString);
            imageString.Append(" />");
            return imageString.ToString();
        }

        private static void AppendSrc(System.Web.Mvc.HtmlHelper helper, byte[] DBImage, StringBuilder imageString)
        {
            if (DBImage != null)
                Apend64BaseImage(DBImage, imageString);
            else
                imageString.AppendFormat("src={0}", GetPlaceHolderImageUrl(helper));
        }

        private static void AppendWidth(int? width, StringBuilder imageString)
        {
            if (width != null)
                imageString.AppendFormat(@"width=""{0}"" ", width);
        }

        private static void AppendHeight(int? height, StringBuilder imageString)
        {
            if (height != null)
                imageString.AppendFormat(@"height=""{0}"" ", height);
        }

        private static void Apend64BaseImage(byte[] DBImage, StringBuilder imageString)
        {
            var t = Convert.ToBase64String(DBImage);
            imageString.AppendFormat(@"src=""data:image/jpg;base64,{0}"" ", t);
        }

        private static string GetPlaceHolderImageUrl(System.Web.Mvc.HtmlHelper helper)
        {
             var urlHelper = new System.Web.Mvc.UrlHelper(helper.ViewContext.RequestContext);
             return urlHelper.Asset(ImagePlaceHolderName,Area);
        }

        public static MvcHtmlString Image(this System.Web.Mvc.HtmlHelper helper, byte[] dbImage)
        {
            return Image(helper, dbImage, null, null);
        }
    }
}
