using System;
using CloudCore.Domain;

namespace CloudCore.Web.Core.Security
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SystemActionAttribute : Attribute
    {
        public string ActionGuid { get; set; }
        public string Caption { get; set; }
        public SystemActionType ActionType { get; set; }
    }
}
