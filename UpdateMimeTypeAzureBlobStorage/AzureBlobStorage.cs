using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace UpdateMimeTypeAzureBlobStorage
{
    public class AzureBlobStorage : IAzureBlobStorage
    {
        private CloudStorageAccount _account;
        private CloudBlobClient _client;

        public AzureBlobStorage(string connString)
        {
            _account = CloudStorageAccount.Parse(connString);
            _client = _account.CreateCloudBlobClient();
        }

        public AzureBlobStorage(CloudStorageAccount account)
        {
            _account = account;
            _client = _account.CreateCloudBlobClient();
        }

        public CloudBlobContainer GetContainer(string name)
        {
            return _client.GetContainerReference(name);
        }
    }
}