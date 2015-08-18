
namespace CloudCore.Admin.Models
{
    public class AccessPoolMember
    {
        public int UserId { get; set; }
        public int AccessPoolId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string  Login { get; set; }
    }
}