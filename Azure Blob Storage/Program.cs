using Azure.Storage.Blobs.Models;

namespace Azure_Blob_Storage
{
    internal class Program
    {
        public const string Downloads = "Downloads";
        public const string Uploads = "Uploads";
        static async Task Main(string[] args)
        {
            var client = new FilesClient("Activity04");
            var filename1 = "Test1.txt";
            await client.DeleteFile(filename1);
            var fullpath1 = Path.Combine(Uploads, filename1);
            Console.Write(File.Exists(fullpath1));
            await client.UploadFile(fullpath1);
            await client.DownloadFile(filename1, Downloads);

            var filename2 = "Morning.jpg";
            var container = "Activity04B";
            var fullpath2 = Path.Combine(Uploads, filename2);
            await client.DeleteFile(filename2, container);
            await client.UploadFile(fullpath2, container);
            await client.DownloadFile(filename2, container, Downloads);
        }
    }
    
}