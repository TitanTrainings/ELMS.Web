using ELMS.API.Models;
using ELMS.API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ELMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IJWTTokenService _jwtTokenService;
        private readonly IAuthService _authService;

        public LoginController(IConfiguration configuration,IJWTTokenService jWTTokenService, IAuthService authService)
        {
            _configuration = configuration;
            _jwtTokenService = jWTTokenService;
            _authService = authService;
        }
        [HttpPost]        
        public IActionResult Login(User user)
        {
            //sample object to hold db object of user record from database post successfull validation.
            User _user = new User();

            _user = _authService.AuthenticateUser(user.Username, user.Password);
            if(_user == null)
            {
                return Unauthorized();
            }

            // do the validation and prepare the required fields and create jwt service to get the jwt in string.
            // Creation and generation of token should be in JWTToken service.
            var token = _jwtTokenService.GenerateJwtToken(user.Username, user.Password, "manager");

            if(token == null)
            {
                return Unauthorized(new { message = "Invalid Credentials" });
            }

            return Ok(new { Token = token });
        }
    }
}
