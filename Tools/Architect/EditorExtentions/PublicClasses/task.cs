using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Btomic
{
    public class Task
    {
        public int TaskID { get; set; }
        public int ProcessID { get; set; }
        public int SystemModuleID { get; set; }
        public string TaskName { get; set; }
        public int Priority { get; set; }
        public bool DocWait { get; set; }
        public System.Data.Linq.Binary LastUpdate { get; set; }
        public bool Outdated { get; set; }
        public Nullable<Guid> Guid { get; set; }
    }
}
