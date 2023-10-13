using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBlobStorage.Services.Dto;
using TestBlobStorage.Services;

namespace TestBlobStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserDto request)
        {
            try
            {
                return Ok(await _userService.Register(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(AuthUserDto request)
        {
            try
            {
                return Ok(await _userService.Login(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getUser")]
        public async Task<ActionResult> GetUser(Guid userId)
        {
            try
            {
                return Ok(await _userService.GetUser(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("uploadPhoto")]
        public async Task<ActionResult> UploadImage([FromForm] UpdateProfilePhotoDto request)
        {
            try
            {
                return Ok($"{await _userService.UploadProfilePicture(request)}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateUser")]
        public async Task<ActionResult> UpdateUser(UpdateUserDto request)
        {
            try
            {
                return Ok(await _userService.UpdateUser(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

