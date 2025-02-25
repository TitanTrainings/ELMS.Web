using ELMS.API.Models;

namespace ELMS.API.Repository
{
    public interface ILeaveRepository
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
