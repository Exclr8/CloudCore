
using CloudCore.VirtualWorker.Engine.OrphanProtection;

namespace CloudCore.VirtualWorker.Threading
{
    public static class LockTimeout
    {
        public static int Value
        {
            get
            {
                return KeepAliveSettings.Instance.TimeOutInSeconds * 1000;
            }
        }
    }
}
