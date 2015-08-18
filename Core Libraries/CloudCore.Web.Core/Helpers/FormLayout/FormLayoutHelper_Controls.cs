using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using CloudCore.Web.Core.Razor.Extensions;

namespace CloudCore.Web.Core.Helpers.FormLayout
{
    public partial class FormLayoutHelper<TModel>
    {
        public MvcHtmlString AddSingleColumnRow(string htmlContent, string cssClass)
        {
            return formTable.AddSingleTDRow(htmlContent, cssClass);
        }

        public MvcHtmlString AddStaticTextRow(string text)
        {
            return formTable.AddSingleTDRow(text, "staticText");
        }

        public MvcHtmlString AddRow(string label, MvcHtmlString controlHtml, string rowId = "", string validationMessage = "", bool isRequired = false)
        {
            var newLabel = string.Format("<label class='col-lg-3 col-md-3 col-sm-4 col-xs-12 control-label'>{0}</label>", label);
            return formTable.AddRow(newLabel, controlHtml, rowId, validationMessage, isRequired);
        }

        public MvcHtmlString AddRowForFileUpload(string labelText, MvcHtmlString controlHtml, string rowId)
        {
            var label = HtmlHelper.Label(labelText, labelText, new { @class = "col-lg-3 col-md-3 col-sm-4 col-xs-12 control-label" }).ToString();
            return formTable.AddRowForFileUpload(label, controlHtml, rowId);
        }

        public MvcHtmlString AddRowFor(Expression<Func<TModel, object>> labelExpression, MvcHtmlString controlHtml)
        {
            return AddRowFor<object>(labelExpression, controlHtml);
        }

        public MvcHtmlString AddRowFor<TProperty>(Expression<Func<TModel, TProperty>> labelExpression, MvcHtmlString controlHtml)
        {
            return AddRowFor(labelExpression, controlHtml, false);
        }

        public MvcHtmlString AddRowFor<TProperty>(Expression<Func<TModel, TProperty>> labelExpression, MvcHtmlString controlHtml, bool ignoreRequired, bool addClearFix = false)
        {
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression(labelExpression, HtmlHelper.ViewData);

            var required = !ignoreRequired && metaData.IsRequired;
            var label = HtmlHelper.LabelFor(labelExpression, new { @class = "col-lg-3 col-md-3 col-sm-4 col-xs-12 control-label", @for = metaData.PropertyName }).ToString();

            if (HtmlHelper.ValidationMessageFor(labelExpression) != null)
            {
                var validationMessage = HtmlHelper.ValidationMessageFor(labelExpression).ToString();

                return formTable.AddRow(label, controlHtml, metaData.PropertyName, validationMessage, required, addClearFix);
            }
            else
            {
                return formTable.AddRow(label, controlHtml, metaData.PropertyName, isRequired: metaData.IsRequired);
            }
        }

        public MvcHtmlString AddRowFor(Expression<Func<TModel, bool>> labelExpression, MvcHtmlString controlHtml)
        {
            return AddRowFor<bool>(labelExpression, controlHtml);
        }

        /// <summary>
        /// Add a subtitle row to the form layout
        /// </summary>
        /// <param name="title">Text your want to display in your form layout subtitle row</param>
        /// <returns>Row as HtmlString</returns>
        public MvcHtmlString AddTitleHeaderRow(string title)
        {
            return formTable.AddSingleTDRow(title, "title");
        }

        /// <summary>
        /// Create a divider row in your form layout
        /// </summary>
        /// <returns>Row as HtmlString</returns>
        public MvcHtmlString AddDividerRow()
        {
            return formTable.AddFillerAndRow("", "divider");
        }

        /// <summary>
        /// Add a display row to the form layout consisting of a label athe properties value
        /// </summary>
        /// <param name="expression">Property from the model to bind to the display row</param>
        /// <returns>Row as HtmlString</returns>
        public MvcHtmlString AddDisplayRowFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            var hiddenTextFor = HtmlHelper.HiddenFor(expression).ToString();
            var displayTextFor = HtmlHelper.DisplayTextFor(expression).ToString();
            var result = string.Format("<label class='control-label display-text'>{0}</label>{1}", displayTextFor, hiddenTextFor);

            return AddRowFor(expression, new MvcHtmlString(result), true, true);
        }

        /// <summary>
        /// Add a Submit button row to your form layout
        /// </summary>
        /// <param name="submitText">Text to display in submit button</param>
        /// <returns>Row as HtmlString</returns>
        public MvcHtmlString AddSubmitRow(string submitText)
        {
            return AddSubmitRow(submitText, string.Empty);
        }

