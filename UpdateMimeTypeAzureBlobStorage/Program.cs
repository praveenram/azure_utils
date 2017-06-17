using System;

namespace UpdateMimeTypeAzureBlobStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = "<<Your connection string>>";

            var storage = new AzureBlobStorage(connString);
            var service = new ContentTypeService();
            service.Update(storage, "test", ".jpg", "image/jpg");

            Console.ReadKey();
        }
    }
}