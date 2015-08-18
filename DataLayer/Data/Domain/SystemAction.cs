using System;
using System.Collections.Generic;
using System.Linq;



namespace CloudCore.Domain
{
    //[Serializable]
    //public class SystemAction : Entity
    //{
    //    public Guid ActionGuid { get; set; }
    //    public SystemModule Module { get; set; }
    //    public string Title { get; set; }
    //    public string Area { get; set; }
    //    public string Controller { get; set; }
    //    public string Action { get; set; }

    //    public SystemActionType ActionType { get; set; }
    //}

    public enum SystemActionType
    {
        Folder,
        Create,
        Details,
        Delete,
        Modify,
        Search,
        Report,
        Statistic,
        Tools
    }
}
