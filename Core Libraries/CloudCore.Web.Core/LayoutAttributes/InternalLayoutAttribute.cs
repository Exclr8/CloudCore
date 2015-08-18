using System.Web.Mvc;

namespace CloudCore.Web.Core.LayoutAttributes
{
    public class LoggedInCloudCoreLayoutAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
              
                viewResult.MasterName = "_CloudCoreInternal";
            }
        }
    }
}
