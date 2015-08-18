using System;
using System.Globalization;
using System.Web.Mvc;

namespace CloudCore.Web.Core.Helpers.FormLayout
{
    public class FormToolbar<TModel> : IDisposable
    {
        public FormToolbar(ViewContext context, PopUpHelper<TModel> popupHelper)
        {
            PopUpHelper = popupHelper;
            Context = context;
            BeginBar();
        }

        private ViewContext Context { get; set; }
        private PopUpHelper<TModel> PopUpHelper { get; set; }

        public void Dispose()
        {
            Context.Writer.Write(CloseBar());
        }

        private void BeginBar()
        {
            string content = @"<div class=""pull-right modal-btn-bar"">";

            Context.Writer.WriteLine(content);
        }


        internal void AddItem(string controlHtml)
        {
            Context.Writer.WriteLine(@"<div class=""submit-btn-container"">{0}</div>", controlHtml.ToString(CultureInfo.InvariantCulture));
        }

        public void AddPopupButton(string popUpName, string title, int width, int height, string url, string buttonText)
        {
            if (PopUpHelper == null)
                throw new Exception("AddPopupButton cannot be used in a PopupView.");

            AddItem(PopUpHelper.CreateAsButton(popUpName, title, width, height, url, buttonText).ToString());
        }

        public void AddPopupButton(string buttonText, string url)
        {
            if (PopUpHelper == null)
                throw new Exception("AddPopupButton cannot be used in a PopupView.");

            AddItem(PopUpHelper.CreateAsButton(buttonText, url).ToString());
        }

        public void AddRedirectButton(string buttonText, string redirectUrlAction)
        {
            AddItem(string.Format(@"<input class=""btn btn-custom"" type=""button"" value=""{0}"" onclick=""location.href='{1}'"" />", buttonText,
                redirectUrlAction));
        }

        public void AddSubmitButton(string submitText)
        {
            AddItem(string.Format(@"<input class=""btn btn-custom"" type=""submit"" value=""{0}"" />", submitText));
        }

        public void AddSubmitButton(string submitButtonId, string submitText)
        {            
            AddItem(string.Format(@"<input class=""btn btn-custom"" type=""submit"" id=""{0}"" value=""{1}"" />", submitButtonId, submitText));
        }

        public void AddModalSubmitButton(string submitText)
        {
            Context.Writer.WriteLine(@"<button class=""btn btn-danger"" type=""submit"">{0}</button>", submitText);
        }

        public void AddCloseButton()
        {            
            Context.Writer.Write(@"<button type='button' class='btn btn-custom' data-dismiss='modal'>CLOSE</button>");
        }

        public void AddCancelButton(string cancelText, string cancelUrlAction)
        {
            AddItem(string.Format(@"<input type=""cancel"" value=""{0}"" onclick=""location.href='{1}'"" />", cancelText,
                cancelUrlAction));
        }

        private MvcHtmlString CloseBar()
        {
            const string content = "</div>";
            return new MvcHtmlString(content);
        }
    }
}