using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Tests.Mocks
{
    public class EngineLoopLimiter
    {
        private ExitStrategy exitStrategy;
        public EngineLoopLimiter(ExitStrategy exitStrategy)
        {
            this.exitStrategy = exitStrategy;
        }
        public static EngineLoopLimiter New(ExitStrategy exitStrategy)
        {
            return new EngineLoopLimiter(exitStrategy);
        }
        public byte LoopCount = 0;
        public void OnEngineLooped()
        {
            LoopCount++;

            // not worth waisting loops...
            if (LoopCount > 3)
                exitStrategy.Quitting = true;
        }
    }
}
