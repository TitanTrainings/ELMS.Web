namespace ELMS.API.DTO
{
    public class LeaveRequestDTO
    {
        public int LeaveRequestId { get; set; }
        
        public int UserId { get; set; }

        public string LeaveType { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; } = DateTime.MinValue;

        public string Status { get; set; } = string.Empty;

        public string ManagerComments { get; set; } = string.Empty;
    }
}
