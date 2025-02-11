using ELMS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ELMS.API.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<LeaveRequest> Employees { get; set; }
        public DbSet<User> Customer { get; set; }
    }
}
