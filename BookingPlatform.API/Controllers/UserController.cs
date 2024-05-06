using BookingPlatform.Application.Interfaces;
using BookingPlatform.Core.Request;
using Microsoft.AspNetCore.Mvc;

namespace BookingPlatform.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]CreateUserRequest request)
        {
            await _userService.Register(request.UserName, request.Email, request.Password);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }

            var token = await _userService.Login(email, password);

            HttpContext.Response.Cookies.Append("test-cookies", token);

            return Ok();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("test-cookies");

            return Ok();
        }
    }
}
