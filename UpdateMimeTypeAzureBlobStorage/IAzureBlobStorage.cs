using Microsoft.WindowsAzure.Storage.Blob;

namespace UpdateMimeTypeAzureBlobStorage
{
    public interface IAzureBlobStorage
    {
        CloudBlobContainer GetContainer(string name);
    }
}