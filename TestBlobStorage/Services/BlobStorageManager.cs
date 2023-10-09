using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;
using TestBlobStorage.Utilities;

namespace TestBlobStorage.Services
{
    public class BlobStorageManager : IStorageManager
    {
        public readonly BlobStorageOptions _storageOptions;

        public BlobStorageManager(IOptions<BlobStorageOptions> options)
        {
            _storageOptions = options.Value;
        }

        public bool DeleteFile(string fileName)
        {
            var serviceClient = new BlobServiceClient(_storageOptions.ConnectionString);
            var contaionerClient = serviceClient.GetBlobContainerClient(_storageOptions.ContainerName);
            var blobClient = contaionerClient.GetBlobClient(fileName);
            
            try
            {
                blobClient.Delete();

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteFileAsync(string fileName)
        {
            var serviceClient = new BlobServiceClient(_storageOptions.ConnectionString);
            var contaionerClient = serviceClient.GetBlobContainerClient(_storageOptions.ContainerName);
            var blobClient = contaionerClient.GetBlobClient(fileName);

            try
            {
                await blobClient.DeleteAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public string GetSignedUrl(string fileName)
        {
            var serviceClient = new BlobServiceClient(_storageOptions.ConnectionString);
            var contaionerClient = serviceClient.GetBlobContainerClient(_storageOptions.ContainerName);
            var blobClient = contaionerClient.GetBlobClient(fileName);

            var signedUrl = blobClient.GenerateSasUri(BlobSasPermissions.Read, DateTime.Now.AddHours(2)).AbsoluteUri;

            return signedUrl;
        }

        public async Task<string> GetSignedUrlAsync(string fileName)
        {
            var serviceClient = new BlobServiceClient(_storageOptions.ConnectionString);
            var contaionerClient = serviceClient.GetBlobContainerClient(_storageOptions.ContainerName);
            var blobClient = contaionerClient.GetBlobClient(fileName);

            var signedUrl = blobClient.GenerateSasUri(BlobSasPermissions.Read, DateTime.Now.AddHours(2)).AbsoluteUri;

            return await Task.FromResult(signedUrl);
        }

        public bool UploadFile(IFormFile formFile)
        {
            BlobContainerClient container = new BlobContainerClient(_storageOptions.ConnectionString, _storageOptions.ContainerName);
            try
            {
                BlobClient client = container.GetBlobClient(formFile.FileName);

                using (Stream? data = formFile.OpenReadStream())
                {
                    client.Upload(data);
                }

            }
            catch (RequestFailedException)
            {
                return false;
            }

            return true;
        }


        public async Task<bool> UploadFileAsync(IFormFile formFile)
        {


            BlobContainerClient container = new BlobContainerClient(_storageOptions.ConnectionString, _storageOptions.ContainerName);
            try
            {
                BlobClient client = container.GetBlobClient(formFile.FileName);

                await using (Stream? data = formFile.OpenReadStream())
                {
                    await client.UploadAsync(data);
                }

            }
            catch (RequestFailedException)
            {
                return false;
            }

            return true;
        }
    }
}
