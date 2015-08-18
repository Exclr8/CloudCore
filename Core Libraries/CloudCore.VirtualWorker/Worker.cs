using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CloudCore.Configuration.ConfigFile;
using CloudCore.Configuration.ConfigFile.Location;
using CloudCore.Core;
using CloudCore.Core.Data;
using CloudCore.Core.DependencyResolution;
using CloudCore.Core.Hosting.VirtualFiles;
using CloudCore.Core.Logging;
using CloudCore.Core.Modules;
using CloudCore.Logging;
using CloudCore.Logging.Configuration;
using CloudCore.VirtualWorker.Engine;
using CloudCore.VirtualWorker.Engine.DashboardTask;
using CloudCore.VirtualWorker.Engine.OrphanProtection;
using CloudCore.VirtualWorker.Engine.ScheduledTask;
using CloudCore.VirtualWorker.Engine.Workflow;
using CloudCore.VirtualWorker.ScheduledTasks;
using CloudCore.VirtualWorker.Threading;
using CloudCore.VirtualWorker.Threading.ScheduledTask;
using CloudCore.VirtualWorker.Threading.Workflow;
using CloudCore.VirtualWorker.WorkflowActivities;
using Microsoft.WindowsAzure.ServiceRuntime;
using Environment = CloudCore.Core.Modules.Environment;
using CloudCore.VirtualWorker.DashboardKpi;
using CloudCore.Data;

namespace CloudCore.VirtualWorker
{
    public delegate void GenericLoopEventHandler();

    public abstract partial class Worker : IModuleHost, ILocationConfigurable
    {
        #region Constructors

        protected Worker()
        {
            exitStrategy = new ExitStrategy();
            InitializeMainWorkerSettings();
        }

        private void InitializeMainWorkerSettings()
        {
            Logger.SetLogger(GetLogger(), GetVerbosityLevel());
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            var settings = ReadConfig.SettingsOnWorkerApplication.Workers;
            SleepIntervalTimeInSeconds = settings.SleepIntervalInSeconds;
            SetLocationConfiguration();
        }

        protected virtual int GetWorkflowParallelThreadCount()
        {
            return ReadConfig.SettingsOnWorkerApplication.Workers.WorkflowParallelThreadCount;
        }

        protected void SetKeepAliveTimeOut(byte timeOutInSeconds)
        {
            if (timeOutInSeconds < 3)
                throw new ArgumentException(@"Cannot set the KeepAliveTimeOut ""timeOutInSeconds"" parameter value to less than 3 seconds. " +
                                            @"Allow at least 3 seconds for the engines to keep their running tasks alive."
                                            , "timeOutInSeconds");

            KeepAliveSettings.Instance.TimeOutInSeconds = timeOutInSeconds;
        }

        #endregion

        #region Startup Operations

        /// <summary>
        /// When overriden in a derived class, it should return all modules that you desire to be registered that contain processes and 
        /// scheduled tasks for the Virtual Worker to understand and execute.
        /// </summary>
        protected abstract IEnumerable<CloudCoreModule> RegisterWorkerModules();

        public bool OnStart()
        {
            try
            {
                Logger.Info("CloudCore Virtual Worker entry point called.", LogCategories.WorkerAppInitialize, ignoreVerbosityConfig: true);
                InitializeIoC();
                Environment.InitializeModuleHost(this);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Exception during start-up initialization.", ex, LogCategories.WorkerAppInitialize, ignoreVerbosityConfig: true);
                return false;
            }
        }

        private static void InitializeIoC()
        {
            Logger.Info("Initializing Inversion of Control...");
            IoC.Initialize();
        }

        protected virtual ILogger GetLogger()
        {
            return new TraceLogger();
        }

        protected virtual VerbosityLevel GetVerbosityLevel()
        {
            return ReadConfig.SettingsOnWorkerApplication.Logging.VerbosityLevel;
        }


        public virtual void SetLocationConfiguration()
        {
            LocationConfig = ReadConfig.SettingsOnWorkerApplication.Location;
        }

        #endregion

        #region Main Execution

        public void Run()
        {
            StartScheduledTaskEngines();
            StartDashboardTaskEngines();
            StartWorkflowEngines();
            StartThreadCrashMonitor();

            Logger.Info("All engines started.", LogCategories.EngineStart, ignoreVerbosityConfig: true);

            OnAllOperationsStarted();
            AnticipateShutDownSignal();
        }

