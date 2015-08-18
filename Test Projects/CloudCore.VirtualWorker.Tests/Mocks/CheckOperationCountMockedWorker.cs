
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Tests.Mocks
{
    public class CheckOperationCountMockedWorker : MockedWorker
    {
        public CheckOperationCountMockedWorker()
        {
            AllOperationsStartedHandler += () =>
            {
                this.ExitStrategy.Quitting = true;
            };
        }
    }
}
