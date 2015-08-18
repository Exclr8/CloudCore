using System;
using System.Web.Mvc;
using CloudCore.Domain;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.CRO
{
    public class SystemValueCategoryCachedReusableObject : BaseCachedReusableObject<SystemValueCategoryCachedReusableObject>
    {
        public override string GetTitle()
        {
            return "System Value Category Details";
        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Category Name", CategoryName);
        }

        protected override void GetPropertyValues()
        {
            CloudCoreDB database = CloudCoreDB.Context;
            var result = (from syscat in database.Cloudcore_SystemValueCategory
                          where syscat.CategoryId == CategoryId
                          select new
                          {
                              syscat.CategoryName,
                              syscat.CategoryId
                          }).SingleOrDefault();

            CategoryName = result.CategoryName;
        }

        #region Properties
        public int CategoryId { get { return Convert.ToInt32(Key); } }
        public string CategoryName { get; set; }
        #endregion
    }
}