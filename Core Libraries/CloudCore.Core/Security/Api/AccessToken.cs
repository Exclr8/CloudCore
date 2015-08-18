using System;
using CloudCore.Configuration.ConfigFile;
using CloudCore.Domain;

using CloudCore.Data;
using System.Linq;
using System.Data.Linq;
using CloudCore.Data.Buildbase;

namespace CloudCore.Core.Security.Api
{
    [Serializable]
    public class AccessToken 
    {
        private readonly int expiryHours = ReadConfig.SettingsOnWebApplication.Api.TokenExpiry;

        private Cloudcore_User user = null;

        public DateTime Expiry { get; set; }

        public int UserId { get; set; }

        public int ApplicationId { get; set; }

        public string Secret { get; set; }

        public AccessToken() { }

        public AccessToken( int applicationId, int userId)
        {
            ApplicationId = applicationId;
            UserId = userId;

            Secret = Guid.NewGuid().ToString();
            Expiry = DateTime.Now.AddHours(expiryHours);

            DateTime? lastlogin = DateTime.Now;
            CloudCoreDB.Context.Cloudcore_LoginUpdate(userId, applicationId, ref lastlogin);
        }
       
        public static AccessToken ReadFromCache(string secret)
        {
            return null;// cacheProvider.Get<AccessToken>(secret);
        }

        public void WriteToCache()
        {
           // cacheProvider.Add(Secret, this, TimeSpan.FromHours(expiryHours));
        }

        public void UpdateUserLogin()
        {
            DateTime? lastlogin = DateTime.Now;
            CloudCoreDB.Context.Cloudcore_LoginUpdate(user.UserId, this.ApplicationId, ref lastlogin);
        }
    }
}
