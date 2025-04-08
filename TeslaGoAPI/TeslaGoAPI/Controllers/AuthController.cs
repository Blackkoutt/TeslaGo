using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TeslaGoAPI.Extensions;
using TeslaGoAPI.Logic.Identity.Dto.RequestDto;
using TeslaGoAPI.Logic.Identity.Services.Interfaces;

namespace TeslaGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequestDto userRegisterRequestDto)
        {
            var result = await _authService.RegisterUser(userRegisterRequestDto);
            return result.IsSuccessful ? Ok(result.Value) : result.Error.Handle(this);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginRequestDto)
        {
            var result = await _authService.Login(loginRequestDto);
            return result.IsSuccessful ? Ok(result.Value) : result.Error.Handle(this);
        }

        [HttpGet("info")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Info()
        {
            var result = await _authService.GetCurrentUser();
            return result.IsSuccessful ? Ok(result.Value) : result.Error.Handle(this);
        }

        [HttpGet("validate")]
        [Authorize]
        public IActionResult ValidateUser()
        {
            var userClaims = User.Claims.ToList();

            return Ok(new
            {
                id = userClaims.FirstOrDefault(c => c.Type == "id")?.Value,
                name = userClaims.FirstOrDefault(c => c.Type == "name")?.Value,
                surname = userClaims.FirstOrDefault(c => c.Type == "surname")?.Value,
                emailAddress = userClaims.FirstOrDefault(c => c.Type == "emailAddress")?.Value,
                userRoles = userClaims.Where(c => c.Type == "userRoles").Select(c => c.Value).ToList()
            });
        }
    }
}
