using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CloudCore.Api.Models
{
    [DataContract]
    public class ResetPassword
    {
        [Required]
        [DataMember(IsRequired = true)]
        public string LoginOrEmail { get; set; }
    }
}
