namespace TestBlobStorage.Services.Dto
{
    public class UpdateProfilePhotoDto
    {
        public Guid UserId { get; set; }
        public IFormFile Image { get; set; }
    }
}
