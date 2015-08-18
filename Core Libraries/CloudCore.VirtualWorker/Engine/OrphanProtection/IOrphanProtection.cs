using CloudCore.Data;


namespace CloudCore.VirtualWorker.Engine.OrphanProtection
{
    public interface IOrphanProtection
    {
        void StartKeepAlive(long primaryKey);
        
        // TODO: Don't use this concrete CloudCoreDB type. Use some kind of data provider or repository
        void SendKeepAliveHeartBeat(long primaryKey, CloudCoreDB database);
        bool ShouldKeepAlive { get; }
        void StopKeepAlive();
        void ResetKeepAlive();
    }
}
