
namespace CloudCore.Api.Models
{
    public class UserDetails
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string CellNo { get; set; }

        public string LastPasswordChangeUTC { get; set; }
    }
}
