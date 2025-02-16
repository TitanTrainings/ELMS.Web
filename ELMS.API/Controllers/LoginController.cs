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

        public LoginController(IConfiguration configuration,IJWTTokenService jWTTokenService)
        {
            _configuration = configuration;
            _jwtTokenService = jWTTokenService;
        }
        [HttpPost]        
        public IActionResult Login(User user)
        {
            //sample object to hold db object of user record from database post successfull validation.
            User _user = new User();

            


            // Replace this with proper user validation (e.g., database values)
            //if (username != _user.Username || password != _user.Password)
            //{
            //    return Unauthorized();
            //}

            // do the validation and prepare the required fields and create jwt service to get the jwt in string.
            // Creation and generation of token should be in JWTToken service.
            var token = _jwtTokenService.GenerateJwtToken(user.Username, user.Password, "manager");

            return Ok(new { Token = token });
        }
    }
}
