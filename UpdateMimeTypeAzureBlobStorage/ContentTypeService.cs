using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace UpdateMimeTypeAzureBlobStorage
{
    public class ContentTypeService : IContentTypeService
    {
        public ContentTypeService() { }

        public async void Update(IAzureBlobStorage blobStorage, string containerName, string fileExt, string contentType)
        {
            var container = blobStorage.GetContainer(containerName);
            var items = await GetBlobs(container);

            foreach (IListBlobItem item in items)
            {
                string ext = Path.GetExtension(item.Uri.AbsoluteUri);
                if (ext == fileExt)
                {
                    var blob = item as CloudBlockBlob;
                    if (blob != null)
                    {
                        blob.Properties.ContentType = contentType;
                        await blob.SetPropertiesAsync();
                    }
                }
            }
        }

        private async Task<List<IListBlobItem>> GetBlobs(CloudBlobContainer container)
        {
            BlobContinuationToken token = null;
            List<IListBlobItem> items = new List<IListBlobItem>();
            do
            {
                var result = await container.ListBlobsSegmentedAsync(token);
                token = result.ContinuationToken;
                items.AddRange(result.Results);
            } while (token != null);

            return items;
        }
    }
}