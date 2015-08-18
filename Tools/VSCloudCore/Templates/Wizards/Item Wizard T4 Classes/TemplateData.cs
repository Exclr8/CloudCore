using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudCore.VSExtension.Classes.Helpers;

namespace CloudCore.VSExtension.Wizards
{
    [Serializable]
    public class TemplateData
    {
        public string Title { get; set; }
        public string ContextName { get; set; }

        public IEnumerable<PropertyItem> ModelProperties { get; set; }

        public TemplateData()
        {
            this.Title = "Title";
            this.ContextName = "";
           
        }
    }

    [Serializable]
    public class DBTemplateData : TemplateData
    {
        [NonSerialized]
        private DBContextReference _contextReference;
        public DBContextReference ContextReference { get { return _contextReference; } }
        const string defaultstring = "Persist Security Info=False;Integrated Security=SSPI;database={0};server=localhost;Connect Timeout=30";
        
        public string ConnectionString { get; set; }
        public string DBContextNamespace { get; set; }
        public string DBContextClassname { get; set; }

        public DBTemplateData()
        {
            this.ConnectionString = string.Format(defaultstring, "master");
        }

        public void SetContextReference(DBContextReference reference)
        {
            this.DBContextNamespace = reference.DBContextClass.Namespace;
            this.DBContextClassname = reference.DBContextClass.Name;
            this._contextReference = reference;
            this.ConnectionString = string.Format(defaultstring, this.DBContextClassname);
        }

    }
}