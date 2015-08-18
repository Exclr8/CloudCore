using System.Configuration;
using CloudCore.Configuration.ConfigFile.Elements;

namespace CloudCore.Configuration.ConfigFile
{
    public class CloudCoreWorkerSection : CloudCoreCommonSection
    {
        [ConfigurationProperty("worker", IsRequired = false)]
        public WorkerElement Workers
        {
            get
            {
                return (WorkerElement)this["worker"];
            }
            set
            { this["worker"] = value; }
        }
    }
}
