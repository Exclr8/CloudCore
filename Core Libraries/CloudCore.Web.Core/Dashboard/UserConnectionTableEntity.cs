using Microsoft.WindowsAzure.Storage.Table;

namespace CloudCore.Core.Dashboard
{
    public class UserConnectionTableEntity : TableEntity
    {
        public int UserId { get; set; }

        public string ConnectionId { get; set; }
    }
}