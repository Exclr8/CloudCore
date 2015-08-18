using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CloudCore.Api.Models
{
    [DataContract]
    public class PasswordChange
    {
        [Required]
        [DataMember(IsRequired = true)]
        public string OldPassword { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public string NewPassword { get; set; }
    }
}
