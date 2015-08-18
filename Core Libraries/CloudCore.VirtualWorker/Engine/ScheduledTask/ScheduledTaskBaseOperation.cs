using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CloudCore.Core.Logging;
using CloudCore.Data;
using CloudCore.Logging;
using CloudCore.VirtualWorker.Engine.OrphanProtection;
using CloudCore.VirtualWorker.Exceptions;
using CloudCore.VirtualWorker.Reporting;
using CloudCore.VirtualWorker.ScheduledTasks;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Engine.ScheduledTask
{
    public abstract class ScheduledTaskBaseOperation : WorkerOperation
    {
        protected readonly Dictionary<string, Type> ScheduledTaskClassTypes;

        protected ScheduledTaskBaseOperation(ScheduledTaskMonitorContext context)
            : base(context)
        {
            ScheduledTaskClassTypes = context.ScheduledTaskTypes;
        }

        public override IEnumerable<WorkerTask> CreateTaskThreads()
        {
            var loopTask = Task.Factory.StartNew(ScheduledTaskMonitorLoop, TaskCreationOptions.LongRunning);
            var cloudTask = new WorkerTask(OperationContext.LoggingCategory, loopTask, ScheduledTaskMonitorLoop, EngineType.ScheduledTask);

            return new[] { cloudTask };
        }

        public void ScheduledTaskMonitorLoop()
        {
            while (!ExitStrategy.Quitting)
            {
                List<ScheduledTaskExecutionInfo> scheduledTasksToRun;

                try
                {
                    scheduledTasksToRun = GetScheduledTasksToRun();
                }
                catch (DataThreadDeadlockException ex)
                {
                    Logger.Fatal("Could not check for Scheduled Tasks that are due.", ex, OperationContext.LoggingCategory);
                    ExitStrategy.Quitting = true;
                    throw;
                }

                if (scheduledTasksToRun != null && scheduledTasksToRun.Count > 0)
                {
                    StartScheduledTasks(scheduledTasksToRun);
                    Logger.ListWrite(scheduledTasksToRun.Select(t => t.ScheduledTaskName).ToList(),
                                     string.Format("Started {0} scheduled tasks.", scheduledTasksToRun.Count),
                                     LogCategories.ScheduledTaskMonitor);
                    DoCallback();
                }
                else
                {
                    DoCallback();
                    Logger.Debug("No scheduled tasks available. Sleeping...", OperationContext.LoggingCategory);
                    Sleep(OperationContext.SleepIntervalTimeInSeconds);
                }
            }
        }

        private void StartScheduledTasks(IEnumerable<ScheduledTaskExecutionInfo> scheduledTasks)
        {
            foreach (var scheduledTask in scheduledTasks)
            {
                var tempTask = scheduledTask; // local copy necessary

                // WARNING! Please DO NOT add the following Task to any engines in the Worker.ActiveEngines collection
                // Failing Scheduled Task threads should NOT be auto-restarted by the worker thread crash monitor engine.
                // Failures are handled by the FailedScheduledTaskEngine
                Task.Factory.StartNew(t => ExecuteScheduledTask(tempTask), TaskCreationOptions.PreferFairness);
            }
        }

        public void ExecuteScheduledTask(ScheduledTaskExecutionInfo scheduledTaskInfo)
        {
            try
            {
                ScheduledTaskExecution execution = PrepareScheduledTaskForExecution(scheduledTaskInfo);
                execution.Execute();
                RescheduleTask(scheduledTaskInfo);

                Logger.Debug(string.Format(@"Scheduled Task ""{0}"" has finished.", scheduledTaskInfo.ScheduledTaskName),
                            LogCategories.ScheduledTaskMonitor);

            }
            catch (DataThreadDeadlockException ex)
            {
                Logger.Fatal(string.Format(@"Scheduled Task {0} could not be rescheduled. Exiting...",
                                            scheduledTaskInfo.ScheduledTaskName),
                             ex, OperationContext.LoggingCategory);

                ExitStrategy.Quitting = true;
                throw;
            }
            catch (Exception ex)
            {
                var message = PrepareExecutionErrorMessage(scheduledTaskInfo.ScheduledTaskId, scheduledTaskInfo.ScheduledTaskName, ex);
                Logger.Error(message, ex, OperationContext.LoggingCategory);

                var outcome = HandleScheduledTaskFailure(scheduledTaskInfo.ScheduledTaskId,
                                                         message,
                                                         scheduledTaskInfo.MaximumRetries,
                                                         scheduledTaskInfo.CurrentRetries);

                if (outcome == ScheduledTaskStatusId.Failed)
                    SendFailureReportViaEmail(scheduledTaskInfo.ScheduledTaskId, message);
            }
        }

        private ScheduledTaskExecution PrepareScheduledTaskForExecution(ScheduledTaskExecutionInfo scheduledTaskInfo)
        {
            ScheduledTaskExecution execution;
            var scheduleTaskGuidName = scheduledTaskInfo.ScheduledTaskGuid.ToString()
                .Replace("-", "_")
                .Replace("{", string.Empty)
                .Replace("}", string.Empty).ToLower();


            if (scheduledTaskInfo.ScheduledTaskType == ExecutionType.Sql)
            {
                var storedProcName = string.Format("[cloudcore].[CCScheduledTask_{0}]", scheduleTaskGuidName);
                execution = new ScheduledTaskExecution(storedProcName, scheduledTaskInfo.ScheduledTaskId, OperationContext.ThreadSafeDataAccess, ExitStrategy);
            }
            else
            {
                var classTypeName = (string.Format(@"_{0}", scheduleTaskGuidName));
                Type scheduledTaskClassType;

                if (!ScheduledTaskClassTypes.TryGetValue(classTypeName, out scheduledTaskClassType))
                {
                    throw new UnknownWorkerTaskTypeException(string.Format(@"A Class Type could not be found in the loaded modules to instantiate " +
                                                                           @"the scheduled task for execution. Scheduled Task GUID {0}." +
                                                                           @"(Have you registered all your modules? Please see " +
                                                                           @"""CloudCore.Deployment.VirtualWorker.Worker.RegisterWorkerModules()"" " +
                                                                           @"for more information.)", scheduledTaskInfo.ScheduledTaskGuid));
                }

                var scheduledTask = ((IScheduledTask)Activator.CreateInstance(scheduledTaskClassType));
                execution = new ScheduledTaskExecution(scheduledTask, scheduledTaskInfo.ScheduledTaskId, OperationContext.ThreadSafeDataAccess, ExitStrategy);
            }
            return execution;
        }

        private static string PrepareExecutionErrorMessage(int scheduledTaskId, string scheduledTaskName, Exception ex)
        {
            var message = string.Format(@"Execution failed for Scheduled Task ""{0}"" ({1}).",
                                         scheduledTaskName,
                                         scheduledTaskId);
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

        private void RescheduleTask(ScheduledTaskExecutionInfo scheduledTaskInfo)
        {
            OperationContext.ThreadSafeDataAccess.DataAccessOperation(() =>
            {
                using (var database = new CloudCoreDB())
                {
                    database.Cloudcore_ScheduledTaskUpdateOutcome(
                        scheduledTaskInfo.ScheduledTaskId,
                        (int)ScheduledTaskStatusId.Pending,
                        reason: string.Empty);
                }
            });
        }

        protected virtual void SendFailureReportViaEmail(int scheduledTaskId, string errorMessage)
        {
            var report = new ScheduledTaskFailureEmailReport(scheduledTaskId, errorMessage);
            report.Send();
        }

        private ScheduledTaskStatusId HandleScheduledTaskFailure(int scheduledTaskId, string message, int maxRetries, int currentRetries)
        {
            var outcome = GetFailureStatusOutcome(maxRetries, currentRetries);
            OnFailureStatusOutcomeDetermined(outcome);
            UpdateFailureOutcome(scheduledTaskId, message, outcome);
            return outcome;
        }

        protected abstract ScheduledTaskStatusId GetFailureStatusOutcome(int maxRetries, int currentRetries);

        public delegate void ScheduledTaskFailureStatusOutcomeDetermined(ScheduledTaskStatusId outcomeStatusId);
        protected ScheduledTaskFailureStatusOutcomeDetermined FinalStatusOutcomeDeterminedHandler;
        private void OnFailureStatusOutcomeDetermined(ScheduledTaskStatusId outcomeStatusId)
        {
            if (FinalStatusOutcomeDeterminedHandler != null)
                FinalStatusOutcomeDeterminedHandler.Invoke(outcomeStatusId);
        }

        protected virtual void UpdateFailureOutcome(int scheduledTaskId, string message, ScheduledTaskStatusId outcomeStatus)
        {
            try
            {
                OperationContext.ThreadSafeDataAccess.DataAccessOperation(() =>
                {
                    using (var database = new CloudCoreDB())
                    {
                        database.Cloudcore_ScheduledTaskUpdateOutcome(scheduledTaskId, (byte)outcomeStatus, message);
                    }
                });
            }
            catch (DataThreadDeadlockException ex)
            {
                Logger.Fatal(string.Format("Unable to update scheduled task final failure outcome after execution (ID {0}). Exiting...", scheduledTaskId),
                             ex, OperationContext.LoggingCategory);

                ExitStrategy.Quitting = true;
                throw;
            }
        }

        protected abstract List<ScheduledTaskExecutionInfo> GetScheduledTasksToRun();

        protected List<ScheduledTaskExecutionInfo> GetScheduledTasksToRun(ScheduledTaskStatusId scheduledTaskStatusId)
        {
            var scheduledTasksToRun = new List<ScheduledTaskExecutionInfo>();

            OperationContext.ThreadSafeDataAccess.DataAccessOperation(() =>
            {
                using (var database = new CloudCoreDB())
                {
                    scheduledTasksToRun = (from t in database.Cloudcore_ScheduledTasksToRun((int)scheduledTaskStatusId, KeepAliveSettings.Instance.TimeOutInSeconds)
                                           let scheduledTaskId = t.ScheduledTaskId
                                           where scheduledTaskId.HasValue
                                           let scheduledTaskGuid = t.ScheduledTaskGuid
                                           where scheduledTaskGuid.HasValue
                                           let retries = t.Retries
                                           where retries.HasValue
                                           let maxRetries = t.MaxRetries
                                           where maxRetries.HasValue
                                           let scheduledTaskTypeId = t.ScheduledTaskTypeId
                                           where scheduledTaskTypeId != null
                                           select new ScheduledTaskExecutionInfo
                                           {
                                               ScheduledTaskId = scheduledTaskId.Value,
                                               ScheduledTaskGuid = scheduledTaskGuid.Value,
                                               ScheduledTaskName = t.ScheduledTaskName,
                                               ScheduledTaskType = (ExecutionType)scheduledTaskTypeId.Value,
                                               CurrentRetries = retries.Value,
                                               MaximumRetries = maxRetries.Value
                                           }).ToList();
                }
            });

            return scheduledTasksToRun;
        }
    }
}