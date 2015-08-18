using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudCore.Configuration.ConfigFile.Location;
using CloudCore.Data;
using CloudCore.Domain.Workflow;
using CloudCore.Logging;
using CloudCore.VirtualWorker.Engine.OrphanProtection;
using CloudCore.VirtualWorker.Exceptions;
using CloudCore.VirtualWorker.Threading;
using CloudCore.VirtualWorker.WorkflowActivities;

namespace CloudCore.VirtualWorker.Engine.Workflow
{
    public abstract class WorkflowLoopOperation : WorkerOperation, IOrphanProtection
    {
        protected readonly Dictionary<string, Type> ActivityClassTypes;
        protected readonly ILocationConfig LocationConfig;

        protected WorkflowLoopOperation(WorkflowContext context)
            : base(context)
        {
            ActivityClassTypes = context.ActivityTypes;
            LocationConfig = context.LocationConfig;
        }

        public override IEnumerable<WorkerTask> CreateTaskThreads()
        {
            var tasks = new List<WorkerTask>();
            var parallelThreadCount = ((WorkflowContext) OperationContext).ParallelThreadCount;

            for (var i = 1; i <= parallelThreadCount; i++)
            {
                var loopTask = Task.Factory.StartNew(t => WorkflowMonitorLoop(), TaskCreationOptions.LongRunning);
                var cloudTask = new WorkerTask(OperationContext.LoggingCategory, loopTask, WorkflowMonitorLoop, EngineType.Workflow);
                tasks.Add(cloudTask);
            }
            return tasks;
        }

        public void WorkflowMonitorLoop()
        {
            while (!ExitStrategy.Quitting)
            {
                var worklistItem = GetWorklistItem();

                if (worklistItem.InstanceId.HasValue && worklistItem.ActivityGuid.HasValue
                    && worklistItem.MaxRetries.HasValue && worklistItem.CurrentRetries.HasValue)
                {
                    try
                    {
                        Logger.Debug(String.Format(@"Executing workflow activity ""{0}"" ({1}) for Instance {2}...",
                                                    worklistItem.ActivityName,
                                                    worklistItem.ActivityGuid.Value,
                                                    worklistItem.InstanceId.Value),
                                    OperationContext.LoggingCategory);

                        var workflowActivity = PrepareWorkflowItemForExecution(worklistItem);

                        try
                        {
                            StartKeepAlive(worklistItem.InstanceId.Value);
                            workflowActivity.ExecuteActivity();
                        }
                        finally
                        {
                            StopKeepAlive();
                        }

                        DoCallback();

                        Logger.Debug(String.Format(@"Workflow activity ""{0}"" ({1}) for Instance {2} completed.",
                                                    worklistItem.ActivityName,
                                                    worklistItem.ActivityGuid.Value,
                                                    worklistItem.InstanceId.Value),
                                    OperationContext.LoggingCategory);
                    }
                    catch (DataThreadDeadlockException deadlockException)
                    {
                        Logger.Fatal(String.Format(@"Could not do final update for Workflow Instance {0} after execution. Exiting...",
                                                    worklistItem.InstanceId.Value),
                                     deadlockException, OperationContext.LoggingCategory);

                        ExitStrategy.Quitting = true;
                        throw;
                    }
                    catch (Exception exception)
                    {
                        var message = LogError(worklistItem, exception);
                        HandleWorklistFailure(worklistItem.InstanceId.Value, message, worklistItem.MaxRetries.Value, worklistItem.CurrentRetries.Value);
                    }
#if DEBUG
                    DoUnsafeCallback();
#endif
                }
                else
                {
                    DoCallback();
                    Logger.Debug("No workflow items available. Sleeping...", OperationContext.LoggingCategory);
                    Sleep(OperationContext.SleepIntervalTimeInSeconds);
                }
            }
        }

        protected virtual WorklistItem GetWorklistItem()
        {
            return (
                LocationConfig != null
                    ? (LocationConfig.LocationAware
                            ? GetLocationAwareWorklistItem()
                            : GetNonLocationAwareWorklistItem())

                    : GetNonLocationAwareWorklistItem()
            );
        }

        private BaseActivity PrepareWorkflowItemForExecution(WorklistItem worklistItem)
        {
            if (worklistItem.ActivityGuid != null)
            {
                var activityClassType = DetermineActivityClassType(worklistItem);
                var workerActivity = (BaseActivity)Activator.CreateInstance(activityClassType);
                workerActivity.SetThreadSafeDataAccessObject(OperationContext.ThreadSafeDataAccess);
                workerActivity.SetWorkItemData(worklistItem);
                return workerActivity;
            }

            throw new NullReferenceException(string.Format(@"Preparation of Worklist Activity Type Instance did not "
                                                             + @"contain all required worklist data. Please see Type ""{0}"""
                                                             + "for the required fields.",
                                                           typeof(WorklistItem)));
        }

