using System;
using System.Collections.Generic;

namespace Core.Common.Tests.Core.VirtualWorker.Instance
{
    public static class ActivityObjectMother
    {
        public static Dictionary<string, Type> Activities(Guid? guid)
        {
            var className = "_" + guid.Value.ToString().Replace("-", "_").ToLower();
            return new Dictionary<string, Type>
            {
                {className, typeof (MockedActivity)}
            };
        }
    }
}