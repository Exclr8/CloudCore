using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudCore.Core.Logging;
using CloudCore.Data;
using CloudCore.Data.Buildbase;
using CloudCore.Domain.Workflow;
using CloudCore.Logging;
using CloudCore.VirtualWorker.Engine.OrphanProtection;
using CloudCore.VirtualWorker.Exceptions;

namespace CloudCore.VirtualWorker.Engine.Workflow
{
    public class OrphanWorkflowGuardEngine : WorkerOperation
    {
        public OrphanWorkflowGuardEngine(WorkerOperationContext context) : base(context) { }

        public override IEnumerable<WorkerTask> CreateTaskThreads()
        {
            var loopTask = Task.Factory.StartNew(OrphanMonitorLoop, TaskCreationOptions.LongRunning);
            var cloudTask = new WorkerTask(OperationContext.LoggingCategory, loopTask, OrphanMonitorLoop, EngineType.ScheduledTask);

            return new[] { cloudTask }.ToList();
        }

        public void OrphanMonitorLoop()
        {
            while (!ExitStrategy.Quitting)
            {
                var outdatedWorkItems = new List<Cloudcore_ResetRunningOutdatedWorkflowItemsResult>();

                try
                {
                    OperationContext.ThreadSafeDataAccess.DataAccessOperation(() =>
                    {
                        outdatedWorkItems = ResetOutdatedWorkflowItems();
                    });
                }
                catch (DataThreadDeadlockException ex)
                {
                    Logger.Fatal("Unable to check for orphaned workflow items. Exiting...", ex, LogCategories.WorkflowOrphanProtection);
                    ExitStrategy.Quitting = true;
                    throw;
                }

                if (outdatedWorkItems.Count > 0)
                {
                    var listToPrintToLog = outdatedWorkItems.Select(outdatedTask => string.Format(@"Instance {0} - Activity {1}, ", outdatedTask.InstanceId, outdatedTask.ActivityId)).ToList();
                    
                    Logger.ListWrite(listToPrintToLog,
                                     "Orphaned Workflow Items found and reset.", 
                                     "Orphan Workflow Monitoring Engine", 
                                     LogEntryType.Warning);
                }

                DoCallback();
                Sleep(KeepAliveSettings.Instance.TimeOutInSeconds); // reason we use KeepAliveSettings.Instance.TimeOutInSeconds is so that keep-alive is given enough chance to keep-alive before the next orphan check is done
            }
        }

        public virtual List<Cloudcore_ResetRunningOutdatedWorkflowItemsResult> ResetOutdatedWorkflowItems()
        {
            var tasks = new List<Cloudcore_ResetRunningOutdatedWorkflowItemsResult>();

            OperationContext.ThreadSafeDataAccess.DataAccessOperation(() =>
            {
                var db = new CloudCoreDB();
                tasks = db.Cloudcore_ResetRunningOutdatedWorkflowItems(
                    KeepAliveSettings.Instance.TimeOutInSeconds,
                    WorkItemStatus.Running.Id,
                    WorkItemStatus.Retry.Id,
                    WorkItemStatus.Pending.Id).ToList();
            });

            return tasks;
        }
    }
}
