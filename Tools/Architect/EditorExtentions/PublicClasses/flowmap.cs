using System;

namespace Btomic
{
    public class FlowMap
    {
        public int FlowID { get; set; }
        public Guid? FlowGuid { get; set; }
        public int FromActivity { get; set; }
        public int OutcomeID { get; set; }
        public int ToActivity { get; set; }
        public string Storyline { get; set; }
        public System.Data.Linq.Binary LastUpdate { get; set; }
        public bool Outdated { get; set; }
        public string Outcome { get; set; }
        public bool OptimalFlow { get; set; }
        public bool NegativeFlow { get; set; }
        public bool HasTrigger { get; set; }
    }
}
