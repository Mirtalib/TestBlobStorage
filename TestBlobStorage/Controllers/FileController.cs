using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestBlobStorage.Services;

namespace TestBlobStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IStorageManager _storageManager;

        public FileController(IStorageManager storageManager)
        {
            _storageManager = storageManager;
        }

        [HttpGet("getUrl")]
        public IActionResult GetUrl(string fileName)
        {
            try
            {
                var result = _storageManager.GetSignedUrl(fileName);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }

        [HttpGet("getUrlAsync")]
        public IActionResult GetUrlAsync(string fileName)
        {
            try
            {
                var result = _storageManager.GetSignedUrlAsync(fileName);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }

        [HttpDelete("deleteFile")]
        public IActionResult Delete(string fileName)
        {
            try
            {
                var result = _storageManager.DeleteFile(fileName);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }

        [HttpDelete("deleteFileAsync")]
        public async Task<IActionResult> DeleteAsync(string fileName)
        {

            try
            {
                var result = await _storageManager.DeleteFileAsync(fileName);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }


        [HttpPost("uploadFile")]
        public IActionResult UploadFile(IFormFile formFile)
        {
            try
            {
                var result = _storageManager.UploadFile(formFile);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }

        [HttpPost("uploadFileAsync")]
        public async Task<IActionResult> UploadFileAsync(IFormFile formFile)
        {
            try
            {
                var result = await _storageManager.UploadFileAsync(formFile);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
        }

    }
}
