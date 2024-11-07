using CalcApp.Server.Commands;
using CalcApp.Server.Requests;
using CalcApp.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalcApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(UserService userService) : ControllerBase
    {
        private readonly CalcDbContext _context;
        //post-запрос на регистрацию
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserRegisterRequest request)
        {
            try
            {
                userService.Register(request.Name, request.Login, request.Password);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //post-запрос на логин
        [HttpPost("login")]
        public IActionResult Login([FromBody]UserLoginRequest request)
        {
            try
            {
                var token = userService.Login(request.Login, request.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
