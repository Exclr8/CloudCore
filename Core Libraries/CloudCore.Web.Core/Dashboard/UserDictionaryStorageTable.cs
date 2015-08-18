using System.Globalization;
using System.Linq;
using CloudCore.Logging.AzureTableStorage;
using Microsoft.WindowsAzure.Storage.Table;

namespace CloudCore.Core.Dashboard
{
    public class UserDictionaryStorageTable : CloudCoreStoredTable<UserConnectionTableEntity>
    {
        public static void Update(UserConnectionTableEntity userConnection)
        {
            var instance = new UserDictionaryStorageTable();

            var tableQuery = instance.Table.CreateQuery<UserConnectionTableEntity>();
            var users = tableQuery.Where(x => x.UserId == userConnection.UserId).ToList();

            users.ForEach(user => instance.Delete(user));
            instance.Insert(userConnection);
        }

        public static string GetConnectionId(long userId)
        {
            var instance = new UserDictionaryStorageTable();

            var tableQuery = instance.Table.CreateQuery<UserConnectionTableEntity>();
            var users = tableQuery.Where(x => x.UserId == (int)userId).ToList();

            return users.Any()
                ? users.Single().ConnectionId
                : null;
        }
    }
}