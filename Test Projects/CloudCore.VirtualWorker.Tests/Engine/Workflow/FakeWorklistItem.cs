using System;
using System.Collections.Generic;
using System.Linq;
using CloudCore.VirtualWorker.Engine.Workflow;

namespace CloudCore.VirtualWorker.Tests.Engine.Workflow
{
    public class FakeWorklistItem : WorklistItem
    {
        public FakeWorklistItem(Dictionary<string, Type> activityTypes, int maxRetries = 0, int currentRetries = 0) :
            base(9235, 
                 new Guid(activityTypes.First().Value.Name.Substring(activityTypes.First().Value.Name.IndexOf("_", StringComparison.Ordinal) + 1, activityTypes.First().Value.Name.Length - 1 - activityTypes.First().Value.Name.IndexOf("_", System.StringComparison.Ordinal)).Replace("_", "-")),
                 "Fake Activity", maxRetries, currentRetries)
        {
            var random = new Random();
            InstanceId = random.Next(1, 999999);
            KeyValue = random.Next(1, 999999);
        }
    }
}
