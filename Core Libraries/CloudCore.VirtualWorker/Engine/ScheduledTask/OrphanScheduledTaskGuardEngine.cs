//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using CloudCore.Core.Logging;
//using CloudCore.Data;
//using CloudCore.Logging;
//using CloudCore.VirtualWorker.Engine.OrphanProtection;
//using CloudCore.VirtualWorker.Exceptions;

//namespace CloudCore.VirtualWorker.Engine.ScheduledTask
//{
//    public class OrphanScheduledTaskGuardEngine : WorkerOperation
//    {
//        private byte failureCount;
//        public OrphanScheduledTaskGuardEngine(WorkerOperationContext context) : base(context) { }

//        public override IEnumerable<WorkerTask> CreateTaskThreads()
//        {
//            var loopTask = Task.Factory.StartNew(() => OrphanMonitorLoop(), TaskCreationOptions.LongRunning);
//            var cloudTask = new WorkerTask("Scheduled Task Orphan Protector", loopTask, OrphanMonitorLoop, EngineType.ScheduledTask);

//            return new[] { cloudTask }.ToList();
//        }

//        public void OrphanMonitorLoop()
//        {
//            failureCount = 0;
//            while (!ExitStrategy.Quitting)
//            {
//                List<Guid> outdatedTasks = new List<Guid>();

//                try
//                {
//                    outdatedTasks = ResetOutdatedScheduledTasks();
//                }
//                catch (DataThreadDeadlockException ex)
//                {
//                    Logger.Fatal("Unable to check for orphaned scheduled tasks due to a thread resource dead-lock. Now Terminating...",
//                                 ex, LogCategories.ScheduledTaskOrphanProtection);

//                    ExitStrategy.Quitting = true;
//                    throw;
//                }
//                catch (Exception ex)
//                {

//                    if (ex.Message.ToLower().Contains("deadlock") || ex.Message.ToLower().Contains("victim"))
//                    {
//                        failureCount += 1;
//                        OnOrphanResetCheckTempFailure(failureCount);

//                        if (failureCount >= 3)
//                        {
//                            Logger.Fatal("Unable to check for orphaned scheduled tasks due to a database resource dead-lock. Now Terminating...",
//                                         ex, LogCategories.ScheduledTaskOrphanProtection);
//                            ExitStrategy.Quitting = true;
//                            throw;
//                        }
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }

//                LogOutdatedTasks(outdatedTasks);
//                DoCallback();

//                if (outdatedTasks.Count > 0)
//                {
//                    Sleep(KeepAliveSettings.Instance.CheckIntervalInSeconds);
//                }
//                else
//                {
//                    Sleep(OperationContext.SleepIntervalTimeInSeconds);
//                }
//            }
//        }
        
//        private static void LogOutdatedTasks(List<Guid> outdatedTasks)
//        {
//            if (outdatedTasks.Count > 0)
//            {
//                var listToPrintToLog = outdatedTasks.Select(guid => guid.ToString()).ToList();
//                Logger.ListWrite(listToPrintToLog,
//                    "Orphaned Scheduled Tasks found and reset.",
//                    LogCategories.ScheduledTaskOrphanProtection,
//                    LogEntryType.Warning);
//            }
//        }

//        public virtual List<Guid> ResetOutdatedScheduledTasks()
//        {
//            var tasks = new List<Guid>();

//            OperationContext.ThreadSafeDataAccess.DataAccessOperation(() =>
//            {
//                using (var database = new CloudCoreDB())
//                {
//                    tasks = database.Cloudcore_ResetRunningOutdatedScheduledTasks(
//                                        KeepAliveSettings.Instance.TimeOutInSeconds,
//                                        (byte)ScheduledTaskStatusId.Running,
//                                        (byte)ScheduledTaskStatusId.Retry,
//                                        (byte)ScheduledTaskStatusId.Pending)
//                        // ReSharper disable once PossibleInvalidOperationException
//                                    .Select(task => task.ScheduledTaskGuid.Value).ToList();
//                }
//            });

//            return tasks;
//        }
//        public virtual void OnOrphanResetCheckTempFailure(byte failureCount) { }
//    }
//}
