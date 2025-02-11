using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELMS.API.Models
{
    public class LeaveRequest
    {
        [Key]
        public int LeaveRequestId {  get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId {  get; set; }
        public string LeaveType {  get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        public string Status { get; set; } = string.Empty;
        public string ManagerComments { get; set; } = string.Empty;
    }
}
