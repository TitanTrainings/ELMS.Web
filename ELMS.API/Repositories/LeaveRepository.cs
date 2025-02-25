using ELMS.API.Data;
using ELMS.API.DTO;
using ELMS.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ELMS.API.Repository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<LeaveRepository> _logger;

        public LeaveRepository(AppDbContext context, ILogger<LeaveRepository> logger)
        {
            _context = context;
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
                var currentUser = _context.Users.Where(x => x.Username == user).FirstOrDefault();
                if (currentUser != null)
                {
                    if (currentUser.Role.ToLower().Equals("manager"))
                    {
                        leaveRequests = _context.LeaveRequests.ToList();
                    }
                    else
                    {
                        leaveRequests = _context.LeaveRequests.Where(lr => lr.UserId == currentUser.UserId).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                leaveRequests = null;
                _logger.LogError(ex, "Error Occured at LeaveRepository- GetLeaveRequests");
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
                leaveRequest = _context.LeaveRequests.Where(x => x.LeaveRequestId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                leaveRequest = null;
                _logger.LogError(ex, "Error Occured at LeaveRepository - GetLeaveRequestById");
            }
            return leaveRequest;
        }

        public string CreateLeaveRequest(LeaveRequest leaveRequest, string? user)
        {
            try
            {
                if (leaveRequest == null)
                {
                    return "Invalid Request could not be processed";
                }
                var userDetail = _context.Users.FirstOrDefault(x => x.Username == user);
                if (userDetail != null)
                {
                    int availableLeaveBalance = 0;
                    if (leaveRequest.LeaveType == "Vacation")
                    {
                        availableLeaveBalance = userDetail.VacationLeaveBalance;
                    }
                    else if (leaveRequest.LeaveType == "Sick")
                    {
                        availableLeaveBalance = userDetail.SickLeaveBalance;
                    }
                    if (availableLeaveBalance >= (leaveRequest.EndDate - leaveRequest.StartDate).Days)
                    {
                        leaveRequest.UserId = userDetail.UserId;
                        _context.LeaveRequests.Add(leaveRequest);
                        _context.SaveChanges();
                    }
                    else
                    {
                        return "You don't have adequate available leaves to submit this request.";
                    }
                    return "Request submitted successfully!";
                }
                else
                {
                    return "User doesn't exist.";
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveRepository - CreateLeaveRequest");
                return "Error Occurred";
            }

        }

        public LeaveRequest ApproveLeaveRequest(int id)
        {
            var leaveRequest = _context.LeaveRequests.Find(id);
            try
            {
                if (leaveRequest != null)
                {
                    leaveRequest.Status = "Approved";
                }
                _context.LeaveRequests.Update(leaveRequest);
                _context.SaveChanges();

                if (leaveRequest.Status == "Approved")
                {
                    UserLeave userLeave = new UserLeave();
                    userLeave.UserId = leaveRequest.UserId;
                    userLeave.LeaveType = leaveRequest.LeaveType;
                    userLeave.LeaveCount = (leaveRequest.EndDate - leaveRequest.StartDate).Days;

                    _context.Add(userLeave);
                    _context.SaveChanges();

                    User updateUser = _context.Users.FirstOrDefault(x => x.UserId == leaveRequest.UserId);
                    if (leaveRequest.LeaveType == "Vacation")
                    {
                        updateUser.VacationLeaveBalance = updateUser.VacationLeaveBalance - userLeave.LeaveCount;
                    }
                    else if (leaveRequest.LeaveType == "Sick")
                    {
                        updateUser.SickLeaveBalance = updateUser.SickLeaveBalance - userLeave.LeaveCount;
                    }
                    _context.Users.Update(updateUser);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveRepository - ApproveLeaveRequest");
            }

            return leaveRequest;
        }

        public LeaveRequest RejectLeaveRequest(int id)
        {
            var leaveRequest = _context.LeaveRequests.Find(id);
            try
            {
                if (leaveRequest != null)
                {
                    leaveRequest.Status = "Rejected";
                    _context.LeaveRequests.Update(leaveRequest);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveRepository - RejectLeaveRequest");
            }
            return leaveRequest;
        }

        public List<LeaveRequest> GetPendingLeaves()
        {
            List<LeaveRequest> leaveRequest = new List<LeaveRequest>();
            try
            {
                leaveRequest = _context.LeaveRequests.Where(x => x.Status.ToLower() == "pending").ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured at LeaveRepository - RejectLeaveRequest");
            }
            return leaveRequest;
        }

        public LeaveRequest AddComment(LeaveRequest leaveRequest)
        {
            var _leaveRequest = _context.LeaveRequests.Find(leaveRequest.LeaveRequestId);

            _leaveRequest.ManagerComments = leaveRequest.ManagerComments;

            _context.Update(_leaveRequest);
            _context.SaveChanges(); 

            return leaveRequest;
        }
    }
}
