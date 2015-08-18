namespace CloudCore.VirtualWorker.Engine.OrphanProtection
{
    public class KeepAliveSettings
    {
        private static volatile KeepAliveSettings _settings;

        public static KeepAliveSettings Instance
        {
            get
            {
                if (_settings == null)
                    _settings = new KeepAliveSettings();

                return _settings;
            }
        }
        private const int DefaultTimeOutInSeconds = 900;
        private volatile int _timeOutInSeconds = DefaultTimeOutInSeconds; // read from config?
        internal int TimeOutInSeconds
        {
            get
            {
                return _timeOutInSeconds;
            }
            set
            {
                _timeOutInSeconds = value;
            }
        }

        private const byte DefaultCheckIntervalInSeconds = 5;
        private volatile byte _checkIntervalInSeconds = DefaultCheckIntervalInSeconds; // read from config?
        internal byte CheckIntervalInSeconds
        {
            get
            {
                return _checkIntervalInSeconds;
            }
            set
            {
                _checkIntervalInSeconds = value;
            }
        }

    }
}
