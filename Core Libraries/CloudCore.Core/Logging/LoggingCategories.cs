
namespace CloudCore.Core.Logging
{
    public class LogCategories
    {
        public static readonly string AppInit = "CloudCore Application Initialization";
        public static readonly string EngineStart = "Engine Start";
        public static readonly string ShutdownSequence = "Shutdown Sequence";
        public static readonly string ThreadCrashMonitor = "Thread Crash Monitor";

        public static readonly string WorkerAppInitialize = "Worker Application Initialization";
        public static readonly string WebAppInitialize = "Web Application Initialization";
        public static readonly string WebModuleDeploy = "Module Deployment";
        public static readonly string WebProcessingResources = "Embedded Resources Initialization";

        public static readonly string WorkflowEngine = "Workflow Monitoring Engine";
        public static readonly string FailingWorkflowEngine = "Failing Workflow Monitoring Engine";
        public static readonly string WorkflowOrphanProtection = "Orphan Workflow Item Protection";
        
        public static readonly string ScheduledTaskMonitor = "Scheduled Task Monitoring Engine";
        public static readonly string FailingScheduledTaskMonitor = "Failing Scheduled Task Monitoring Engine";
        public static readonly string ScheduledTaskOrphanProtection = "Orphan Scheduled Task Protection";
        
        public static readonly string DashboardTask = "Dashboard Task Engine";
    }
}
