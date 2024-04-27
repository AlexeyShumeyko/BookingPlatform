using BookingPlatform.Application.Interfaces;
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
        public async Task<IActionResult> Register(string userName, string Email, string password)
        {
            await _userService.Register(userName, Email, password);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string emeil, string password)
        {
            var token = await _userService.Login(emeil, password);

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
