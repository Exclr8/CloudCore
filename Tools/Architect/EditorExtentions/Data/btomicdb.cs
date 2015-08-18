using System;
using System.ComponentModel;
using Btomic;

namespace Btomic
{
    public partial class BtomicDB : BtomicDBBase
    {
        public BtomicDB()
            : base(Dbsettings.MyConnectionString) {
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

