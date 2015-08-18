using System;



namespace CloudCore.Domain
{
    [Serializable]
    public class SystemModule
    {
        public Guid SystemModuleGuid { get; set; }
        public string AssemblyName { get; set; }
        public long SystemModuleId { get; set; }
    }

}
