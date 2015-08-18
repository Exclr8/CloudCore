using System;
using System.Web.Mvc;
using CloudCore.Domain;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.CRO
{
    public class SystemApplicationCachedReusableObject : BaseCachedReusableObject<SystemApplicationCachedReusableObject>
    {
        public override string GetTitle()
        {
            return "System Application Details";
        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Application Name", ApplicationName);
            content.AddHtmlContent("Company Name", CompanyName);
            content.AddHtmlContent("Contact Person", ContactPerson);
            content.AddHtmlContent("Contact Number", ContactNumber);
            content.AddHtmlContent("Enabled", Enabled ? "Yes" : "No");
        }

        protected override void GetPropertyValues()
        {
            CloudCoreDB database = CloudCoreDB.Context;
            var result = (from sysapp in database.Cloudcore_SystemApplication
                          where sysapp.ApplicationId == ApplicationId
                          select new
                          {
                              sysapp.ApplicationName,
                              sysapp.CompanyName,
                              sysapp.ContactNumber,
                              sysapp.ContactPerson,
                              sysapp.Enabled
                          }).SingleOrDefault();

            ApplicationName = result.ApplicationName;
            ContactNumber = result.ContactNumber;
            CompanyName = result.CompanyName;
            ContactPerson = result.ContactPerson;
            this.Enabled = result.Enabled;
        }

        public int ApplicationId { get { return Convert.ToInt32(Key); } }
    
        public string ApplicationName { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public bool Enabled { get; set; }
    }
}