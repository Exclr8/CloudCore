using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudCore.VSExtension.Wizards
{
    [Serializable]
    public class PropertyItem
    {
        public string DisplayName { get; set; }
        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }
    }
}