        private Type DetermineActivityClassType(WorklistItem worklistItem)
        {
            Type activityClassType = null;

            if (worklistItem.ActivityGuid != null)
            {
                var classTypeName = "_" + worklistItem.ActivityGuid.Value.ToString().Replace("-", "_").ToLower();

                if (!ActivityClassTypes.TryGetValue(classTypeName, out activityClassType))
                {
                    throw new UnknownWorkerTaskTypeException(String.Format(@"Unexpected workflow activity type encountered: {0} " +
                                                                           @"for activity guid {1}. (Have you registered all your modules? " +
                                                                           @"Please see ""CloudCore.Deployment.VirtualWorker.Worker.RegisterWorkerModules()"" " +
                                                                           @"for more information.)", classTypeName, worklistItem.ActivityGuid));
                }
            }

            return activityClassType;
        }

        private static string PrepareWorkflowInstanceErrorMessage(long intanceId, string activityName, Exception ex)
        {
            var message = String.Format(@"Execution failed for Workflow Activity ""{0}"", Instance {1}. ",
                                         activityName,
                                         intanceId);
            message += ex.Message
                       + " -- Exception: " + ex.GetType()
                       + " -- Message: " + ex.Message
                       + " -- Stack Trace: " + ex.StackTrace;

            if (ex.InnerException != null)
            {
                var innerException = ex.InnerException;
                message += innerException.Message
                           + " -- Inner Exception: " + innerException.GetType()
                           + " -- Inner Message: " + innerException.Message
                           + " -- Inner Stack Trace: " + ex.StackTrace;
            }

            return message;
        }

        private string LogError(WorklistItem worklistItem, Exception exception)
        {
            var message = PrepareWorkflowInstanceErrorMessage(worklistItem.InstanceId.Value, worklistItem.ActivityName,
                exception);
            Logger.Error(message, exception, OperationContext.LoggingCategory);
            return message;
        }

        public void StartKeepAlive(long instanceId)
        {
            ResetKeepAlive();

            var keepAliveRoutine = new Action(() =>
            {
                Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
                KeepWorkflowItemAlive(instanceId);
                Thread.CurrentThread.Priority = ThreadPriority.Normal;
            });

            Task.Factory.StartNew(t => keepAliveRoutine(), null, TaskCreationOptions.PreferFairness);
        }

        private void KeepWorkflowItemAlive(long instanceId)
        {
            Logger.Debug(String.Format("Keep-Alive session has started for Workflow Item Instance ID {0}.", instanceId),
                OperationContext.LoggingCategory);

            using (var database = new CloudCoreDB())
            {
                while (ShouldKeepAlive && !ExitStrategy.Quitting)
                {
                    SendKeepAliveHeartBeat(instanceId, database);
                    OnWorkflowKeptAlive(instanceId);
                    Sleep(KeepAliveSettings.Instance.CheckIntervalInSeconds);
                }
            }

            Logger.Debug(String.Format("Keep-Alive session has ended for Workflow Item Instance ID {0}.", instanceId),
                OperationContext.LoggingCategory);
        }

        public delegate void WorkflowKeptAlive(long instanceId);
        public event WorkflowKeptAlive WorkflowKeptAliveHandler;
        private void OnWorkflowKeptAlive(long instanceId)
        {
            if (WorkflowKeptAliveHandler != null)
                WorkflowKeptAliveHandler.Invoke(instanceId);
        }

        public virtual void SendKeepAliveHeartBeat(long instanceId, CloudCoreDB database)
        {
            OperationContext.ThreadSafeDataAccess.DataAccessOperation(() => database.Cloudcore_WorkflowKeepAlive(instanceId));
        }

        public bool ShouldKeepAlive { get; private set; }

        public void StopKeepAlive()
        {
            ShouldKeepAlive = false;
        }

        public void ResetKeepAlive()
        {
            ShouldKeepAlive = true;
        }

        private void HandleWorklistFailure(long instanceId, string message, int maxRetries, int currentRetries)
        {
            var outcome = GetFailureStatusOutcome(maxRetries, currentRetries);
            OnFailureStatusOutcomeDetermined(outcome);
            UpdateFailureOutcome(instanceId, message, outcome);
            // add event for update?
        }

