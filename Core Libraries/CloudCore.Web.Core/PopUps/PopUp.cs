using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CloudCore.Web.Core.PopUps
{
    public class PopUp
    {
         public PopUp(string popUpName, string title, int width, int height, string url)
        {
            this.PopUpName = popUpName;
            this.Width = width;
            this.Height = height;
            this.Url = url;
            this.Title = title;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public string PopUpName { get; set; }
        public string Title { get; set; }
        public string CloseScript { get; set; }
        public string Url { get; set; }

        public string Render_PopupJavascript(HttpContextBase context)
        {
            return string.Format("{0}{1}", Render_PopupLoadJavascript(context), 
                                                                Render_PopupCloseScript());
        }

        public string Render_PopupLoadJavascript(HttpContextBase context)
        {
            var scriptString = new StringBuilder();
            scriptString.Append(string.Format("function {0}", GetMethodCall()));
            scriptString.Append("{");
            scriptString.Append(string.Format("loadPopup('{0}', '{1}px', '{2}px', '{3}', '{4}');", UrlHelper.GenerateContentUrl(this.Url, context), this.Width, this.Height, this.PopUpName, this.Title));
            scriptString.Append("}");

            return scriptString.ToString();
        }

        public string Render_PopupCloseScript()
        {
            string closeScript = string.Format(@"function close{0}Popup()", this.PopUpName);
            closeScript += @"{";
            closeScript += CloseScript;
            closeScript += @"}";

            return closeScript;
        }

        public string GetMethodCall()
        {
            return string.Format("load_{0}()", this.PopUpName);
        }       
    }
}
