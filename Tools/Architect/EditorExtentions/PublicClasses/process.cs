using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Btomic
{
    public class Process
    {
        public int ProcessID { get; set; }
        public string ProcessName { get; set; }
        public int ManagerID { get; set; }
        public int EntityID { get; set; }
        public System.Data.Linq.Binary LastUpdate { get; set; }
        public bool Outdated { get; set; }
        public Guid? Guid { get; set; }
    }
}
