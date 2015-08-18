using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CloudCore.Api.Models
{
    [DataContract]
    public class ApplicationAuthorization
    {
        [Required]
        [DataMember(IsRequired=true)]
        public string ApplicationKey { get; set; }
    }
}
