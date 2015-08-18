using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CloudCore.Api.Models
{
    [DataContract]
    public class UserAuthorization
    {
        [Required]
        [DataMember(IsRequired = true)]
        public string UserName { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public string Password { get; set; }
    }
}
