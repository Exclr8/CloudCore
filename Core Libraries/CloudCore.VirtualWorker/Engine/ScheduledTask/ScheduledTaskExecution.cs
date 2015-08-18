using System;
using System.Threading;
using System.Threading.Tasks;
using CloudCore.Core.Logging;
using CloudCore.Data;
using CloudCore.Logging;
using CloudCore.VirtualWorker.Engine.OrphanProtection;
using CloudCore.VirtualWorker.ScheduledTasks;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Engine.ScheduledTask
{
    public class ScheduledTaskExecution : IOrphanProtection
    {
        private readonly IScheduledTask _cSharpScheduledTask;
        private readonly string _storedProcedureName;
        private readonly int _scheduledTaskid;
        private readonly IThreadSafeDataAccess _threadSafeDataAccess;
        private readonly ExitStrategy _exitStrategy;

        public ScheduledTaskExecution(IScheduledTask scheduledTask, int scheduledTaskId, IThreadSafeDataAccess threadSafeDataAccess, ExitStrategy exitStrategy)
        {
            _scheduledTaskid = scheduledTaskId;
            _cSharpScheduledTask = scheduledTask;
            _threadSafeDataAccess = threadSafeDataAccess;
            _exitStrategy = exitStrategy;
        }

        public ScheduledTaskExecution(string storedProcedureName, int scheduledTaskid, IThreadSafeDataAccess threadSafeDataAccess, ExitStrategy exitStrategy)
        {
            _scheduledTaskid = scheduledTaskid;
            _storedProcedureName = storedProcedureName;
            _threadSafeDataAccess = threadSafeDataAccess;
            _exitStrategy = exitStrategy;
        }

        public void Execute()
        {
            try
            {
                StartKeepAlive(_scheduledTaskid);

                if (TaskTypeIsCSharp())
                {
                    _cSharpScheduledTask.Execute();
                }
                else
                {
                    using (var database = new CloudCoreDB())
                    {
                        database.CommandTimeout = 240;
                        database.ExecuteCommand(string.Format("exec {0}", _storedProcedureName));
                    }
                }
            }
            finally
            {
                StopKeepAlive();
            }
        }

        private bool TaskTypeIsCSharp()
        {
            return _cSharpScheduledTask != null;
        }

        public delegate void ScheduledTaskKeptAlive(long instanceId);
        public event ScheduledTaskKeptAlive ScheduledTaskKeptAliveHandler;
        public void StartKeepAlive(long scheduledTaskId)
        {
            ResetKeepAlive();

            var keepAliveRoutine = new Action(() =>
            {
                Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
                KeepScheduledTaskAlive(scheduledTaskId);
                Thread.CurrentThread.Priority = ThreadPriority.Normal;
            });

            var task = Task.Factory.StartNew(t => keepAliveRoutine(), null, TaskCreationOptions.PreferFairness);
        }

        private void KeepScheduledTaskAlive(long scheduledTaskId)
        {
            Logger.Debug(string.Format("Keep-Alive session has started for Scheduled Task ID {0}.", scheduledTaskId),
                LogCategories.ScheduledTaskMonitor);

            using (var database = new CloudCoreDB())
            {
                byte retryCount = 0;

                while (ShouldKeepAlive && !_exitStrategy.Quitting)
                {
                    try
                    {
                        SendKeepAliveHeartBeat(scheduledTaskId, database);
                        retryCount = 0;
                        
                        if (ScheduledTaskKeptAliveHandler != null)
                            ScheduledTaskKeptAliveHandler.Invoke(scheduledTaskId);
                    }
                    catch (Exception ex)
                    {
                        if (retryCount > 3)
                        {
                            Logger.Fatal(string.Format("Keep-Alive session failed for Scheduled Task ID {0}. Now Terminating...", scheduledTaskId), ex);
                            _exitStrategy.Quitting = true;
                        }

                        retryCount++;
                    }

                    Sleep(KeepAliveSettings.Instance.CheckIntervalInSeconds);
                }
            }

            Logger.Debug(string.Format("Keep-Alive session has ended for Scheduled Task ID {0}.", scheduledTaskId),
                LogCategories.ScheduledTaskMonitor);
        }

        private void Sleep(int seconds)
        {
            var delayedUntil = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < delayedUntil && !_exitStrategy.Quitting)
            {
                Thread.Sleep(100);
            }
        }

        public virtual void SendKeepAliveHeartBeat(long scheduledTaskId, CloudCoreDB database)
        {
            _threadSafeDataAccess.DataAccessOperation(() => database.Cloudcore_ScheduledTaskKeepAlive((int)scheduledTaskId));
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
    }
}
