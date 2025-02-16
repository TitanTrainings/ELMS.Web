using AutoMapper;
using ELMS.API.DTO;
using ELMS.API.Models;
using ELMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ELMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class LeaveController : Controller
    {

        private readonly ILeaveService _leaveService;
        private readonly IMapper _mapper;

        public LeaveController(ILeaveService leaveService, IMapper mapper)
        {
            _leaveService = leaveService;
            _mapper = mapper;
        }


        // GET: LeaveController
        [HttpGet]
        public ActionResult<List<LeaveRequestDTO>> GetLeaveRequest()
        {
            return null;
        }

        // GET: LeaveController/Details/5
        [HttpGet("{id}")]
        public ActionResult<LeaveRequestDTO> GetLeaveRequestById(int id)
        {
            //var user = await _userService.GetUserById(id);

            //if (user == null)
            //{
            //    return NotFound();
            //}

            // Use AutoMapper to map the User entity to UserDTO
            //var userDto = _mapper.Map<UserDTO>(user);

            return null;
        }

        // POST: LeaveController/Create
        [HttpPost]
        public ActionResult<LeaveRequestDTO> CreateLeaveRequest(LeaveRequest leaveRequest)
        {
            
            return null;
        }

        // GET: LeaveController/Edit/5
        [HttpPut("{id}")]
        public ActionResult UpdateLeaveRequest([FromRoute] int id, [FromBody] LeaveRequest product)
        {
            return null;
        }


        // GET: LeaveController/Delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return null;
        }       
    }
}
