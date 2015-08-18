using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using CloudCore.Web.Core.PopUps;

namespace CloudCore.Web.Core.Helpers
{
    public class PopUpHelper<T>
    {
        protected List<PopUp> PopUps { get; set; }

        internal object Model { get; set; }
        internal HttpContextBase Context { get; set; }
        internal HtmlHelper<T> Html { get; set; }

        public PopUpHelper()
        {
            PopUps = new List<PopUp>();
        }

        /// <summary>
        /// Add your popup to the PopUps List
        /// </summary>
        /// <param name="popup">An instantiated popup object</param>
        public void Add(PopUp popup)
        {
            PopUps.Add(popup);
        }

        /// <summary>
        /// Add your popup to the PopUps List
        /// </summary>
        /// <param name="popUpName">The name of your popup</param>
        /// <param name="title">The title you want to be displayed in your popup</param>
        /// <param name="width">The width of the popup</param>
        /// <param name="height">The height of the popup</param>
        /// <param name="url">The url of the view you would like to show, use Url.Action</param>
        public void Add(string popUpName, string title, int width, int height, string url)
        {
            PopUps.Add(new PopUp(popUpName, title, width, height, url));
        }

        /// <summary>
        /// Add your popup to the PopUps List and create a link on your page to show the popup
        /// </summary>
        /// <param name="popUpName">The name of your popup</param>
        /// <param name="title">The title you want to be displayed in your popup</param>
        /// <param name="width">The width of the popup</param>
        /// <param name="height">The height of the popup</param>
        /// <param name="url">The url of the view you would like to show, use Url.Action</param>
        /// <param name="hrefText">The text in the link</param>
        /// <returns></returns>
        public MvcHtmlString CreateAsHref(string popUpName, string title, int width, int height, string url, string hrefText)
        {
            Add(new PopUp(popUpName, title, width, height, url));

            return new MvcHtmlString(string.Format(@"<a href=""javascript:void(0);"" onclick=""{0}"">{1}</a>", JavascriptMethodCall(popUpName), hrefText));
        }

        public MvcHtmlString CreateAsHref(string title, string url, string hrefText)
        {
            return new MvcHtmlString(string.Format(@"<a href=""{0}"" class=""modal-btn"">{1}</a>", url, hrefText));
        }

        public MvcHtmlString CreateAsImg(string popUpName, string title, int width, int height, string url, string imgUrl, string cssClass = "")
        {
            Add(new PopUp(popUpName, title, width, height, url));

            return new MvcHtmlString(string.Format(@"<img src=""{0}"" onclick=""{1}"" border=""0"" {2} />"
                                                            , imgUrl
                                                            , JavascriptMethodCall(popUpName)
                                                            , string.IsNullOrEmpty(cssClass) ? string.Empty : String.Format(@"class=""{0}""", cssClass)));
        }

        /// <summary>
        /// Add your popup to the PopUps List and create a button on your page to show the popup
        /// </summary>
        /// <param name="popUpName">The name of your popup</param>
        /// <param name="title">The title you want to be displayed in your popup</param>
        /// <param name="width">The width of the popup</param>
        /// <param name="height">The height of the popup</param>
        /// <param name="url">The url of the view you would like to show, use Url.Action</param>
        /// <param name="buttonText">The text in the button</param>
        /// <returns></returns>
        public MvcHtmlString CreateAsButton(string popUpName, string title, int width, int height, string url, string buttonText)
        {
            Add(new PopUp(popUpName, title, width, height, url));
            return new MvcHtmlString(string.Format(@"<input class=""btn btn-custom"" type=""button"" onclick=""{0}"" value=""{1}""/>", JavascriptMethodCall(popUpName), buttonText));
        }

        public MvcHtmlString CreateAsButton(string buttonText, string url)
        {
            return new MvcHtmlString(string.Format(@"<input class=""btn btn-custom modal-btn "" type=""button"" href=""{0}"" value=""{1}""/>", url, buttonText));
        }

        public MvcHtmlString CreateAsLookupButton(Expression<Func<T, int>> idExpression, Expression<Func<T,string>> valueExpression, string popUpName, string title, int width, int height, string url, string placeholder, bool disabled)
        {
            var idName = ((MemberExpression)idExpression.Body).Member.Name;
            var valueName = ((MemberExpression)valueExpression.Body).Member.Name;
            
            var valueTextBoxId = string.Format("{0}_{1}", popUpName, valueName);
            var idTextBoxId = string.Format("{0}_{1}", popUpName, idName);
            
            url += (url.Contains("?")) ? "&" : "?";
            url += string.Format("idName={0}&valueName={1}", idTextBoxId, valueTextBoxId);

            Add(new PopUp(popUpName, title, width, height, url));

            var stringBuilder = new StringBuilder();
            string disabledText = disabled ? "disabled='disabled'" : string.Empty;

            stringBuilder.Append(@"<div class=""input-group"">");
            stringBuilder.AppendFormat(@"<input id=""{0}"" class=""form-control"" {2} value=""{1}"" placeholder=""{3}""/>", valueTextBoxId, Html.DisplayTextFor(valueExpression), disabledText, placeholder);
            stringBuilder.Append(@"<div class=""input-group-btn"">");
            stringBuilder.AppendFormat(@"<button class=""btn btn-custom"" type=""button"" onclick=""{0}""><span class=""glyphicon glyphicon-search""></button>", JavascriptMethodCall(popUpName));
            stringBuilder.Append("</div>");
            stringBuilder.Append(Html.HiddenFor(valueExpression, new { @id = "name_" + valueTextBoxId }));
            stringBuilder.Append(Html.HiddenFor(idExpression, new { @id = idTextBoxId }));
            stringBuilder.Append("</div>");

            return new MvcHtmlString(stringBuilder.ToString());
        }

