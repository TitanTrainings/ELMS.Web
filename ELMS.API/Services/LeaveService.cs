using ELMS.API.Models;
using ELMS.API.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ELMS.API.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _repository;
        private readonly ILogger<LeaveService> _logger;

        public LeaveService(ILeaveRepository repository, ILogger<LeaveService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public List<LeaveRequest> GetLeaveRequests(string? user)
        {
            List<LeaveRequest> leaveRequests = new List<LeaveRequest>();
            try
            {
                if (user == null)
                {
                    return null;
                }

                leaveRequests = _repository.GetLeaveRequests(user);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveService- GetLeaveRequests");
            }

            return leaveRequests;
        }

        public LeaveRequest GetLeaveRequestById(int id)
        {
            LeaveRequest leaveRequest = null;
            try
            {
                if (id == null)
                {
                    return null;
                }
                leaveRequest = _repository.GetLeaveRequestById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveService - GetLeaveRequestById");
            }
            return leaveRequest;
        }

        public string CreateLeaveRequest(LeaveRequest leaveRequest, string? user)
        {
            string response = string.Empty;
            try
            {
                if (leaveRequest == null)
                {
                    return null;
                }
                response = _repository.CreateLeaveRequest(leaveRequest, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveService- CreateLeaveRequest");
            }
            return response;
        }

        public LeaveRequest ApproveLeaveRequest(LeaveRequest leaveRequest)
        {
            LeaveRequest updatedleaveRequest = null;
            try
            {
                updatedleaveRequest = _repository.ApproveLeaveRequest(leaveRequest);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveService- ApproveLeaveRequest");
            }
            return updatedleaveRequest;
        }

        public LeaveRequest RejectLeaveRequest(LeaveRequest leaveRequest)
        {
            LeaveRequest updatedleaveRequest = null;
            try
            {
                updatedleaveRequest = _repository.RejectLeaveRequest(leaveRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveService- RejectLeaveRequest");
            }
            return updatedleaveRequest;
        }
    }
}
