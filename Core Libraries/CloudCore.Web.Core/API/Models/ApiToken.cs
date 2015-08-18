using System;
using System.Globalization;

namespace CloudCore.Api.Models
{
    public class ApiToken
    {
        public string TokenKey { get; set; }
        public string ExpiryUtc { get; set; }
        public string TokenKeyName { get; set; }
        public DateTime ExpiryLocal  {
            get {   
                return DateTime.ParseExact(ExpiryUtc, "o", CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
        }
    }
}