        /// <summary>
        /// Add a Submit button row to your form layout
        /// </summary>
        /// <param name="submitText">Text to display in submit button</param>
        /// <param name="submitButtonId">Id for the submit button</param>
        /// <returns>Row as HtmlString</returns>
        public MvcHtmlString AddSubmitRow(string submitText, string submitButtonId)
        {
            return formTable.AddFillerAndRow(BuildSubmitButton(submitButtonId, submitText)
                                                , "submit"
                                                , TDFillerPosition.Top);
        }

        /// <summary>
        /// Add a Submit button row to your form layout
        /// with Back/Cancel button to redirect to a different View
        /// </summary>
        /// <param name="submitText"></param>
        /// <param name="cancelText"></param>
        /// <param name="cancelUrlAction"></param>
        /// <returns></returns>
        public MvcHtmlString AddSubmitRow(string submitText, string cancelText, string cancelUrlAction)
        {
            string cancelButton = BuildRedirectButton(cancelText, cancelUrlAction);
            string submitButton = BuildSubmitButton(string.Empty, submitText);

            return formTable.AddFillerAndRow(string.Format("{0}&nbsp;&nbsp;&nbsp;{1}", cancelButton, submitButton), "submit", TDFillerPosition.Top);
        }

        /// <summary>
        /// Not actually a submit row, this is the same as AddRedirectButtonRow
        /// If you want to create a submit row rather use AddSubmitRow
        /// </summary>
        /// <param name="submitText"></param>
        /// <param name="urlAction"></param>
        /// <returns></returns>
        [Obsolete("Use AddSubmitRow")]
        public MvcHtmlString AddButtonSubmitRow(string submitText, string urlAction)
        {
            return AddRedirectButtonRow(submitText, urlAction);
        }

        /// <summary>
        /// Add a submit button row to your form layout
        /// with Back/Cancel button to redirect to a different View
        /// </summary>
        /// <param name="submitText"></param>
        /// <param name="cancelText"></param>
        /// <param name="cancelUrlAction"></param>
        /// <param name="submitButtonId"></param>
        /// <returns></returns>
        public MvcHtmlString AddSubmitRow(string submitText, string cancelText, string cancelUrlAction, string submitButtonId)
        {
            string cancelButton = BuildRedirectButton(cancelText, cancelUrlAction);
            string submitButton = BuildSubmitButton(submitButtonId, submitText);

            return formTable.AddFillerAndRow(string.Format("{0}&nbsp;&nbsp;&nbsp;{1}", cancelButton, submitButton)
                                                , "submit", TDFillerPosition.Top);
        }

        /// <summary>
        /// Add a button tht redirects to an action
        /// adds a filler row above the button
        /// </summary>
        public MvcHtmlString AddRedirectButtonRow(string buttonText, string urlAction)
        {
            return AddRedirectButtonRow(buttonText, urlAction, TDFillerPosition.Top);
        }

        /// <summary>
        /// Add a button tht redirects to an action
        /// adds a filler row above the button
        /// </summary>
        public MvcHtmlString AddRedirectButtonRow(string buttonText, string rowClass, string urlAction)
        {
            return AddRedirectButtonRow(buttonText, rowClass, urlAction, TDFillerPosition.Top);
        }


        /// <summary>
        /// Add a button tht redirects to an action
        /// Allows you to sepecify the fill position
        /// </summary>
        public MvcHtmlString AddRedirectButtonRow(string buttonText, string urlAction, TDFillerPosition fillPosition)
        {
            return AddRedirectButtonRow(buttonText, string.Empty, urlAction, fillPosition);
        }


        /// <summary>
        /// Add a button tht redirects to an action
        /// Allows you to sepecify the fill position
        /// </summary>
        public MvcHtmlString AddRedirectButtonRow(string buttonText, string rowClass, string urlAction, TDFillerPosition fillPosition)
        {
            return formTable.AddFillerAndRow(BuildRedirectButton(buttonText, urlAction)
                                                , rowClass
                                                , fillPosition);
        }

        private string BuildRedirectButton(string buttonText, string redirectUrlAction)
        {
            return string.Format(@"<input class=""btn btn-custom"" type=""button"" value=""{0}"" onclick=""location.href='{1}'"" />", buttonText, redirectUrlAction);
        }

        private string BuildSubmitButton(string submitButtonId, string submitText)
        {
            const string submitButtonClassName = "ccSubmitButton";

            return string.Format(@"<input class=""btn btn-custom"" type=""submit"" id=""{0}"" value=""{1}"" class=""{2}"" />", submitButtonId, submitText, submitButtonClassName);
        }

