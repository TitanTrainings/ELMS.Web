using AutoMapper;
using Azure;
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
    public class LeaveController : Controller
    {

        private readonly ILeaveService _service;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public LeaveController(ILeaveService service, IMapper mapper,IUserService userService)
        {
            _service = service;
            _mapper = mapper;
            _userService = userService;            
        }


        // GET: LeaveController
        [HttpGet("GetLeaveRequests/{userId}")]
        public ActionResult<List<LeaveRequestDTO>> GetLeaveRequests(int userId)
        {
            List<LeaveRequest>? leaveRequests = new List<LeaveRequest>();
            List<LeaveRequestDTO>? leaveRequestsDTO = null;
            try
            {
                var currentUser = _userService.UserByUserId(userId);                

                leaveRequests = _service.GetLeaveRequests(currentUser.Username);
            }
            catch (Exception ex)
            {
                
            }

            leaveRequestsDTO = leaveRequests != null ? _mapper.Map<List<LeaveRequestDTO>>(leaveRequests): null;
            return Ok(new { Response = leaveRequestsDTO });
        }

        // GET: LeaveController/Details/5
        [HttpGet("GetLeaveRequestById/{id}")]
        public IActionResult GetLeaveRequestById(int id)
        {
            LeaveRequest leaveRequest = null;
            LeaveRequestDTO leaveRequestDTO = null;
            try
            {
                if (id == null)
                {
                    return null;
                }
                leaveRequest = _service.GetLeaveRequestById(id);
            }
            catch(Exception ex)
            {
                leaveRequestDTO = null;
                _logger.LogError(ex, "Error Occured at LeaveRepository");
            }
            // Use AutoMapper to map the LeaveRequest entity to LeaveRequestDTO
            leaveRequestDTO = leaveRequest != null ? _mapper.Map<LeaveRequestDTO>(leaveRequest): null;
            return Ok(new { Response = leaveRequestDTO });
        }

        // POST: LeaveController/Create
        [HttpPost("CreateLeaveRequest")]
        public IActionResult CreateLeaveRequest(LeaveRequest leaveRequest)
        {
            string _response = string.Empty;
            try
            {
                if(leaveRequest == null)
                {
                    return null;
                }
                //string? user = HttpContext.User.FindFirstValue("username");                
                var user = _userService.UserByUserId(leaveRequest.UserId);

                leaveRequest.Status = "Pending";
                //user = "anand";
                _response = _service.CreateLeaveRequest(leaveRequest, user.Username);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveController - CreateLeaveRequest");
                return BadRequest(new { Response = "error" });
            }
            return Ok(new { Response = _response });
        }

        [HttpPut("approve/{id}")]
        public IActionResult ApproveLeaveRequest(int id)
        {
            LeaveRequest updatedleaveRequest = null;
            LeaveRequestDTO updatedLeaveRequestDTO = null;
            try
            {
                if(id == null)
                {
                    return NotFound();
                }
                updatedleaveRequest = _service.ApproveLeaveRequest(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveController - ApproveLeaveRequest");
            }
            updatedLeaveRequestDTO = updatedleaveRequest != null ? _mapper.Map<LeaveRequestDTO>(updatedleaveRequest) : null;
            return Ok(new { Response = updatedLeaveRequestDTO });
        }

        [HttpPut("reject/{id}")]
        public IActionResult RejectLeaveRequest(int id)
        {
            LeaveRequest updatedleaveRequest = null;
            LeaveRequestDTO updatedLeaveRequestDTO = null;
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                updatedleaveRequest = _service.RejectLeaveRequest(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveController - RejectLeaveRequest");
            }
            updatedLeaveRequestDTO = updatedleaveRequest != null ? _mapper.Map<LeaveRequestDTO>(updatedleaveRequest) : null;
            return Ok(new { Response = updatedLeaveRequestDTO });
        }

        [HttpGet("getPendingLeaves")]
        public ActionResult GetPendingLeaves()
        {
            List<LeaveRequest> leaveRequest = new List<LeaveRequest>();
            try
            {
                leaveRequest = _service.GetPendingLeaves();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveController - RejectLeaveRequest");
            }
            
            return Ok(new { Response = leaveRequest });
        }

        [HttpPut("addManagerComment")]
        public IActionResult AddManagerComment(LeaveRequest leaveRequest)
        {
            LeaveRequest _leaveRequest = new LeaveRequest();
            try
            {
                _leaveRequest = _service.AddComment(leaveRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveController - RejectLeaveRequest");
            }

            return Ok(new { Response = leaveRequest });
        }
    }
}
