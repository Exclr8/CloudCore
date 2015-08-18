using System;
using CloudCore.Core.Core.VirtualWorker.Instance.Tasks;

namespace Core.Common.Tests.Core.VirtualWorker.Instance
{
    public static class WorkListObjectMother
    {
        public static WorklistItem FailureItem(int maxRetries = 0, int retries = 0)
        {
            return new WorklistItem
                {
                    MaxRetries = maxRetries,
                    Retries = retries,
                    ActivityId = 1,
                    InstanceId = 1,
                    KeyValue = 1,
                    ActivityGuid = Guid.NewGuid()
                };
        }
    }
}