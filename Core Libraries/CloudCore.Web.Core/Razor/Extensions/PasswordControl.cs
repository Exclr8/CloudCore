using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class PasswordControls
    {
        public static MvcHtmlString PasswordStrengthControl<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string submitButtonId, object htmlAttributes = null)
        {
            var urlHelper = new System.Web.Mvc.UrlHelper(helper.ViewContext.RequestContext);

            //Get name of property from model
            var passwordName = ((MemberExpression)expression.Body).Member.Name;

            //Define style and js
            //var cssRegister = FrameworkExtensions.StyleSheetTag(urlHelper.Asset("passwordStrength.css", "CUI"));
            //var scriptRegister = FrameworkExtensions.ScriptTag(urlHelper.Asset("passwordStrength.js", "CUI"));
            //cssRegister = cssRegister + FrameworkExtensions.StyleSheetTag(urlHelper.Asset("tooltip.css", "CUI"));

            const string template = @"<a class=""tooltip"" href=""#"">" +
                                    @"<img src=""{0}"" border=""0"" style=""margin-left: 7px;vertical-align: -4px; padding-top: 5px;""/>" +
                                    @"<span class=""custom help"">" +
                                    @"<img class=""innerimage"" src=""{1}"" alt=""Help"" height=""48"" width=""48"" border=""0"" style=""position: relative; float:left;padding-left:25px"" />" +
                                    @"<em>Help</em>Your password must include alpha-numeric characters (a,b,c,1,2,3), special characters(_, $, -), uppercase and lowercase characters." +
                                    @"</span>"+
                                    @"</a>";
            
            var helpLayer = string.Format(template, urlHelper.Asset("info.png", "CUI"), urlHelper.Asset("tooltip/info.png", "CUI"));
            var documentScriptRegister = @"<script type=""text/javascript"">$(document).ready(function () {" +
                                         string.Format(@"RegisterPassword('{0}', '{1}', {2});", passwordName, submitButtonId, 4) +
                                         "});</script>";

            var passwordHtml = helper.PasswordFor(expression, htmlAttributes);

            var helperHtml = string.Format(@"<br /><span class=""pst"">A strength of ""Strong"" or higher is required.{0}</span>", helpLayer);

            const string strengthHtml =
                @"<br />" +
                @"<span class=""response"">" +
                @"    <div class=""password_strength"">" +
                @"    <div class=""gradient sp_First"" strength=""0""></div>" +
                @"    <div class=""gradient"" strength=""1""></div>" +
                @"    <div class=""gradient"" strength=""2""></div>" +
                @"    <div class=""gradient"" strength=""3""></div>" +
                @"    <div class=""gradient sp_Last"" strength=""4"" ></div>" +
                @"    </div>" +
                @"    <div id=""pstext"" class=""pst""></div>" +
                @"</span>";

            var ret =   @"<span style='float:left;'>" + 
                            //cssRegister +
                            //scriptRegister +
                            documentScriptRegister +
                            passwordHtml.ToString() +
                            helperHtml +
                            strengthHtml +
                        @"</span>";

            return new MvcHtmlString(ret);
        }

    }
}
