using System;
using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.BaseModels;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Data;

namespace CloudCore.Web.Core.Workflow.Models
{
    public abstract class BaseWorkItemModel : BaseContextModel, IWorkItemModel
    {
        public WorkItemCachedReusableObject ActiveWorkItem = WorkItemCachedReusableObject.LoadFromCache();

        public long InstanceId
        {
            get
            {
                return ActiveWorkItem.InstanceId;
            }
            set
            {
                Key = value;
            }
        }

        public long KeyValue { get { return ActiveWorkItem.KeyValue; } }
        
        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ActiveWorkItem, key);
            base.OnKeyChanged(key);
        }

        public void Navigate()
        {
            CloudCoreDB.Context.Cloudcore_WorkItemFlow(ActiveWorkItem.InstanceId, CloudCoreIdentity.UserId, "");
        }

        public void Cancel()
        {
            CloudCoreDB.Context.Cloudcore_WorkItemCancel(ActiveWorkItem.InstanceId, CloudCoreIdentity.UserId);
        }

        /// <summary>
        /// Delays the current task until a specified date and time. Only after that date/time the task will re-appear on the worklist.
        /// </summary>
        /// <param name="reactivateAt">Date and Time at which to reactive this task. After this time the task will re-appear on the worklist.</param>
        public void Delay( DateTime reactivateAt)
        {
            CloudCoreDB.Context.Cloudcore_WorkItemDelay(ActiveWorkItem.InstanceId, reactivateAt);
        }

        public void Release()
        {
            CloudCoreDB.Context.Cloudcore_WorkItemRelease( ActiveWorkItem.InstanceId);
        }
    }
}
