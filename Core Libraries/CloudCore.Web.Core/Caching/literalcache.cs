using System;
using System.Text;
using System.Web.Script.Serialization;
using CloudCore.Web.Core.Security.Authentication;


namespace CloudCore.Web.Core.Caching
{
    [Serializable]
    public class LiteralCache<T>
    {
        protected virtual void Update() { }

        public byte[] JsonData()
        {
            Update();
            var jdata = (new JavaScriptSerializer()).Serialize(this);
            return Encoding.ASCII.GetBytes(string.Format("var cc_{0} = {1}", this.GetType().Name.ToLower(), jdata));
        }

        public static string GetGuidName()
        {
            return string.Format("cc_{0}guid", typeof(T).Name);
        }

        public static string GetCacheGuid()
        {

            var pGuid = (string)SessionInfo.Session[GetGuidName()];
            
            if (string.IsNullOrEmpty(pGuid))
            {
                pGuid = ForceRefresh();
            }

            return pGuid;
        }

        public static string ForceRefresh()
        {
            var pGuid = Guid.NewGuid().ToString().Replace("-", "");
            SessionInfo.Session[GetGuidName()] = pGuid;
            return pGuid;
        }
    }
}
