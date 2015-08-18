using System;
using System.Configuration;
using CloudCore.Logging;
using CloudCore.Logging.Configuration;

namespace CloudCore.Configuration.ConfigFile.Elements
{

    public class LoggingElement : ConfigurationElement, ILoggingConfig
    {
        private const VerbosityLevel DefaultVerbosityLevel = Logger.DefaultLogVerbosity;

        [ConfigurationProperty("verbosityLevel", DefaultValue = DefaultVerbosityLevel, IsRequired = false)]
        public VerbosityLevel VerbosityLevel 
        {
            get
            {
                // ReSharper disable once RedundantAssignment
                VerbosityLevel verbosityLevel = DefaultVerbosityLevel;

                if (!Enum.TryParse(this["verbosityLevel"].ToString(), 
                        ignoreCase: true,
                        result: out verbosityLevel))

                    verbosityLevel = DefaultVerbosityLevel;

                return verbosityLevel;
            }
        }
    }
}
