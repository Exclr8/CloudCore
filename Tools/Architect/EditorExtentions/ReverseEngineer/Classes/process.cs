using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Btomic
{
    public class ActivityType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class Process
    {
        public int ProcessID { get; set; }
        public string ProcessName { get; set; }
        public int ManagerID { get; set; }
        public int EntityID { get; set; }
        public System.Data.Linq.Binary LastUpdate { get; set; }
        public bool Outdated { get; set; }
        public Nullable<Guid> Guid { get; set; }
    }

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

    public class Activity
    {
        public int ActivityID { get; set; }
        public int TaskID { get; set; }
        public string ActivityName { get; set; }
        public byte ActivityInd { get; set; }
        public string ActivityType { get; set; }
        public bool Startable { get; set; }
        public bool IsMenuItem { get; set; }
        public System.Data.Linq.Binary LastUpdate { get; set; }
        public bool Outdated { get; set; }
        public Nullable<Guid> Guid { get; set; }
    }

    public class FlowMap
    {
        public int FlowID { get; set; }
        public int FromActivity { get; set; }
        public int OutcomeID { get; set; }
        public int ToActivity { get; set; }
        public string Storyline { get; set; }
        public System.Data.Linq.Binary LastUpdate { get; set; }
        public bool Outdated { get; set; }
        public int FromTaskID { get; set; }
        public int ToTaskID { get; set; }
        public string Outcome { get; set; }
    }
}
