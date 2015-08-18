using System;
using CloudCore.Core.Core.VirtualWorker.Instance.Tasks;
using CloudCore.Data;

namespace Core.Common.Tests.Core.VirtualWorker.Instance
{
    public static class WorkflowContextObjectMother
    {
        public static WorkflowContext WorkflowContext(Guid? activityGuid)
        {
            var exit = false;
            return new WorkflowContext(0,
                                       () => exit,
                                       null,
                                       null,
                                       false,
                                       null,
                                       ActivityObjectMother.Activities(activityGuid),
                                       () => exit = true);
        }

    }
}