using System;
using System.Linq;
using System.Security.Claims;

namespace CloudCore.Web.Core.Security.Api.Identity
{
    [Serializable]
    public class CloudCoreApiIdentity : ClaimsIdentity
    {
        public int ApplicationId
        {
            get
            {
                return int.Parse(Claims.First(c => c.Type == "ApplicationId").Value);
            }
        }

        public int UserId
        {
            get
            {
                return int.Parse(Claims.First(c => c.Type == "UserId").Value);
            }
        }
    }
}