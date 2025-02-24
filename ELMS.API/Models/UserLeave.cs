using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELMS.API.Models
{
    public class UserLeave
    {
        [Key]
        public int UserLeaveId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string LeaveType { get; set; }
        public int LeaveCount { get; set; }
    }
}
