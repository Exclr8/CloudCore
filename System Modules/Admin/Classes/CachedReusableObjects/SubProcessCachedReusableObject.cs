using System;
using System.Web.Mvc;
using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.Classes.CachedReusableObjects
{
    public class SubProcessCachedReusableObject : BaseCachedReusableObject<SubProcessCachedReusableObject>
    {
        public int SubProcessId { get { return Convert.ToInt32(Key); } }
        public int ProcessRevisonId { get; set; }
        public string SubProcessName { get; set; }

        protected override void GetPropertyValues()
        {
            using (var context = CloudCoreDB.Context)
            {
                var result = (from subProcess in context.Cloudcoremodel_SubProcess
                              where subProcess.SubProcessId == SubProcessId
                              select new
                              {
                                  ProcessId = subProcess.ProcessRevisionId,
                                  SubProcessName = subProcess.SubProcessName
                              }).Single();

                ProcessRevisonId = result.ProcessId;
                SubProcessName = result.SubProcessName;
            }

        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Sub-Process Name", SubProcessName);
        }

        public override string GetTitle()
        {
            return "Sub-Process Details";
        }
    }
}