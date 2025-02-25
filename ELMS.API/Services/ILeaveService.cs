using ELMS.API.Models;

namespace ELMS.API.Services
{
    public interface ILeaveService
    {
        public List<LeaveRequest> GetLeaveRequests(string? user);
        public LeaveRequest GetLeaveRequestById(int id);
        public string CreateLeaveRequest(LeaveRequest leaveRequest, string? user);
        public LeaveRequest ApproveLeaveRequest(int id);
        public LeaveRequest RejectLeaveRequest(int id);
        public LeaveRequest AddComment(LeaveRequest leaveRequest);
        public List<LeaveRequest> GetPendingLeaves();
    }
}
