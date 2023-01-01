using API.DTO;
using API.Errors;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.EmailAddress);
            if (user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse(401));
            }
            return new UserDto
            {
                EmailAddress = user.Email,
                DisplayName = user.DisplayName,
                Token = "This is a token"
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {
            var user = new AppUser
            {
                DisplayName = model.DisplayName,
                Email = model.Emaill,
                UserName = model.DisplayName
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }
            return new UserDto
            {
                DisplayName = model.DisplayName,
                EmailAddress = model.Emaill,
                Token = model.Emaill
            };
        }

    }
}
