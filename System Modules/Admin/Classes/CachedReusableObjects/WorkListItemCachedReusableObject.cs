using System;
using System.Globalization;
using System.Web.Mvc;
using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.Classes.CachedReusableObjects
{
    public class WorkListItemCachedReusableObject : BaseCachedReusableObject<WorkListItemCachedReusableObject>
    {
        public override string GetTitle()
        {
            return "Worklist Item Details";
        }


        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Instance Id", InstanceId.ToString(CultureInfo.InvariantCulture));
            content.AddHtmlContent("Status", StatusTypeName);
            content.AddHtmlContent("User", UserName);
            content.AddHtmlContent("Process", ProcessName);
            content.AddHtmlContent("Sub Process", SubProcessName);
            content.AddHtmlContent("Activity", ActivityName);
            content.AddHtmlContent("Priority", Priority.ToString(CultureInfo.InvariantCulture));
        }

        protected override void GetPropertyValues()
        {
            CloudCoreDB database = CloudCoreDB.Context;

            var result = (from vwx in database.Cloudcore_VwWorklistEx
                          where vwx.InstanceId == InstanceId
                          select new
                          {
                              vwx.StatusTypeName,
                              vwx.UserName,
                              vwx.ActivityName,
                              vwx.ProcessName,
                              vwx.SubProcessName,
                              vwx.UserId,
                              vwx.Priority,
                              vwx.Activate
                          }).SingleOrDefault();


            StatusTypeName = result.StatusTypeName;
            UserName = result.UserName;
            ActivityName = result.ActivityName;
            ProcessName = result.ProcessName;
            SubProcessName = result.SubProcessName;
            UserId = result.UserId;
            Priority = result.Priority;
        }

        #region Properties

        public int InstanceId { get { return Convert.ToInt32(Key); } }
        public string StatusTypeName { get; set; }
        public string UserName { get; set; }
        public string ActivityName { get; set; }
        public string ProcessName { get; set; }
        public string SubProcessName { get; set; }
        public int UserId { get; set; }
        public byte Priority { get; set; }
        public DateTime ActivationSchedule { get; set; }
        #endregion
    }
}