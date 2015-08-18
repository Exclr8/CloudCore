using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudCore.VirtualWorker.Engine;

namespace CloudCore.VirtualWorker.Tests.Mocks
{
    internal class WorkerTaskMother
    {
        private static readonly object RandomGlobalTasksLock = new object();
        private static readonly object NonRandomTaskGlobalTasksLock = new object();

        internal static SynchronizedCollection<WorkerTask> GenerateRandomGlobalCloudTasks(EngineType taskType)
        {
            var tasks = GenerateNormalRandomList(taskType);
            return new SynchronizedCollection<WorkerTask>(NonRandomTaskGlobalTasksLock, tasks);
        }

        internal static SynchronizedCollection<WorkerTask> GenerateRandomGlobalCloudTasks()
        {
            var tasks = GenerateNormalRandomList(null);

            return new SynchronizedCollection<WorkerTask>(RandomGlobalTasksLock, tasks);
        }

        private static IEnumerable<WorkerTask> GenerateNormalRandomList(EngineType? tasktype)
        {
            var tasks = new List<WorkerTask>();

            var random = new Random();
            var numberOfTasks = random.Next(16, 32);

            for (int i = 1; i <= numberOfTasks; i++)
            {
                var loopTask = Task.Factory.StartNew(t => FakeTaskActionMethod(), TaskCreationOptions.LongRunning);
                WorkerTask cloudTask;
                const string operationName = "Test Operation";
                if (tasktype.HasValue)
                {
                    cloudTask = new WorkerTask(operationName, loopTask,
                                                  FakeTaskActionMethod,
                                                  tasktype.Value);
                }
                else
                {
                    cloudTask = new WorkerTask(operationName, loopTask,
                                                  FakeTaskActionMethod,
                                                  i % 2 == 0 ? EngineType.ScheduledTask : (i % 3 == 0 ? EngineType.Workflow : EngineType.Maintenance));
                }

                tasks.Add(cloudTask);
            }

            return tasks;
        }

        public static void FakeTaskActionMethod() { }

    }
}
