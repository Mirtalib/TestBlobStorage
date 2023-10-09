namespace TestBlobStorage.Services
{
    public interface IStorageManager
    {
        string GetSignedUrl(string fileName);
        Task<string> GetSignedUrlAsync(string fileName);
        bool UploadFile(IFormFile formFile);
        Task<bool> UploadFileAsync(IFormFile formFile);
        bool DeleteFile(string fileName);
        Task<bool> DeleteFileAsync(string fileName);
    }
}
