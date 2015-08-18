using System.Collections.Generic;

using CloudCore.Domain.Workflow;

using CloudCore.Data;
using System.Linq;
using CloudCore.Data.Buildbase;
using CloudCore.Domain.Specifications.Workflow;

namespace CloudCore.Domain.Workflow
{
    public abstract class StandardTaskListQuery : ITaskListQuery
    {
        public abstract string Title { get; }

        public abstract string Description { get; }

        protected readonly CloudCoreDB Datacontext = CloudCoreDB.Context;

        protected virtual IQueryable<Cloudcore_VwTasklist> DataSource
        {
            get { return Datacontext.Cloudcore_VwTasklist; }
        }

        private IQueryable<Cloudcore_VwTasklist> BaseExecute(int userId, int referenceTypeId, string referenceValue, int applicationid)
        {

            if (!string.IsNullOrEmpty(referenceValue) && referenceTypeId > 0)
            {

                return (from a in Datacontext.Cloudcore_WorklistReference
                        join b in DataSource on a.InstanceId equals b.InstanceId
                        where a.ReferenceTypeId == referenceTypeId
                           && a.Reference.ToUpper().Contains(referenceValue.ToUpper())
                           && b.UserId == userId
                           && b.ApplicationId == applicationid
                        select b);

            }
            else
            {
                var list = DataSource.Where(r => r.UserId == userId && r.ApplicationId == applicationid).AsQueryable();
                int keyid;
                if ((referenceTypeId == 0) && (int.TryParse(referenceValue, out keyid)))
                {

                    return list.Where(r => r.KeyValue == keyid);
                }
                else return list;
            }
        }

        public IEnumerable<TaskItem> Execute(int userId, int referenceTypeId, string referenceValue, int applicationid)
        {
            var query = BaseExecute(userId, referenceTypeId, referenceValue, applicationid);
            query = query.OrderByDescending(px => px.Priority).ThenBy(ax => ax.Activate).Take(5);
            return (from tasklistItem in query
                select new TaskItem
                {
                    InstanceId = tasklistItem.InstanceId,
                    Header = tasklistItem.ProcessName,
                    SubHeader = tasklistItem.SubProcessName,
                    ActivityId = tasklistItem.ActivityId,
                    ActivityGuid = tasklistItem.ActivityGuid,
                    ActivityName = tasklistItem.ActivityName,
                    KeyValue = tasklistItem.KeyValue,
                    ActivationSchedule = tasklistItem.Activate.ToLongDateString(),
                    StatusId = tasklistItem.StatusTypeId,
                    Priority = tasklistItem.Priority,
                    UserId = tasklistItem.UserId,
                    ApplicationId = tasklistItem.ApplicationId,
                    Delayed = tasklistItem.Delayed,
                    StatusTypeId = tasklistItem.StatusTypeId,
                    DocWait = tasklistItem.DocWait,
                    OpenedBy = tasklistItem.OpenedBy,
                    ProcessModelId = tasklistItem.ProcessModelId,
                    SubProcessId = tasklistItem.SubProcessId,
                    SubProcessGuid = tasklistItem.SubProcessGuid,
                    SubProcessName = tasklistItem.SubProcessName
                });
        }
    }
}