using System;
using Btomic;

namespace FrameworkOne.EditorExtentions.Data.Version1
{
    public partial class BtomicDB : BtomicDBBase
        {
            public BtomicDB()
                : base(Dbsettings.MyConnectionString)
            {
                this.ObjectTrackingEnabled = false;
            }

            public static BtomicDB Context
            {
                get { return new BtomicDB(); }
            }

            public Guid? NewGuid()
            {
                return Guid.NewGuid();
            }
    }
}
