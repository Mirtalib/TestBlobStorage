using TestBlobStorage.Entitiy;
using TestBlobStorage.Services.Dto;

namespace TestBlobStorage.Services
{
    public interface IUserService
    {
        Task<User> GetUser(Guid userId);
        Task<string> UploadProfilePicture(UpdateProfilePhotoDto request);
        Task<bool> UpdateUser(UpdateUserDto request);
        Task<bool> Register(RegisterUserDto request);
        Task<string> Login(AuthUserDto request);
    }
}
