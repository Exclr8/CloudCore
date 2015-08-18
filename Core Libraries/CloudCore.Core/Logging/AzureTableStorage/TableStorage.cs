using System.Collections.Generic;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Azure;

namespace CloudCore.Logging.AzureTableStorage
{

    public abstract class CloudCoreStoredTable
    {
        private CloudStorageAccount cloudStorageAccount;
        private readonly CloudTableClient cloudTableClient;
        private readonly CloudTable cloudTable;
        
        protected CloudCoreStoredTable(string accountSonnectionString = "")
        {
            SetAccount(accountSonnectionString);
            cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            cloudTable = cloudTableClient.GetTableReference(GetType().Name.Replace("Entity", "").Replace("Table", "").ToLower());
            cloudTable.CreateIfNotExists();
        }

        private void SetAccount(string accountSonnectionString)
        {
            if (string.IsNullOrWhiteSpace(accountSonnectionString) && RoleEnvironment.IsAvailable)
                accountSonnectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");

            if (string.IsNullOrWhiteSpace(accountSonnectionString) || accountSonnectionString.Contains("UseDevelopmentStorage=true"))
                cloudStorageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            else
                cloudStorageAccount = CloudStorageAccount.Parse(accountSonnectionString);
        }
        
        public CloudTable Table
        {
            get { return cloudTable; }
        }

        public CloudTableClient TableClient
        {
            get { return cloudTableClient; }
        }

        public CloudStorageAccount StorageAccount
        {
            get { return cloudStorageAccount; }
        }
    }


    public abstract class CloudCoreStoredTable<T> : CloudCoreStoredTable where T : TableEntity
    {
        public void Insert(T entityItem)
        {
            TableOperation insertOperation = TableOperation.Insert(entityItem);
            Table.Execute(insertOperation);
        }

        public void InsertBatch(List<T> listOfItems)
        {
            TableBatchOperation batchOperation = new TableBatchOperation();
            foreach (var item in listOfItems)
            {
                batchOperation.Insert(item);
            }
            Table.ExecuteBatch(batchOperation);
        }

        public void InsertOrReplace(T entityItem)
        {
            var insertOrReplaceOperation = TableOperation.InsertOrReplace(entityItem);
            Table.Execute(insertOrReplaceOperation);
        }

        public void Delete(T entityItem)
        {
            TableOperation deleteOperation = TableOperation.Delete(entityItem);
            Table.Execute(deleteOperation);
        }
    }
}
