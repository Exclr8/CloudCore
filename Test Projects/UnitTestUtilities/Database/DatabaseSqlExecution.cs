using System.Data.SqlClient;
using CloudCore.Configuration.ConfigFile;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Frameworkone.UnitTestUtilities.Database
{
    public class DatabaseSqlExecution
    {
        public static void ExecuteSqlScript(string scriptContent)
        {
            var sqlConnectionString = ReadConfig.ConnectionString;
            using (var dbConnection = new SqlConnection(sqlConnectionString))
            {
                var server = new Server(new ServerConnection(dbConnection));
                server.ConnectionContext.ExecuteNonQuery(scriptContent);
            }
        }
    }
}