        /// <summary>
        /// Add a file upload row
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="extension">specify extension type to check for - example "jpg|png|gif" or "dll" or "*.*" for any.</param>
        /// <returns></returns>
        public MvcHtmlString AddFileUploadRow(string labelText, string name, int width, string extension)
        {
            return AddRowForFileUpload(labelText, ControlWrappers.FileUpload(HtmlHelper, name, width, extension), name);
        }

        public MvcHtmlString AddTextboxRowFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            return AddRowFor(expression, HtmlHelper.TextBoxFor(expression, ApplyManditoryClasses(htmlAttributes)));
        }

        public MvcHtmlString AddCurrencyTextboxRowFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            return AddRowFor(expression, new MvcHtmlString(String.Concat("R&nbsp", HtmlHelper.TextBoxFor(expression, ApplyManditoryClasses(htmlAttributes)))));
        }

        public MvcHtmlString AddTextboxRow(string labelText, string name, object value = null, object htmlAttributes = null)
        {
            return AddRow(labelText, HtmlHelper.TextBox(name, value, ApplyManditoryClasses(htmlAttributes)));
        }

        public MvcHtmlString AddCheckboxRowFor(Expression<Func<TModel, bool>> expression, object htmlAttributes = null)
        {
            var html = new StringBuilder();
            html.Append("<div class=\"checkbox\" >");
            html.Append(HtmlHelper.CheckBoxFor(expression, htmlAttributes));
            html.Append("</div>");
            return AddRowFor(expression, new MvcHtmlString(html.ToString()));
        }

        public MvcHtmlString AddCheckboxRow(string labelText, string name, bool isChecked, object htmlAttributes = null)
        {
            var html = new StringBuilder();
            html.Append("<div class=\"checkbox\" >");
            html.Append(HtmlHelper.CheckBox(name, isChecked, htmlAttributes));
            html.Append("</div>");
            return AddRow(labelText, new MvcHtmlString(html.ToString()));
        }

        public MvcHtmlString AddPasswordRowFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            return AddRowFor(expression, HtmlHelper.PasswordFor(expression, ApplyManditoryClasses(htmlAttributes)));
        }

        public MvcHtmlString AddPasswordRow(string labelText, string name, object value = null, object htmlAttributes = null)
        {
            return AddRow(labelText, HtmlHelper.Password(name, value, ApplyManditoryClasses(htmlAttributes)));
        }

        public MvcHtmlString AddPasswordStrengthRowFor(Expression<Func<TModel, object>> expression, string submitButtonId, object htmlAttributes = null)
        {
            return AddRowFor(expression, HtmlHelper.PasswordStrengthControl<TModel, object>(expression, submitButtonId, ApplyManditoryClasses(htmlAttributes)));
        }

        public MvcHtmlString AddDropDownRowFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> dropDownItems, string optionLabel = "", object htmlAttributes = null)
        {
            var html = new StringBuilder();
            html.Append("<div class=\"filter-dropdown input-group\" >");

            html.Append(string.IsNullOrEmpty(optionLabel)
                ? HtmlHelper.DropDownListFor(expression, dropDownItems, ApplyManditoryClasses(htmlAttributes))
                : HtmlHelper.DropDownListFor(expression, dropDownItems, optionLabel, ApplyManditoryClasses(htmlAttributes)));

            html.Append("</div>");

            return AddRowFor(expression, new MvcHtmlString(html.ToString()));
        }

        public MvcHtmlString AddDropDownRow(string labelText, string name, IEnumerable<SelectListItem> dropDownItems, string optionLabel = "", object htmlAttributes = null)
        {
            return (string.IsNullOrEmpty(optionLabel)) ?
                AddRow(labelText, HtmlHelper.DropDownList(name, dropDownItems, ApplyManditoryClasses(htmlAttributes))) :
                AddRow(labelText, HtmlHelper.DropDownList(name, dropDownItems, optionLabel, ApplyManditoryClasses(htmlAttributes)));
        }

        public MvcHtmlString AddDateTimePickerRowFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return AddRowFor(expression, HtmlHelper.EditorFor(expression));
        }

        public MvcHtmlString AddTimePickerRowFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return AddRowFor(expression, HtmlHelper.EditorFor(expression));
        }

        public MvcHtmlString AddRadioButtonsRowFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes)
        {
            return AddRowFor(expression, HtmlHelper.RadioButtonFor(expression, value, ApplyManditoryClasses(htmlAttributes)));
        }

        public MvcHtmlString AddRadioButtonsList(string labelText, string name, IEnumerable<string> radioButtonItems, object value = null)
        {
            return AddRow(labelText, HtmlHelper.RadioButtonList(name, radioButtonItems));
        }

        public MvcHtmlString AddRadioButtonsList(string labelText, string name, IEnumerable<SelectListItem> radioButtonItems, object value = null, object htmlAttributes = null)
        {
            return AddRow(labelText, HtmlHelper.RadioButtonList(name, radioButtonItems, htmlAttributes));
        }

        public MvcHtmlString AddTextAreaFor<TProperty>(Expression<Func<TModel, TProperty>> expression, int rows = 5, int columns = 10, object htmlAttributes = null)
        {
            return AddRowFor(expression, HtmlHelper.TextAreaFor(expression, rows, columns, ApplyManditoryClasses(htmlAttributes)));
        }

        public MvcHtmlString AddTextAreaForWithMaxLimit<TProperty>(Expression<Func<TModel, TProperty>> expression, int maxLength, int rows = 5, int columns = 10, object htmlAttributes = null)
        {
            var newHtmlAttributes = new RouteValueDictionary(htmlAttributes)
            {
                { "class", "form-control" },
                { "maxlength", maxLength }
            };
            return AddRowFor(expression, HtmlHelper.TextAreaFor(expression, rows, columns, newHtmlAttributes));
        }

        public MvcHtmlString AddTextArea(string labelText, string name, string value = "", int rows = 5, int columns = 10, object htmlAttributes = null)
        {

            return AddRow(labelText, HtmlHelper.TextArea(name, value, rows, columns, ApplyManditoryClasses(htmlAttributes)));
        }

        public MvcHtmlString AddFilterEditRowFor(Expression<Func<TModel, object>> expression, Expression<Func<TModel, object>> filter, object ddlhtmlAttributes = null, object txthtmlAttributes = null)
        {
            return AddRowFor(expression, HtmlHelper.FilterEdit(expression, filter, ddlhtmlAttributes, txthtmlAttributes), false, true);
        }

        public MvcHtmlString AddLookupFor(Expression<Func<TModel, int>> idExpression, Expression<Func<TModel, string>> valueExpression, string popUpName, string title, int width, int height, string url, bool disabled = false, string placeholder = "Click button to search")
        {
            if (this.PopUpHelper == null)
                throw new Exception("AddLookupFor cannot be used in PopupView.");

            var control = PopUpHelper.CreateAsLookupButton(idExpression, valueExpression, popUpName, title, width, height, url, placeholder, disabled);

            return AddRowFor(valueExpression, control);
        }
        public MvcHtmlString AddLookupFor(Expression<Func<TModel, int>> idExpression, Expression<Func<TModel, string>> valueExpression, string title, string url, bool disabled = false, string placeholder = "Click button to search")
        {
            if (this.PopUpHelper == null)
                throw new Exception("AddLookupFor cannot be used in PopupView.");

            var control = PopUpHelper.CreateAsLookupButton(idExpression, valueExpression, title, url, placeholder, disabled);

            return AddRowFor(valueExpression, control);
        }
        
        public MvcHtmlString AddDownloadOption(string labelText, List<SelectListItem> options, string downloadActionUrl)
        {
            return formTable.AddDownloadOptionRow(labelText, options, downloadActionUrl);
        }

        private RouteValueDictionary ApplyManditoryClasses(object htmlAttributes)
        {
            var newHtmlAttributes = new RouteValueDictionary(htmlAttributes);

            if (newHtmlAttributes.ContainsKey("class"))
            {
                var value = string.Format("{0} form-control", newHtmlAttributes.Single(x => x.Key == "class").Value);
                newHtmlAttributes.Remove("class");
                newHtmlAttributes.Add("class", value);
            }
            else
            {
                newHtmlAttributes.Add("class", "form-control");
            }

            return newHtmlAttributes;
        }

        public MvcHtmlString AddModalSearchButtonBar(string searchPostUrl)
        {
            const string clearFix = "<div class='clearfix'></div>";
            const string scriptOpen = "<script type='text/javascript'>";
            const string scriptClose = "</script>";

            var builder = new StringBuilder();
            builder.Append(clearFix);
            builder.Append("<button type='button' class='btn btn-default pull-right' data-dismiss='modal'>CLOSE</button>");
            builder.Append("<button id='btn-search-Submit' type='button' class='btn btn-custom pull-right'>Search</button>");
            builder.Append(clearFix);


            builder.Append(scriptOpen);

            builder.Append(@"$(function () {
                                $('#btn-search-Submit').click(function (e) {
                                    e.preventDefault();
                                    var self = $(this);
                                    $.ajax({
                                        url: '" + searchPostUrl + @"',
                                        type: 'POST',
                                        data: self.closest('form').serialize(),
                                        success: function (data) {
                                            $('#modal-container .modal-content').html(data);
                                            return false;
                                        }
                                    });
                                    return false;
                                });
                            });");

            builder.Append(scriptClose);

            return new MvcHtmlString(builder.ToString());
        }
    }
}
