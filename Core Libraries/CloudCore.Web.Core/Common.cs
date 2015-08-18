using System.Linq;
using System.Text;
using System.Web;

namespace CloudCore.Web.Core
{
    public class Common
    {
        public static void GenerateHttpResponse(HttpResponseBase response, int responseCode, string htmlMessage)
        {
            response.StatusCode = responseCode;
            response.Clear();
            response.Write(htmlMessage);
            response.ContentType = "text/html";
            response.End(); 
        }

        public static string GetErrorListFromModelState(System.Web.Mvc.ModelStateDictionary modelState)
        {
            var modelStateErrors = modelState.Keys.SelectMany(key => modelState[key].Errors);
            var errorlist = new StringBuilder();
            errorlist.Append("<br/> <br/>");
            foreach (var item in modelStateErrors)
            {
                errorlist.AppendFormat("- {0} <br/>", item.ErrorMessage);
            }
            return errorlist.ToString();
        }
    }
}
