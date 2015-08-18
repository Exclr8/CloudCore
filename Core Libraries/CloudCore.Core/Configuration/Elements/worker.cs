using System.Configuration;
using CloudCore.Logging;

namespace CloudCore.Configuration.ConfigFile.Elements
{
    public class WorkerElement : ConfigurationElement
    {
        private const int DefaultSleepIntervalInSeconds = 3;
        private const int MinimumParallelThreadCount = 2;

        [ConfigurationProperty("sleepIntervalInSeconds", DefaultValue = DefaultSleepIntervalInSeconds, IsRequired = false)]
        public int SleepIntervalInSeconds
        {
            get
            {
                int sleepInterval;

                if (!int.TryParse(this["sleepIntervalInSeconds"].ToString(), out sleepInterval))
                    sleepInterval = DefaultSleepIntervalInSeconds;

                return sleepInterval;
            }
        }

        [ConfigurationProperty("workflowParallelThreadCount", DefaultValue = MinimumParallelThreadCount, IsRequired = false)]
        public int WorkflowParallelThreadCount
        {
            get
            {
                int workflowParallelThreadCount;
                var isIncorrectSetting = false;
                var useDefault = false;
                var defaultThreadCount = System.Environment.ProcessorCount == 1 ? MinimumParallelThreadCount : System.Environment.ProcessorCount;
                var configuredValue = this["workflowParallelThreadCount"].ToString();

                if (int.TryParse(configuredValue, out workflowParallelThreadCount))
                {
                    if (workflowParallelThreadCount < MinimumParallelThreadCount)
                        isIncorrectSetting = true;
                }
                else if (string.Equals(configuredValue, "auto", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    useDefault = true;
                }
                else
                {
                    isIncorrectSetting = true;
                }

                if (isIncorrectSetting || useDefault)
                {
                    workflowParallelThreadCount = defaultThreadCount;

                    if (isIncorrectSetting)
                        Logger.Warn(string.Format(@"Cannot use incorrectly configured parallel thread count '{0}' " +
                                                  @"for work-flow engines. Using default of '{1}'.", 
                                                  configuredValue, 
                                                  defaultThreadCount));
                }

                return workflowParallelThreadCount;
            }
        }
    }
}
