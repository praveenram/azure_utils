namespace UpdateMimeTypeAzureBlobStorage
{
    public interface IContentTypeService
    {
        void Update(IAzureBlobStorage blobStorage, string containerName, string fileExt, string contentType);
    }
}