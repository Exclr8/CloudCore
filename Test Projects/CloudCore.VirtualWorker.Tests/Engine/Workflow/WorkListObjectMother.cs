
using System;
using System.Collections.Generic;

namespace CloudCore.VirtualWorker.Tests.Engine.Workflow
{
    public static class WorkListObjectMother
    {
        public static FakeWorklistItem GenerateFakeWorklistItem(Dictionary<string, Type> activityTypes, int maxRetries = 0, int currentRetries = 0)
        {
            return new FakeWorklistItem(activityTypes, maxRetries, currentRetries);
        }
    }
}