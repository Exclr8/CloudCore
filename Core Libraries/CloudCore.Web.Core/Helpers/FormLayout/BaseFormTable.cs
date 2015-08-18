using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using CloudCore.Core.Domain;

namespace CloudCore.Web.Core.Helpers.FormLayout
{
    public class BaseFormTable<TModel> : IDisposable
    {
        private ViewContext Context { get; set; }
        private FormLayoutType FormType { get; set; }

        public BaseFormTable(ViewContext context, FormLayoutType formType = FormLayoutType.Default)
        {
            Context = context;
            FormType = formType;

            switch (FormType)
            {
                case FormLayoutType.Default:
                    BeginTable();
                    break;
                case FormLayoutType.SideBySide:
                    BeginSideBySideTable();
                    break;
                case FormLayoutType.SideBySideChild:
                    BeginSideBySideChildTable();
                    break;
                case FormLayoutType.Popup:
                    BeginPopupTable();
                    break;
            }
        }

        private void BeginTable()
        {
            Context.Writer.WriteLine(@"<div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12 tablediv""><div class=""col-lg-6 col-md-12 col-sm-12 col-xs-12"">");
        }

        private void BeginPopupTable()
        {
            Context.Writer.WriteLine(@"<div>");
        }

        private void BeginSideBySideTable()
        {
            Context.Writer.WriteLine(@"<div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12 tablediv"">");
        }
        private void BeginSideBySideChildTable()
        {
            Context.Writer.WriteLine(@"<div class=""col-lg-6 col-md-6 col-sm-12 col-xs-12"">");
        }

        /// <summary>
        /// Adds a row with the required html, and styles
        /// </summary>
        /// <param name="label"></param>
        /// <param name="controlHtml"></param>
        /// <param name="rowId"></param>
        /// <param name="validationMessage"></param>
        /// <param name="isRequired">Adds a .required style to the line</param>
        /// <returns></returns>
        internal MvcHtmlString AddRow(string label, MvcHtmlString controlHtml, string rowId, string validationMessage = "", bool isRequired = false, bool addClearFix = false)
        {
            var htmlValidationMessage = new MvcHtmlString(validationMessage);

            var requiredCssClass = isRequired ? "required" : "";
            var clearfix = addClearFix ? "<div class='clearfix'></div>" : "";

            string content = string.Format(@"<div id=""row{4}"" class=""form-group {0}"">{1}<div class=""col-lg-9 col-md-9 col-sm-8 col-xs-12"">{2}{3}</div>{5}</div>", requiredCssClass, label, controlHtml.ToString(), htmlValidationMessage, rowId, clearfix);

            return new MvcHtmlString(content);
        }

        internal MvcHtmlString AddRowForFileUpload(string label, MvcHtmlString controlHtml, string rowId, string validationMessage = "")
        {
            var htmlValidationMessage = new MvcHtmlString(validationMessage);

            string content = string.Format(@"<div id=""row{3}"" class=""form-group"">{0}<div class=""col-lg-9 col-md-9 col-sm-8 col-xs-12"">{1}{2}</div ></div>", label, controlHtml.ToString(), htmlValidationMessage, rowId);

            return new MvcHtmlString(content);
        }

        internal MvcHtmlString AddSingleTDRow(string htmlContent, string cssClass)
        {
            var content = string.Format(@"<div class=""form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 {0}"">{1}</div>", cssClass, htmlContent);

            return new MvcHtmlString(content);
        }

        internal MvcHtmlString AddFillerAndRow(string content, string cssClass, TDFillerPosition fillerPosition = TDFillerPosition.Both)
        {
            var ret = string.Format("{0}{1}{2}"
                        , ((fillerPosition == TDFillerPosition.Top || fillerPosition == TDFillerPosition.Both) && (fillerPosition != TDFillerPosition.None)) ? AddSingleTDRow("&nbsp;", "tdfiller").ToString() : string.Empty
                        , AddSingleTDRow(content, cssClass).ToString()
                        , ((fillerPosition == TDFillerPosition.Bottom || fillerPosition == TDFillerPosition.Both) && (fillerPosition != TDFillerPosition.None)) ? AddSingleTDRow("&nbsp;", "tdfiller").ToString() : string.Empty);

            return new MvcHtmlString(ret);
        }

        private MvcHtmlString CloseTable(FormLayoutType formType = FormLayoutType.Default)
        {
            MvcHtmlString endTag;

            switch (formType)
            {
                case FormLayoutType.Default:
                    endTag = new MvcHtmlString("</div></div>");
                    break;
                default:
                    endTag = new MvcHtmlString("</div>");
                    break;
            };

            return endTag;
        }

        internal MvcHtmlString AddDownloadOptionRow(string label, List<SelectListItem> optionList, string downloadActionUrl)
        {
            var html = new StringBuilder();
            html.Append(@"<div id=""rowReportType"" class=""form-group required"" aria-required=""true"">");
            html.AppendFormat(@"<label class=""col-lg-3 col-md-4 col-sm-6 col-xs-12 control-label formLabel"" for=""ReportType"">{0}</label>", label);
            html.Append(@"<div class=""col-lg-9 col-md-8 col-sm-6 col-xs-12 fieldvalue"">");
            html.Append(@"<div class=""input-group"">");
            html.Append(@"<select data-val=""true"" data-val-required=""The Report Type field is required."" id=""ReportType"" name=""ReportType"" aria-required=""true"" aria-invalid=""false"" aria-describedby=""ReportType-error"" class=""valid form-control"">");

            foreach (var item in optionList)
                html.AppendFormat(@"<option value=""{0}"">{1}</option>", item.Value, item.Text);

            html.Append("</select>");
            html.Append(@"<div class=""input-group-btn""><button id=""btnDownload"" type=""button"" class=""btn btn-custom"">Download <span class=""glyphicon glyphicon-download""></span></button></div>");
            html.Append("</div>");
            html.Append(@"<span class=""field-validation-valid"" data-valmsg-for=""ReportType"" data-valmsg-replace=""true""></span>");
            html.Append("</div>");
            html.Append("</div>");

            html.Append(@"<script type=""text/javascript"">$(function () {$('#btnDownload').removeClass('ccSubmitButton');$('#btnDownload').on('click', function () {$(this).removeAttr('disabled');$(this).val('Download');$(this).parent().find('img').remove(); window.location.href = '" + downloadActionUrl + "?reportType=' + $('#ReportType').val();});});</script>");

            return new MvcHtmlString(html.ToString());
        }

        public void Dispose()
        {
            Context.Writer.Write(CloseTable(FormType));
        }
    }
}
