using CloudCore.Web.Core.Dashboard;

namespace CloudCore.Admin.Classes.DashboardObjects
{
    public class UserSearchDBO : BaseDashboardItem
    {
        public override string Title
        {
            get { return "A Link to the User Search Page"; }
        }

        public override string Description
        {
            get { return "This is My First Dashboard Item"; }
        }

        public override string NavigateURL(System.Web.Mvc.UrlHelper urlHelper)
        {
            return urlHelper.Action("Search", "User", new { Area = "Admin" });
        }
    }
}