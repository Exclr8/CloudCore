using System.Collections.Generic;
using System.Configuration;
using CloudCore.Data.Buildbase;

namespace CloudCore.Data
{
    public class CloudCoreDB : CloudCoreDBBase
    {
        public CloudCoreDB()
            : base(ConfigurationManager.ConnectionStrings["cloudcore"].ConnectionString)
        {
            ObjectTrackingEnabled = false;
        }

        public CloudCoreDB(string connectionString)
            : base(connectionString)
        {
            ObjectTrackingEnabled = false;
        }

        public static CloudCoreDB Context
        {
            get { return new CloudCoreDB(); }
        }
    }
}
