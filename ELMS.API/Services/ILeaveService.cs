using ELMS.API.Models;

namespace ELMS.API.Services
{
    public interface ILeaveService
    {
        public List<LeaveRequest> GetLeaveRequests(string? user);
        public LeaveRequest GetLeaveRequestById(int id);
        public string CreateLeaveRequest(LeaveRequest leaveRequest, string? user);
        public LeaveRequest ApproveLeaveRequest(LeaveRequest leaveRequest);
        public LeaveRequest RejectLeaveRequest(LeaveRequest leaveRequest);
    }
}
