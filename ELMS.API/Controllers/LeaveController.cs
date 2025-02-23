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
    [Authorize]
    public class LeaveController : Controller
    {

        private readonly ILeaveService _service;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public LeaveController(ILeaveService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        // GET: LeaveController
        [HttpGet("GetLeaveRequests")]
        public ActionResult<List<LeaveRequestDTO>> GetLeaveRequests()
        {
            List<LeaveRequest>? leaveRequests = new List<LeaveRequest>();
            List<LeaveRequestDTO>? leaveRequestsDTO = null;
            try
            {
                var currentUser = HttpContext.User.FindFirstValue("username");
                //currentUser = "anand";
                leaveRequests = _service.GetLeaveRequests(currentUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveService");
            }

            leaveRequestsDTO = leaveRequests != null ? _mapper.Map<List<LeaveRequestDTO>>(leaveRequests): null;
            return leaveRequestsDTO;
        }

        // GET: LeaveController/Details/5
        [HttpGet("GetLeaveRequestById/{id}")]
        public ActionResult<LeaveRequestDTO> GetLeaveRequestById(int id)
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
            return leaveRequestDTO;
        }

        // POST: LeaveController/Create
        [HttpPost("CreateLeaveRequest")]
        public string CreateLeaveRequest(LeaveRequest leaveRequest)
        {
            string response = string.Empty;
            try
            {
                if(leaveRequest == null)
                {
                    return null;
                }
                string? user = HttpContext.User.FindFirstValue("username");
                leaveRequest.Status = "Pending";
                //user = "anand";
                response = _service.CreateLeaveRequest(leaveRequest, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveController - CreateLeaveRequest");
                return "Error Occurred";
            }
            return response;
        }

        [HttpPut("approve")]
        public ActionResult<LeaveRequestDTO> ApproveLeaveRequest(LeaveRequest leaveRequest)
        {
            LeaveRequest updatedleaveRequest = null;
            LeaveRequestDTO updatedLeaveRequestDTO = null;
            try
            {
                if(leaveRequest.LeaveRequestId == null)
                {
                    return NotFound();
                }
                updatedleaveRequest = _service.ApproveLeaveRequest(leaveRequest);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveController - ApproveLeaveRequest");
            }
            updatedLeaveRequestDTO = updatedleaveRequest != null ? _mapper.Map<LeaveRequestDTO>(updatedleaveRequest) : null;
            return updatedLeaveRequestDTO;
        }

        [HttpPut("reject")]
        public ActionResult<LeaveRequestDTO> RejectLeaveRequest(LeaveRequest leaveRequest)
        {
            LeaveRequest updatedleaveRequest = null;
            LeaveRequestDTO updatedLeaveRequestDTO = null;
            try
            {
                if (leaveRequest.LeaveRequestId == null)
                {
                    return NotFound();
                }
                updatedleaveRequest = _service.RejectLeaveRequest(leaveRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveController - RejectLeaveRequest");
            }
            updatedLeaveRequestDTO = updatedleaveRequest != null ? _mapper.Map<LeaveRequestDTO>(updatedleaveRequest) : null;
            return updatedLeaveRequestDTO;
        }
    }
}
