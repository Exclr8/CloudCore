using System;
using System.Web.Mvc;
using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.Classes.CachedReusableObjects
{
    public class ProcessCachedReusableObject : BaseCachedReusableObject<ProcessCachedReusableObject>
    {
        public int ProcessRevisionId { get { return Convert.ToInt32(Key); } }
        public string ProcessName { get; set; }
        public string ProcessMangerName { get; set; }
        public DateTime DateChanged { get; set; }

        protected override void GetPropertyValues()
        {
            using (var context = CloudCoreDB.Context)
            {
                var result = (from processRevision in context.Cloudcoremodel_ProcessRevision
                              join processModel in context.Cloudcoremodel_ProcessModel on processRevision.ProcessModelId equals processModel.ProcessModelId
                              join manager in context.Cloudcore_User on processRevision.ManagerId equals manager.UserId
                              where processRevision.ProcessRevisionId == ProcessRevisionId
                              select new
                              {
                                  ProcessName = processModel.ProcessName,
                                  ProcessMangerName = manager.NFullname,
                                  DataChanged = processRevision.Changed

                              }).Single();

                ProcessName = result.ProcessName;
                ProcessMangerName = result.ProcessMangerName;
                DateChanged = result.DataChanged;
            }

        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Name", ProcessName);
            content.AddHtmlContent("Process Manager", ProcessMangerName);
            content.AddHtmlContent("Date Changed", DateChanged.ToShortDateString());
        }

        public override string GetTitle()
        {
            return "Process Details";
        }
    }
}