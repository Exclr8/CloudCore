using System;
using System.Collections.Generic;


namespace CloudCore.Domain
{
    [Serializable]
    public class AccessPool
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public int ManagerId { get; set; }
    
    }

}