        protected abstract WorkItemStatus GetFailureStatusOutcome(int maxRetries, int currentRetries);

        public delegate void WorkflowFailureStatusOutcomeDetermined(WorkItemStatus outcomeStatusId);
        protected WorkflowFailureStatusOutcomeDetermined FinalStatusOutcomeDeterminedHandler;
        private void OnFailureStatusOutcomeDetermined(WorkItemStatus outcomeStatusId)
        {
            if (FinalStatusOutcomeDeterminedHandler != null)
                FinalStatusOutcomeDeterminedHandler.Invoke(outcomeStatusId);
        }

        protected virtual void UpdateFailureOutcome(long instanceId, string message, WorkItemStatus outcomeStatus)
        {
            try
            {
                OperationContext.ThreadSafeDataAccess.DataAccessOperation(() =>
                {
                    using (var database = new CloudCoreDB())
                    {
                        database.Cloudcore_WorkItemFail(instanceId, message, (byte)outcomeStatus.Id);
                    }
                });
            }
            catch (DataThreadDeadlockException ex)
            {
                Logger.Fatal(String.Format("Unable to update workflow final failure status after execution (ID {0}). Exiting...", instanceId),
                             ex, OperationContext.LoggingCategory);

                ExitStrategy.Quitting = true;
                throw;
            }
        }
        
        protected abstract WorklistItem GetNonLocationAwareWorklistItem();
        protected abstract WorklistItem GetLocationAwareWorklistItem();

        protected WorklistItem GetNonLocationAwareWorklistItem(WorkItemStatus workflowStatusType)
        {
            long? instanceId = null;
            int? activityId = null;
            Guid? activityGuid = null;
            long? keyValue = null;
            int? maxRetries = null;
            int? currentRetries = null;
            string activityName = String.Empty;

            OperationContext.ThreadSafeDataAccess.DataAccessOperation(() =>
            {
                using (var database = new CloudCoreDB())
                {
                    database.Cloudcore_WorkItemStartFromVirtualWorker(
                        Core.Modules.Environment.ApplicationId,
                        (int)workflowStatusType.Id,
                        KeepAliveSettings.Instance.TimeOutInSeconds,
                        ref activityGuid,
                        ref activityId,
                        ref instanceId,
                        ref keyValue,
                        ref maxRetries,
                        ref currentRetries,
                        ref activityName);
                }
            });

            return new WorklistItem(activityId, activityGuid, activityName, maxRetries, currentRetries)
            {
                InstanceId = instanceId,
                KeyValue = keyValue
            };
        }

        protected WorklistItem GetLocationAwareWorklistItem(WorkItemStatus workflowStatusType)
        {
            long? instanceId = null;
            int? activityId = null;
            Guid? activityGuid = null;
            long? keyValue = null;
            int? maxRetries = null;
            int? currentRetries = null;
            string activityName = String.Empty;

            OperationContext.ThreadSafeDataAccess.DataAccessOperation(() =>
            {
                using (var database = new CloudCoreDB())
                {
                    database.Cloudcore_WorkItemStartFromVirtualWorkerByLocation(
                        Core.Modules.Environment.ApplicationId,
                        (int)workflowStatusType.Id,
                        KeepAliveSettings.Instance.TimeOutInSeconds,
                        ref activityGuid,
                        ref activityId,
                        ref instanceId,
                        ref keyValue,
                        LocationConfig.Latitude,
                        LocationConfig.Longitude,
                        LocationConfig.RadiusInMeters,
                        ref maxRetries,
                        ref currentRetries,
                        ref activityName);
                }
            });

            return new WorklistItem(activityId, activityGuid, activityName, maxRetries, currentRetries)
            {
                InstanceId = instanceId,
                KeyValue = keyValue
            };
        }
    }

    public class WorklistItem
    {
        public WorklistItem() { }

        public WorklistItem(int? activityId, Guid? activityGuid, string activityName, int? maxRetries, int? currentRetries)
        {
            ActivityId = activityId;
            ActivityGuid = activityGuid;
            ActivityName = activityName;
            MaxRetries = maxRetries;
            CurrentRetries = currentRetries;
        }

        public long? InstanceId { get; set; }
        public long? KeyValue { get; set; }

        internal int? ActivityId { get; private set; }
        internal Guid? ActivityGuid { get; private set; }
        internal string ActivityName { get; private set; }
        internal int? MaxRetries { get; private set; }
        internal int? CurrentRetries { get; private set; }
    }
}
