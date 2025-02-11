using AutoMapper;
using ELMS.API.DTO;
using ELMS.API.Models;
using ELMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ELMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        // GET: LeaveController
        [HttpGet]
        public ActionResult<List<UserDTO>> GetUsers()
        {
            return null;
        }

        // GET: LeaveController/Details/5
        [HttpGet("{id}")]
        public ActionResult<LeaveRequestDTO> GetUserById(int id)
        {
            return null;
        }

        // POST: LeaveController/Create
        [HttpPost]
        public ActionResult<LeaveRequestDTO> CreateUser(LeaveRequest leaveRequest)
        {
            return null;
        }

        // GET: LeaveController/Edit/5
        [HttpPut("{id}")]
        public ActionResult UpdateUser([FromRoute] int id, [FromBody] LeaveRequest product)
        {
            return null;
        }


        // GET: LeaveController/Delete/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            return null;
        }
    }
}
