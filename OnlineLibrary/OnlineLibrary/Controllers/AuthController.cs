using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Business.Models.Users;
using OnlineLibrary.Business.Services;
using OnlineLibrary.Business.Services.Interfaces;
using System.Threading.Tasks;

namespace OnlineLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var token = await _authService.Authenticate(model);

            if (token == null)
            {
                return BadRequest("Invalid email or password");
            }

            return Ok(token);
        }
    }
}
