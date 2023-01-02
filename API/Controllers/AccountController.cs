using API.DTO;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

       public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            //var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            /*var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);*/
            var user = await _userManager.FindByEMailFromClaimPrincipal(User);

            return new UserDto
            {
                EmailAddress = user.Email,
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDTO>> GetUserAddress()
        {
            /*var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return user.Address;*/
            var user = await _userManager.FindUserByClaimsPrincipalWithAddressAsync(User);
            return _mapper.Map<Address, AddressDTO>(user.Address);

        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.EmailAddress);
            //var userName = _userManager.FindByNameAsync(loginDto.DisplayName);
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
                Token = _tokenService.CreateToken(user)
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {
            if (CheckEmailExistsAsync(model.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Email address is in use" } });
            }

            var user = new AppUser
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
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
                EmailAddress = model.Email,
                Token = _tokenService.CreateToken(user)
            };
        }
        [HttpPut("update-address")]
        public async Task<ActionResult<AddressDTO>> UpdateUserAddress(AddressDTO address)
        {
            var user = await _userManager.FindUserByClaimsPrincipalWithAddressAsync(User);
            user.Address = _mapper.Map<AddressDTO, Address>(address);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return Ok(_mapper.Map<Address, AddressDTO>(user.Address));
            return BadRequest("There was an issue updating the user address, please try again");
        }
    }
}
