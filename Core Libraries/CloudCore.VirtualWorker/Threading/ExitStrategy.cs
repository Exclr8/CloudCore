using System.Threading;
using CloudCore.Logging;
using CloudCore.VirtualWorker.Exceptions;

namespace CloudCore.VirtualWorker.Threading
{
    public class ExitStrategy
    {
        private volatile bool _quitting;

        public static ExitStrategy New
        {
            get
            {
                return new ExitStrategy();
            }
        }
        public bool Quitting
        {
            get
            {
                return _quitting;
            }
            set
            {
                _quitting = value;
            }
        }
    }
}
