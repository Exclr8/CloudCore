using System.Web.Mvc;
using CloudCore.Core.Domain;

namespace CloudCore.Web.Core.Helpers.FormLayout
{
    public partial class FormLayoutHelper<TModel>
    {
        private ViewContext Context { get; set; }
        private HtmlHelper<TModel> HtmlHelper { get; set; }
        internal PopUpHelper<TModel> PopUpHelper { get; set; }

        private BaseFormTable<TModel> formTable;

        public FormLayoutHelper(ViewContext context, HtmlHelper<TModel> htmlHelper)
        {
            Context = context;
            this.HtmlHelper = htmlHelper;
        }

        public BaseFormTable<TModel> BeginTable(FormLayoutType formType = FormLayoutType.Default)
        {
            formTable = new BaseFormTable<TModel>(Context, formType);
            return formTable;
        }

        public FormToolbar<TModel> BeginToolbar()
        {
            var formToolbar = new FormToolbar<TModel>(Context, PopUpHelper);
            return formToolbar;
        }

        public void AddSubmitButtonWithBar(string submitText)
        {
            using (var formToolbar = new FormToolbar<TModel>(Context, PopUpHelper))
            {
                formToolbar.AddSubmitButton(submitText);
            }
        }

        public void AddSubmitButtonWithBar(string submitText, string buttonElementId)
        {
            using (var formToolbar = new FormToolbar<TModel>(Context, PopUpHelper))
            {
                formToolbar.AddSubmitButton(buttonElementId, submitText);
            }
        }


        public void AddSubmitButtonWithBar(string submitText, string buttonElementId, string cancelText, string cancelUrlAction)
        {
            using (var formToolbar = new FormToolbar<TModel>(Context, PopUpHelper))
            {
                formToolbar.AddRedirectButton(cancelText, cancelUrlAction);
                formToolbar.AddSubmitButton(buttonElementId, submitText);
            }
        }

        public void AddSubmitButtonWithBar(string submitText, string cancelText, string cancelUrlAction)
        {
            using (var formToolbar = new FormToolbar<TModel>(Context, PopUpHelper))
            {
                formToolbar.AddRedirectButton(cancelText, cancelUrlAction);
                formToolbar.AddSubmitButton(submitText);
            }
        }

        public void AddModalSubmitButton(string submitText)
        {
            using (var formToolbar = new FormToolbar<TModel>(Context, PopUpHelper))
            {
                formToolbar.AddModalSubmitButton(submitText);
                formToolbar.AddCloseButton();
            }
        }

        public void AddRedirectButtonWithBar(string buttonText, string redirectUrlAction)
        {
            using (var formToolbar = new FormToolbar<TModel>(Context, PopUpHelper))
            {
                formToolbar.AddRedirectButton(buttonText,redirectUrlAction);
            }
        }

        public void AddPopupButtonWithBar(string popUpName, string title, int width, int height, string url, string buttonText)
        {
            using (var formToolbar = new FormToolbar<TModel>(Context, PopUpHelper))
            {
                formToolbar.AddPopupButton(popUpName, title, width, height, url, buttonText);
            }
        }

        public void AddPopupButtonWithBar(string buttonText, string url)
        {
            using (var formToolbar = new FormToolbar<TModel>(Context, PopUpHelper))
            {
                formToolbar.AddPopupButton(buttonText, url);
            }
        }

        public ModalPopupWrapper<TModel> BeginModal(string title)
        {
            var modalWrapper = new ModalPopupWrapper<TModel>(Context, title);
            return modalWrapper;
        }
    }
}
