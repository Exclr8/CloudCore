using System;
using System.Web.Mvc;
using CloudCore.Domain;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.CRO
{
    public class SystemValueCachedReusableObject : BaseCachedReusableObject<SystemValueCachedReusableObject>
    {
        public override string GetTitle()
        {
            return "System Value Details";
        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Value Name", ValueName);
            content.AddHtmlContent("Value Data", ValueData);
            content.AddHtmlContent("Value Description", ValueDescription);
        }

        protected override void GetPropertyValues()
        {
            CloudCoreDB database = CloudCoreDB.Context;
            var result = (from syscat in database.Cloudcore_SystemValue
                          where syscat.ValueID == ValueId
                          select new
                          {
                              syscat.ValueName,
                              syscat.ValueDescription,
                              syscat.ValueData,
                              syscat.CategoryId
                          }).SingleOrDefault();

            ValueName = result.ValueName;
            ValueData = result.ValueData;
            ValueDescription = result.ValueDescription;
            CategoryId = result.CategoryId;
        }

        #region Properties
        public int ValueId { get { return Convert.ToInt32(Key); } }
        public int CategoryId { get; set; }
        public string ValueName { get; set; }
        public string ValueData { get; set; }
        public string ValueDescription { get; set; }
        #endregion
    }
}