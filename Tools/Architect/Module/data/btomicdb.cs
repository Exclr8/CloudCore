namespace Btomic
{
    public partial class BtomicDB : BtomicDBBase
    {
        public BtomicDB()
            : base(Btomic.Application.ConnectionString("btomic")) {
                this.ObjectTrackingEnabled = false;
        }

        public BtomicDB(string connectionString)
            : base(connectionString)
        {
            ObjectTrackingEnabled = false;
        }

        public static BtomicDB Context
        {
            get { return new BtomicDB(); }
        }
    }


}

