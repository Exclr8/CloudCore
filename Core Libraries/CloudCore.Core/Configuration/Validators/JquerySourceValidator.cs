using System;
using System.Configuration;

namespace CloudCore.Configuration.ConfigFile.Validators
{
    public sealed class JquerySourceValidatorBase : ConfigurationValidatorBase
    {
        public override bool CanValidate(Type type)
        {
            return type == typeof(string);
        }

        public override void Validate(object value)
        {
            var stringValue = ((string)value).ToLower();

            if (stringValue != "cdn" && stringValue != "internal")
            {
                throw new ConfigurationErrorsException(string.Format("Invalid value \"{0}\" was specified in the configuration file for setting \"jQuerySource\" under cloudCore > internalUi. The only allowed values are \"CDN\" and \"internal\".", stringValue));
            }
        }
    }

    public sealed class JquerySourceValidatorAttribute : ConfigurationValidatorAttribute
    {
        public override ConfigurationValidatorBase ValidatorInstance
        {
            get
            {
                return new JquerySourceValidatorBase();
            }
        }
    }
}
