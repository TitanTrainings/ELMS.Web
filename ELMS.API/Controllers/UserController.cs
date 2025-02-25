using AutoMapper;
using ELMS.API.DTO;
using ELMS.API.Models;
using ELMS.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ELMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        // GET: LeaveController
        [HttpGet("leave-balance/{userId}")]
        public ActionResult<UserLeaveBalanceDTO> GetLeaveBalance(int userId)
        {
            UserLeaveBalanceDTO userLeaveBalanceDTO = new UserLeaveBalanceDTO();
            try
            {
                string user = HttpContext.User.FindFirstValue("username");
                //user = "anand";
                if(user != null) 
                {
                    userLeaveBalanceDTO = _userService.GetLeaveBalance(user);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at UserController- GetLeaveBalance");
            }
            return userLeaveBalanceDTO;
        }

        [HttpGet("getUserByUserId/{userId}")]
        public IActionResult GetUserByUserId(int userId) 
        {
            var user = _userService.UserByUserId(userId);

            return Ok(new { Response = user });

        }
    }
}
