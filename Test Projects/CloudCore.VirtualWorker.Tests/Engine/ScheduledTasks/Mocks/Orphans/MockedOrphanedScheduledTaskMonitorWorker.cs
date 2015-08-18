using System;
using System.Linq;
using System.Collections.Generic;
using CloudCore.VirtualWorker.Tests.Mocks;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Tests.Engine.ScheduledTasks.Mocks.Orphans
{
    public class MockedOrphanedScheduledTaskMonitorWorker : MockedWorker
    {
        public List<DateTime> LoopTimes = new List<DateTime>();
        public List<double> WaitTimesInSeconds = new List<double>();
        public MockedOrphanedScheduledTaskMonitorWorker()
        {
            SetKeepAliveTimeOut(4);

            OrphanScheduledTaskMonitorLoopedHandler += () =>
            {
                RecordLoopSpeed();
                LoopCount++;

                if (LoopCount >= 2)
                {
                    ExitStrategy.Quitting = true;
                }
            };
        }

        private void RecordLoopSpeed()
        {
            LoopTimes.Add(DateTime.Now);

            if (LoopCount > 0)
                WaitTimesInSeconds.Add(GetPreviousLoopTimeDifference().TotalSeconds);
        }

        private TimeSpan GetPreviousLoopTimeDifference()
        {
            return (LoopTimes[LoopCount] - LoopTimes[LoopCount - 1]);
        }

        public double GetAverageLoopWaitTime()
        {
            if (LoopCount > 0)
                return WaitTimesInSeconds.Sum() / LoopCount;

            return 0;
        }
    }
}
