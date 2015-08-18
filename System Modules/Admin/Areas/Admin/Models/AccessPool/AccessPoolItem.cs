namespace CloudCore.Admin.Models
{
    public class AccessPoolModel
    {
        public int AccessPoolId { get; set; }
        public string AccessPoolName { get; set; }
        public int ManagerUserId { get; set; }
        public string ManagerName { get; set; }
    }
}