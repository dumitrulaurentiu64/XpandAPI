using Microsoft.AspNetCore.Mvc;
using XPandAuthentication.Dtos;
using XPandAuthentication.Model;
using XPandAuthentication.Repositories;
using XPandAuthentication.Services;

namespace XPandAuthentication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private const string JWT = "jwt";
        private readonly IAuthRepository _authRepository;
        private JwtService _jwtService;

        public AuthController(IAuthRepository authRepository, JwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            User user = _authRepository.Login(dto);

            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(dto.UserPassword, user.UserPassword))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = _jwtService.Generate(user.UserID);

            Response.Cookies.Append(JWT, jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "success"
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies[JWT];
                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                User? user = _authRepository.GetUser(userId);
                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(JWT);

            return Ok(new
            {
                message = "success"
            });
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            try
            {
                _authRepository.Register(registerDto);

                return Ok(new
                {
                    message = "success"
                });
            }
            catch (Exception)
            { 
                return ValidationProblem();
            }
        }
    }
}
