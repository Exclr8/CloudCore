using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudCore.Data;
using CloudCore.Logging;
using CloudCore.VirtualWorker.Exceptions;
using CloudCore.VirtualWorker.ScheduledTasks;
using System.Text;
using System.Collections;

namespace CloudCore.VirtualWorker.Engine.DashboardTask
{
    public class DashboardTaskOperation : WorkerOperation
    {
        protected readonly Dictionary<string, Type> DashboardTaskClassTypes;

        public DashboardTaskOperation(DashboardTaskOperationContext context)
            : base(context)
        {
            DashboardTaskClassTypes = context.DashboardTaskClassTypes;
        }

        public override IEnumerable<WorkerTask> CreateTaskThreads()
        {
            var loopTask = Task.Factory.StartNew(DashboardTaskLoop, TaskCreationOptions.LongRunning);
            var cloudTask = new WorkerTask(OperationContext.LoggingCategory, loopTask, DashboardTaskLoop, EngineType.ScheduledTask);

            return new[] { cloudTask };
        }

        public void DashboardTaskLoop()
        {
            while (!ExitStrategy.Quitting)
            {
                List<DashboardItemInfo> dashboardTasksToRun;

                try
                {
                    dashboardTasksToRun = GetDashboardTasksToRun();
                }
                catch (DataThreadDeadlockException ex)
                {
                    Logger.Fatal("Could not check for Dashboard Tasks that are due.", ex, OperationContext.LoggingCategory);
                    ExitStrategy.Quitting = true;
                    throw;
                }

                if (dashboardTasksToRun != null && dashboardTasksToRun.Count > 0)
                {
                    StartDashboardTasks(dashboardTasksToRun);

                    DoCallback();
                }
                else
                {
                    DoCallback();

                    Sleep(OperationContext.SleepIntervalTimeInSeconds);
                }
            }
        }

        private void StartDashboardTasks(IEnumerable<DashboardItemInfo> dashboardTasks)
        {
            foreach (var dashboardTask in dashboardTasks)
            {
                var tempTask = dashboardTask; // local copy necessary

                // WARNING! Please DO NOT add the following Task to any engines in the Worker.ActiveEngines collection
                // Failing Scheduled Task threads should NOT be auto-restarted by the worker thread crash monitor engine.
                // Failures are handled by the FailedScheduledTaskEngine
                Task.Factory.StartNew(t => ExecuteDashboardTask(tempTask), TaskCreationOptions.PreferFairness);
            }
        }

        public void ExecuteDashboardTask(DashboardItemInfo dashboardTaskInfo)
        {
            try
            {
                var dashboardGuid = dashboardTaskInfo.DashboardGuid.ToString()
                    .Replace("-", "_").ToLower();

                var classTypeName = (string.Format(@"_{0}", dashboardGuid));
                Type dashboardClassType;

                if (!DashboardTaskClassTypes.TryGetValue(classTypeName, out dashboardClassType))
                {
                    throw new UnknownWorkerTaskTypeException(string.Format(@"A Class Type could not be found in the loaded modules to instantiate " +
                                                                           @"the dashboard task for execution. Dashboard Task GUID {0}." +
                                                                           @"(Have you registered all your modules? Please see " +
                                                                           @"""CloudCore.Deployment.VirtualWorker.Worker.RegisterWorkerModules()"" " +
                                                                           @"for more information.)", dashboardTaskInfo.DashboardGuid));
                }

                var dashboardTask = ((IScheduledTask)Activator.CreateInstance(dashboardClassType));
                dashboardTask.Execute();

                UpdateDashboardTask(dashboardTaskInfo, DashboardTaskStatus.Pending);
            }
            catch (Exception ex)
            {
                try
                {
                    var exceptionMessage = FlattenExceptionsIntoOneMessage(ex);
                    DashboardTaskFailed(dashboardTaskInfo, exceptionMessage);
                }
                finally
                {
                    Logger.Info(ex.Message, OperationContext.LoggingCategory);
                    ExitStrategy.Quitting = true;  
                }
            }
        }

        private void UpdateDashboardTask(DashboardItemInfo dashboardTaskInfo, DashboardTaskStatus status)
        {
            OperationContext.ThreadSafeDataAccess.DataAccessOperation(() =>
            {
                using (var database = new CloudCoreDB())
                {
                    database.Cloudcore_DashboardTaskUpdate(
                        dashboardTaskInfo.DashboardId,
                        (byte)status);
                }
            });
        }

        private void DashboardTaskFailed(DashboardItemInfo dashboardTaskInfo, string failureReason)
        {
            using (var database = new CloudCoreDB())
            {
                database.Cloudcore_DashboardFailed(dashboardTaskInfo.DashboardId, failureReason, (byte)DashboardTaskStatus.Failed);
            }
        }

        private List<DashboardItemInfo> GetDashboardTasksToRun()
        {
            var dashboardTasksToRun = new List<DashboardItemInfo>();

            OperationContext.ThreadSafeDataAccess.DataAccessOperation(() =>
            {
                using (var database = new CloudCoreDB())
                {
                    dashboardTasksToRun = (from t in database.Cloudcore_DashboardTasksToRun()
                                           let dashboardId = t.DashboardId
                                           where dashboardId.HasValue
                                           let dashboardGuid = t.DashboardGuid
                                           where dashboardGuid.HasValue
                                           let systemModuleId = t.SystemModuleId
                                           where systemModuleId.HasValue
                                           let title = t.Title
                                           where !String.IsNullOrWhiteSpace(title) 
                                           let description = t.Description
                                           where !String.IsNullOrWhiteSpace(description)
                                           select new DashboardItemInfo
                                           {
                                               DashboardId = dashboardId.Value,
                                               DashboardGuid = dashboardGuid.Value,
                                               SystemModuleId = systemModuleId.Value,
                                               Title = title,
                                               Description = description
                                           }).ToList();
                }
            });

            return dashboardTasksToRun;
        }

        private string FlattenExceptionsIntoOneMessage(Exception exception)
        {
            var message = new StringBuilder();

            message.AppendLine(String.Format("ExceptionType: {0}", exception.GetType().Name));
            message.AppendLine(String.Format("   ExceptionMessage: {0}", exception.Message));

            if (exception.Data.Count > 0)
            {
                message.AppendLine("   Data: ");
                foreach (var value in exception.Data.Cast<DictionaryEntry>())
                {
                    message.AppendLine(String.Format("      {0}", value.Value.ToString()));
                }
            }

            message.AppendLine(String.Format("   StackTrace: {0}", exception.StackTrace));

            if (exception.InnerException != null)
            {
                message.AppendLine("");
                message.AppendLine(FlattenExceptionsIntoOneMessage(exception.InnerException));
            }

            return message.ToString();
        }
    }
}
