using System;
using System.Collections.Generic;
using CloudCore.VirtualWorker.Tests.Engine.Workflow.Mocks;

namespace CloudCore.VirtualWorker.Tests.Engine.Workflow
{
    public static class ActivityObjectMother
    {
        public static Dictionary<string, Type> GenerateFakeFailingActivities()
        {
            return new Dictionary<string, Type>
            {
                {
                    "_57953b5b_1e35_45ff_950b_100c2566c843", 
                    typeof (_57953b5b_1e35_45ff_950b_100c2566c843)
                },
                {
                    "_2333cd82_1bc3_4a55_8c93_33e189600b33", 
                    typeof (_2333cd82_1bc3_4a55_8c93_33e189600b33)
                }
            };
        }
    }
}