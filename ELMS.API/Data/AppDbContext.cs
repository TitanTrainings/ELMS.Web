using ELMS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ELMS.API.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLeave> UserLeaves { get; set; }
    }
}
