using System;
using CloudCore.Core.VirtualWorker.Activities;

namespace Core.Common.Tests.Core.VirtualWorker.Instance
{
    public class MockedActivity : IActivity
    {
        public void Dispose()
        {

        }

        public void DoVirtualWork(long? instanceId, long? keyValue, int? activityId, Guid? activityGuid)
        {
            throw new NotImplementedException();
        }
    }
}