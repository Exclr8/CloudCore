using System;
using System.Web.Mvc;
//using CloudCore.Domain.SchedulesTasks;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.Classes.CachedReusableObjects
{
    public class ScheduledGroupCachedReusableObject : BaseCachedReusableObject<ScheduledGroupCachedReusableObject>
    {
        public override string GetTitle()
        {
            return "Scheduled Task Group Details";
        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Scheduled Task Group Name", ScheduledTaskGroupName);
            content.AddHtmlContent("User Manager", UserName);
        }

        protected override void GetPropertyValues()
        {
            CloudCoreDB database = CloudCoreDB.Context;
            var result = (from sched in database.Cloudcore_ScheduledTaskGroup
                          join user in database.Cloudcore_User on sched.ManagerUserId equals user.UserId
                          where sched.ScheduledTaskGroupId == ScheduledTaskGroupId
                          select new { sched.ScheduledTaskGroupName, user.Fullname, user.UserId }).SingleOrDefault();

            this.ScheduledTaskGroupName = result.ScheduledTaskGroupName;
            this.UserName = result.Fullname;
            this.UserId = result.UserId;
        }

        #region Properties
        public int ScheduledTaskGroupId { get { return Convert.ToInt32(Key); } }
        public string ScheduledTaskGroupName { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        #endregion
    }
}