        public MvcHtmlString CreateAsLookupButton(Expression<Func<T, int>> idExpression, Expression<Func<T, string>> valueExpression, string title, string url, string placeholder, bool disabled)
        {
            var idName = ((MemberExpression)idExpression.Body).Member.Name;
            var valueName = ((MemberExpression)valueExpression.Body).Member.Name;

            url += (url.Contains("?")) ? "&" : "?";
            url += string.Format("idName={0}&valueName={1}", idName, valueName);

            var stringBuilder = new StringBuilder();
            string disabledText = disabled ? "disabled='disabled'" : string.Empty;

            stringBuilder.Append(@"<div class=""input-group"">");
            stringBuilder.AppendFormat(@"<input id='input_{0}' class='form-control' {2} value='{1}' placeholder='{3}'/>", valueName, Html.DisplayTextFor(valueExpression), disabledText, placeholder);
            stringBuilder.Append(@"<div class=""input-group-btn"">");
            stringBuilder.AppendFormat(@"<button class=""btn btn-custom modal-btn"" type=""button"" href=""{0}""><span class=""glyphicon glyphicon-search""></button>", url);
            stringBuilder.Append("</div>");
            stringBuilder.Append(Html.HiddenFor(valueExpression, new { @id = "name_" + valueName }));
            stringBuilder.Append(Html.HiddenFor(idExpression, new { @id = idName }));                        
            stringBuilder.Append("</div>");

            return new MvcHtmlString(stringBuilder.ToString());
        } 

        public string JavascriptMethodCall(string popUpName)
        {
            var popUp = PopUps.SingleOrDefault(p => p.PopUpName == popUpName);

            if (popUp == null)
                throw new Exception(string.Format("No popup up called '{0}' found.", popUpName));

            return popUp.GetMethodCall();
        }

        internal MvcHtmlString Render(HttpContextBase httpContext)
        {
            if (PopUps.Count == 0)
                return new MvcHtmlString(string.Empty);

            return Render_PopUps(httpContext);
        }

        private MvcHtmlString Render_PopUps(HttpContextBase httpContext)
        {
            var sb = new StringBuilder();
            Render_PopUpWireframe(sb,httpContext);
            Render_PopUpJavascript(httpContext, sb);
            return new MvcHtmlString(sb.ToString());
        }

        private void Render_PopUpJavascript(HttpContextBase httpContext, StringBuilder sb)
        {
            // TODO: Use built-in Html builders...
            sb.Append(@"<script type=""text/javascript"">");
            PopUps.ForEach(pu => sb.Append(pu.Render_PopupJavascript(httpContext)));
            RenderClosePopUpJavascript(sb);
            sb.Append("</script>");
        }

        private static void RenderClosePopUpJavascript(StringBuilder sb)
        {
            sb.Append(@"$(document).ready(function () {");
            sb.Append("BindPopupClickStandard();");
            sb.Append("});");
        }

        private void Render_PopUpWireframe(StringBuilder sb,HttpContextBase httpContext)
        {
            // TODO: Use built-in Html builders...
            string serverUrlAndApplicationPath = GetServerUrlAndApplicationPath(httpContext);
            sb.Append(@"<div id=""backgroundPopup"">&nbsp;</div>");
            sb.Append(@"<div id=""popUp"" class=""popUpStructure"">");
            sb.AppendFormat(@"<div class=""popCloseButton"">x</div>");
            sb.AppendFormat(@"<div id=""popUpTitle""><div class=""popupTitleIcon""><img src=""{0}/Asset/Get?area=CUI&file=/popups/PopUpIcon.png"" /></div><span id=""titleText""></span></div>", serverUrlAndApplicationPath);
            sb.Append(@"<iframe id=""popupIFrame"" marginheight=""5"" marginwidth=""20"" frameborder=""0"" style=""margin: 0 4px;""></iframe>");
            sb.Append(@"</div>");
        }

        private string GetServerUrlAndApplicationPath(HttpContextBase httpContext)
        {
            return httpContext.Request.ApplicationPath.TrimEnd('/');
        }
    }
}