        protected void StartScheduledTaskEngines()
        {
            try
            {
                StartNormalScheduledTaskMonitor();
                StartFailingScheduledTaskMonitor();

                Logger.Info("Scheduled Task Engines started successfully.", LogCategories.EngineStart, ignoreVerbosityConfig: true);
            }
            catch (Exception exception)
            {
                Logger.Fatal("Scheduled Task engines failed to start.", exception);
                throw;
            }
        }

        protected void StartDashboardTaskEngines()
        {
            try
            {
                Logger.Info("Starting Dashboard Task Engine...", LogCategories.EngineStart,
                ignoreVerbosityConfig: true);

                var dashboardTaskContext = new DashboardTaskOperationContext(
                    SleepIntervalTimeInSeconds,
                    LogCategories.DashboardTask,
                    new TaskThreadSafeDataAccess(),
                    exitStrategy,
                    dashboardTaskTypes,
                    OnScheduledTaskMonitorLooped);

                foreach (var task in WorkerOperationFactory<DashboardTaskOperation>.Construct(dashboardTaskContext))
                {
                    ActiveEngines.Add(task);
                }


                Logger.Info("Dashboard Task Engines started successfully.", LogCategories.EngineStart, ignoreVerbosityConfig: true);
            }
            catch (Exception exception)
            {
                Logger.Fatal("Dashboard Task engines failed to start.", exception);
                throw;
            }
        }

        private void StartNormalScheduledTaskMonitor()
        {
            Logger.Info("Starting Normal Scheduled Task Engine...", LogCategories.EngineStart,
                ignoreVerbosityConfig: true);

            var scheduledTaskContext = new ScheduledTaskMonitorContext(
                SleepIntervalTimeInSeconds,
                scheduledTaskTypes,
                LogCategories.ScheduledTaskMonitor,
                new NormalScheduledTaskThreadSafeDataAccess(),
                exitStrategy,
                OnScheduledTaskMonitorLooped);

            foreach (var task in WorkerOperationFactory<NormalScheduledTaskEngine>.Construct(scheduledTaskContext))
            {
                ActiveEngines.Add(task);
            }
        }

        private void StartFailingScheduledTaskMonitor()
        {
            Logger.Info("Starting Scheduled Task Failing Monitoring Engine...", LogCategories.EngineStart,
                ignoreVerbosityConfig: true);

            var failedScheduledTaskContext = new ScheduledTaskMonitorContext(
                SleepIntervalTimeInSeconds,
                scheduledTaskTypes,
                LogCategories.FailingScheduledTaskMonitor,
                new FailingScheduledTaskThreadSafeDataAccess(),
                ExitStrategy,
                OnFailedScheduledTaskMonitorLooped);

            foreach (var task in WorkerOperationFactory<FailedScheduledTaskEngine>.Construct(failedScheduledTaskContext))
            {
                ActiveEngines.Add(task);
            }
        }

        protected void StartWorkflowEngines()
        {
            try
            {
                StartNormalWorkflowMonitor();
                StartFailingWorkflowMonitor();

                Logger.Info("Workflow Engines started successfully.", LogCategories.EngineStart, ignoreVerbosityConfig: true);
            }
            catch (Exception exception)
            {
                Logger.Fatal("Workflow engines failed to start.", exception);
                throw;
            }
        }

        private void StartNormalWorkflowMonitor()
        {
            Logger.Info("Starting Normal Workflow Engine...", LogCategories.EngineStart, ignoreVerbosityConfig: true);

            var workflowContext = new WorkflowContext(
                SleepIntervalTimeInSeconds,
                LocationConfig,
                activityTypes,
                LogCategories.WorkflowEngine,
                new NormalWorkflowThreadSafeDataAccess(),
                exitStrategy,
#if DEBUG
 OnWorkflowMonitorLooped,
                OnUnsafeCallback,
                GetWorkflowParallelThreadCount());
#else
                OnWorkflowMonitorLooped,
                GetWorkflowParallelThreadCount());
#endif

            foreach (var task in WorkerOperationFactory<NormalWorkflowEngine>.Construct(workflowContext))
            {
                ActiveEngines.Add(task);
            }
        }

