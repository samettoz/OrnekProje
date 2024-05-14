using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Request;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginRequestModel model)
        {
            return Ok(_authService.Login(model));
        }

        [HttpPost("Register")]
        public IActionResult Register(UserRegisterRequestModel model)
        {
            return Ok(_authService.Register(model));
        }
    }
}
