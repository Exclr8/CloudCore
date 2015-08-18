using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CloudCore.Web.Core.Helpers.FormLayout
{
    public class ModalPopupWrapper<TModel> : IDisposable
    {
        private ViewContext Context { get; set; }
        private string Title { get; set; }

        public ModalPopupWrapper(ViewContext context, string title)
        {
            Context = context;
            Title = title;

            BeginModal();
        }

        private void BeginModal()
        {
            string header = string.Format(@"<div class='modal-header'>
                                                <button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>×</span></button>
                                                <h4 class='modal-title'>{0}</h4>
                                            </div>
                                            <div class='modal-body'>", Title);
            Context.Writer.Write(header);
        }

        private MvcHtmlString CloseModal()
        {
            const string content = "<div class='clearfix'></div></div>";
            return new MvcHtmlString(content);
        }

        public void Dispose()
        {
            Context.Writer.Write(CloseModal());
        }
    }
}