        private void StartFailingWorkflowMonitor()
        {
            Logger.Info("Starting Workflow Failing Monitoring  Engine...", LogCategories.EngineStart, ignoreVerbosityConfig: true);

            var failedWorkflowContext = new WorkflowContext(
                SleepIntervalTimeInSeconds,
                LocationConfig,
                activityTypes,
                LogCategories.FailingWorkflowEngine,
                new FailingWorkflowThreadSafeDataAccess(),
                exitStrategy,
                OnWorkflowFailMonitorLooped,
                GetWorkflowParallelThreadCount());

            foreach (var task in WorkerOperationFactory<FailedWorkflowEngine>.Construct(failedWorkflowContext))
            {
                ActiveEngines.Add(task);
            }
        }

        private void AnticipateShutDownSignal()
        {
            while (!ExitStrategy.Quitting)
            {
                Logger.Debug("Main thread still alive.");
                Sleep(1);
            }

            Logger.Info("Shut-down signal received. Waiting for child threads to exit cleanly...", "General",
                ignoreVerbosityConfig: true);

            while (ActiveEngines.Any(task => task.ThreadedTask.Status == TaskStatus.Running))
            {
                Sleep(1);
            }

            Logger.Info("Application has shut down.");
        }

        #endregion

        #region Callback Hooks

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Fatal("Unhandled Exception caught!", e.ExceptionObject as Exception, "Unhandled Exception");
        }

        public event GenericLoopEventHandler ScheduledTaskMonitorLoopedHandler;
        protected void OnScheduledTaskMonitorLooped()
        {
            if (ScheduledTaskMonitorLoopedHandler != null)
            {
                ScheduledTaskMonitorLoopedHandler.Invoke();
            }
        }

        public event GenericLoopEventHandler FailedScheduledTaskMonitorLoopedHandler;
        protected void OnFailedScheduledTaskMonitorLooped()
        {
            if (FailedScheduledTaskMonitorLoopedHandler != null)
            {
                FailedScheduledTaskMonitorLoopedHandler.Invoke();
            }
        }

        public event GenericLoopEventHandler WorkflowMonitorLoopedHandler;
        protected void OnWorkflowMonitorLooped()
        {
            if (WorkflowMonitorLoopedHandler != null)
            {
                WorkflowMonitorLoopedHandler.Invoke();
            }
        }

        public event GenericLoopEventHandler WorkflowOrphanMonitorLoopedHandler;
        protected void OnWorkflowOrphanMonitorLooped()
        {
            if (WorkflowOrphanMonitorLoopedHandler != null)
            {
                WorkflowOrphanMonitorLoopedHandler.Invoke();
            }
        }

        public event GenericLoopEventHandler WorkflowFailMonitorHandler;
        protected void OnWorkflowFailMonitorLooped()
        {
            if (WorkflowFailMonitorHandler != null)
            {
                WorkflowFailMonitorHandler.Invoke();
            }
        }

        public event GenericLoopEventHandler OrphanScheduledTaskMonitorLoopedHandler;
        protected void OnOrphanScheduledTaskMonitorLooped()
        {
            if (OrphanScheduledTaskMonitorLoopedHandler != null)
            {
                OrphanScheduledTaskMonitorLoopedHandler.Invoke();
            }
        }

        public event GenericLoopEventHandler AllOperationsStartedHandler;
        protected void OnAllOperationsStarted()
        {
            if (AllOperationsStartedHandler != null)
            {
                AllOperationsStartedHandler.Invoke();
            }
        }

        #endregion

        #region Shutdown

        public void Stop()
        {
            Logger.Warn("Shutdown signal received! Notifying threads...", LogCategories.ShutdownSequence, ignoreVerbosityConfig: true);
            ExitStrategy.Quitting = true;
        }

        #endregion

        #region Implementation of IModuleHost

        List<CloudCoreModule> IModuleHost.RegisterModules()
        {
            var modulesToLoad = FilterDuplicateModules(GetCoreModules(), RegisterWorkerModules());
            return modulesToLoad.ToList();
        }

        private IEnumerable<CloudCoreModule> FilterDuplicateModules(List<CloudCoreModule> coreModules, IEnumerable<CloudCoreModule> clientModules)
        {
            clientModules = clientModules.Where(client => !coreModules.Any(core => core.AssemblyName == client.AssemblyName)).ToList();
            coreModules.AddRange(clientModules);
            return coreModules;
        }

        private List<CloudCoreModule> GetCoreModules()
        {
            var modulesToLoad = new List<CloudCoreModule>
            {
                new CloudCoreDataModule(),
                new CoreCommonModule(),
            };
            return modulesToLoad;
        }

        private static void DeployModuleDashboards(CloudCoreModule module)
        {
            var dashboards = (from a in module.Assembly.GetTypes()
                              where a.IsClass && !a.IsAbstract && a.GetInterfaces().Contains(typeof(IDashboard))
                              select a).ToList();

            foreach (var dbDashboard in dashboards.Select(dashboard => new DBDashboard(dashboard, module.Assembly)))
            {
                dbDashboard.Deploy();
            }
        }

        void IModuleHost.OnAllModulesRegistered(List<CloudCoreModule> loadedModules)
        {
            Logger.Info("Checking for custom modules...", LogCategories.WorkerAppInitialize, ignoreVerbosityConfig: true);

            foreach (var module in loadedModules.Where(r => r.ModuleType == CloudCoreModuleType.Process).ToList())
            {
                try
                {
                    Logger.Info(string.Format("Loading module {0}...", module.Assembly.FullName), LogCategories.WorkerAppInitialize, ignoreVerbosityConfig: true);
                    IoC.AdditionalConfiguration(module);
                    LoadModuleWorkflowActivities(module);
                    LoadModuleScheduledTasks(module);
                    LoadModuleDashboardTasks(module);
                    DeployModuleDashboards(module);
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("Module registration failed for {0}.", module.Assembly.FullName), ex, LogCategories.WorkerAppInitialize, ignoreVerbosityConfig: true);
                }
            }

            Logger.Info("Custom modules have finished loading.", LogCategories.WorkerAppInitialize, ignoreVerbosityConfig: true);
        }

        protected Dictionary<string, Type> LoadModuleScheduledTasks(CloudCoreModule module)
        {
            var scheduledTasks = (from a in module.Assembly.GetTypes()
                                  where a.IsClass && !a.IsAbstract &&
                                        a.IsSubclassOf(typeof(ScheduledTask))
                                  select a).ToList();

            foreach (var scheduledTask in scheduledTasks)
            {
                scheduledTaskTypes.Add(scheduledTask.Name, scheduledTask);
            }

            return scheduledTaskTypes;
        }

        protected Dictionary<string, Type> LoadModuleDashboardTasks(CloudCoreModule module)
        {
            var dashboardTasks = (from a in module.Assembly.GetTypes()
                                  where a.IsClass && !a.IsAbstract && a.GetInterfaces().Contains(typeof(IDashboard))
                                  select a).ToList();

            foreach (var dashboardTask in dashboardTasks)
            {
                dashboardTaskTypes.Add(dashboardTask.Name, dashboardTask);
            }

            return dashboardTaskTypes;
        }

        protected Dictionary<string, Type> LoadModuleWorkflowActivities(CloudCoreModule item)
        {
            var activities = (from a in item.Assembly.GetTypes()
                              where a.IsClass && !a.IsAbstract &&
                                    a.GetInterfaces().Contains(typeof(IActivity))
                              select a).ToList();

            foreach (var activity in activities)
            {
                activityTypes.Add(activity.Name, activity);
            }

            return activityTypes;
        }

        #endregion

        #region Fields / Properties

        public static CloudCoreResourcePathProvider<EmbeddedResourceVirtualFile> VirtualPathProvider
        {
            get { return virtualPathProvider; }
        }

        public volatile ExitStrategy exitStrategy;

        public ExitStrategy ExitStrategy
        {
            get
            {
                return exitStrategy;
            }
            private set
            {
                exitStrategy = value;
            }
        }

        private readonly Dictionary<string, Type> activityTypes = new Dictionary<string, Type>();
        private readonly Dictionary<string, Type> scheduledTaskTypes = new Dictionary<string, Type>();
        private readonly Dictionary<string, Type> dashboardTaskTypes = new Dictionary<string, Type>();
        private readonly SynchronizedCollection<WorkerTask> activeEngines = new SynchronizedCollection<WorkerTask>();

        public SynchronizedCollection<WorkerTask> ActiveEngines
        {
            get
            {
                return activeEngines;
            }
        }

        private ILocationConfig LocationConfig { get; set; }

        protected int SleepIntervalTimeInSeconds;
        private readonly static CloudCoreResourcePathProvider<EmbeddedResourceVirtualFile> virtualPathProvider = new CloudCoreResourcePathProvider<EmbeddedResourceVirtualFile>();

        #endregion

    }
}
