using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CloudCore.Configuration.ConfigFile;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CloudCore.Core.Storage
{
    public class BlobStorage
    {
        private CloudBlobClient blobClient;

        public BlobStorage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ReadConfig.CommonCloudCoreApplicationSettings.Storage.StorageConnectionString);
            blobClient = storageAccount.CreateCloudBlobClient();
            blobClient.DefaultRequestOptions.ServerTimeout = TimeSpan.FromMinutes(10);
         //   blobClient.ServerTimeout = TimeSpan.FromMinutes(10);
        }

        public void CreatePrivateContainer(string containerName)
        {
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();
        }

        public void CreatePublicContainer(string containerName)
        {
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        }

        public ICloudBlob UploadBlob(string containerName, string blobName, Stream data)
        {
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            ICloudBlob blob = container.GetBlockBlobReference(blobName);
            blob.UploadFromStream(data, null, new BlobRequestOptions { ServerTimeout = TimeSpan.FromMinutes(Math.Max(1, data.Length / (1024 * 1024))) }, null);
            return blob;
        }

        public void DeleteBlob(string containerName, string blobName)
        {
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            ICloudBlob blob = container.GetBlobReferenceFromServer(blobName);
            blob.Delete();
        }

        public List<IListBlobItem> GetBlobListing(string containerName)
        {
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            return (from listBlob in container.ListBlobs(null, true) select listBlob).ToList();
        }

        public MemoryStream DownloadBlob(string containerName, string blobName)
        {
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            ICloudBlob blob = container.GetBlobReferenceFromServer(blobName);
            var stream = new MemoryStream();
            blob.DownloadToStream(stream, null, new BlobRequestOptions { ServerTimeout = TimeSpan.FromMinutes(30) }, null);
            return stream;
        }
    }
}