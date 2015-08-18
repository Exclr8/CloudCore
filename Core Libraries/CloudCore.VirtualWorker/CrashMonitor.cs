using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CloudCore.Core.Logging;
using CloudCore.Logging;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker
{
    public abstract partial class Worker
    {
        public virtual void StartThreadCrashMonitor()
        {
            Logger.Info("Starting Thread Crash Monitor... ", LogCategories.ThreadCrashMonitor, ignoreVerbosityConfig: true);

            // WARNING! Please DO NOT add the following Task to any engines in the Worker.ActiveEngines collection
            // It will cause the worker to hang, because the crash monitor cannot monitor itself...
            Task.Factory.StartNew(() => CrashMonitoringEngine(), TaskCreationOptions.LongRunning);

            Logger.Info("Thread Crash Monitor has started.", LogCategories.ThreadCrashMonitor, ignoreVerbosityConfig: true);
        }

        private void CrashMonitoringEngine()
        {
            while (!ExitStrategy.Quitting)
            {
                CheckForFailedEngineThreads();
                OnThreadCrashMonitorLooped();
                Sleep(SleepIntervalTimeInSeconds);
            }
        }

        public void Sleep(int seconds)
        {
            var delayedUntil = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < delayedUntil && !ExitStrategy.Quitting)
            {
                Thread.Sleep(100);
            }
        }

        private void CheckForFailedEngineThreads()
        {
            var engineCounter = ActiveEngines.Count;

            while (engineCounter > 0 && !ExitStrategy.Quitting)
            {
                WorkerTask engineToMonitor = ActiveEngines.ElementAt(engineCounter - 1);
                
                if (engineToMonitor.ThreadedTask.Status == TaskStatus.Faulted)
                {
                    var logMessage = string.Format(@"Crashed thread restarted: Name: {0}, " + 
                                                    @"Engine type: {1}, " + 
                                                    @"Cause: {2}", 
                                                    engineToMonitor.Name, 
                                                    engineToMonitor.EngineType, 
                                                    GetCrashedThreadExceptionMessages(engineToMonitor));

                    engineToMonitor.ThreadedTask.Dispose();
                    WorkerTask engine = engineToMonitor; // local copy necessary
                    
                    if (!ExitStrategy.Quitting)
                        engineToMonitor.ThreadedTask = Task.Factory.StartNew(() => engine.MethodToExecute());

                    Logger.Warn(logMessage, "Thread Crash Monitor");
                    OnFaultedThreadRestarted();
                }

                engineCounter--;
            }
        }

        private string GetCrashedThreadExceptionMessages(WorkerTask failedEngine)
        {
            AggregateException aggregateException = failedEngine.ThreadedTask.Exception;
            string message = string.Empty;

            if (aggregateException != null)
            {
                foreach (Exception ex in aggregateException.InnerExceptions)
                {
                    message = GetInnerExceptionMessages(ex);
                    message = message.Remove(message.Length - 1);
                    
                    if (ExitStrategy.Quitting)
                        break;
                }
            }
            else
                message = "No exception found";

            return message;
        }

        private string GetInnerExceptionMessages(Exception exception)
        {
            string message = String.Format("Message:{0}| |Stack Trace:{1},", exception.Message, exception.StackTrace);
            
            if (exception.InnerException != null && !ExitStrategy.Quitting)
                message += GetInnerExceptionMessages(exception.InnerException);

            return message;
        }
        
        public event GenericLoopEventHandler ThreadCrashMonitorLoopedHandler;
        private void OnThreadCrashMonitorLooped()
        {
            if (ThreadCrashMonitorLoopedHandler != null)
            {
                ThreadCrashMonitorLoopedHandler.Invoke();
            }
        }

        public event GenericLoopEventHandler FaultedThreadRestartedHandler;
        public void OnFaultedThreadRestarted()
        {
            if (FaultedThreadRestartedHandler != null)
            {
                FaultedThreadRestartedHandler.Invoke();
            }
        }

#if DEBUG
        public event GenericLoopEventHandler UnsafeCallbackHandler;
        public void OnUnsafeCallback()
        {
            if (UnsafeCallbackHandler != null)
            {
                UnsafeCallbackHandler.Invoke();
            }
        }
#endif
    }
}
