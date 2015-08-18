using System;
using System.Diagnostics;
using CloudCore.VirtualWorker.Tests.Mocks;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Tests.Engine.Workflow.Mocks
{
    public class WorkflowFailedMockedWorker : MockedWorker
    {
        public WorkflowFailedMockedWorker()
        {
            Debug.WriteLine(string.Format("{0} - Workflow Failed Monitor Engine Tests Started.", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
            WorkflowFailMonitorHandler += () =>
            {
                LoopCount++;

                if (LoopCount >= 2)
                {
                    ExitStrategy.Quitting = true;
                    Debug.WriteLine(string.Format("{0} - Workflow Failed Monitor Engine Tests Ended.", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                }
            };
        }
    }
}
