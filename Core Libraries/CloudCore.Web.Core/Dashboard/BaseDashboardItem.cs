using System.Web.Mvc;

namespace CloudCore.Web.Core.Dashboard
{

    public abstract class BaseDashboardItem
    {
        public abstract string Title { get; }
        public abstract string Description { get; }
        public abstract string NavigateURL(UrlHelper urlHelper);
    }
}
