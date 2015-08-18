using System;
using System.Web.Mvc;
using CloudCore.Domain;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Linq;
using System.Data.Linq;

namespace CloudCore.Admin.Classes.CachedReusableObjects
{
    public class AccessPoolCachedReusableObject : BaseCachedReusableObject<AccessPoolCachedReusableObject>
    {
        public override string GetTitle()
        {
            return "Access Pool Details";
        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Access Pool Name", AccessPoolName);
            content.AddHtmlContent("Manager", FullName);
            content.AddEmailContent("Email", Email, Email);
        }

        protected override void GetPropertyValues()
        {

            CloudCoreDB database = CloudCoreDB.Context;
            var result = (from accpool in database.Cloudcore_AccessPool
                          join manager in database.Cloudcore_User
                            on accpool.ManagerId equals manager.UserId
                          where accpool.AccessPoolId == AccessPoolId
                          select new
                          {
                              accpool.AccessPoolId,
                              accpool.AccessPoolName,
                              manager.UserId,
                              manager.Fullname,
                              manager.Email,
                              manager.Login
                          }).SingleOrDefault();

            AccessPoolName = result.AccessPoolName;
            UserId = result.UserId;
            FullName = result.Fullname;
            Email = result.Email;
            Login = result.Login;
        }

        #region Properties
        public int AccessPoolId { get { return Convert.ToInt32(Key); } }
        public string AccessPoolName { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        #endregion
    }
}