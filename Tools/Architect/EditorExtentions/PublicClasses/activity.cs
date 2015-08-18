using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Btomic
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public int SubProcessID { get; set; }
        public string ActivityName { get; set; }
        public byte ActivityInd { get; set; }
        public string ActivityType { get; set; }
        public bool Startable { get; set; }
        public bool IsMenuItem { get; set; }
        public System.Data.Linq.Binary LastUpdate { get; set; }
        public bool Outdated { get; set; }
        public Nullable<Guid> Guid { get; set; }
    }
}
