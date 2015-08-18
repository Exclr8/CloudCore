using System;
using System.Threading.Tasks;
using CloudCore.VirtualWorker.Engine;

namespace CloudCore.VirtualWorker
{
    public class WorkerTask
    {
        public WorkerTask(string name, Task task, Action action, EngineType taskType)
        {
            Name = name;
            ThreadedTask = task;
            MethodToExecute = action;
            EngineType = taskType;
        }

        public string Name { get; private set; }
        public Task ThreadedTask { get; internal set; }
        public Action MethodToExecute { get; private set; }
        public EngineType EngineType { get; private set; }
    }
}
