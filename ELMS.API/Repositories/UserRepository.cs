using ELMS.API.Data;
using ELMS.API.DTO;
using ELMS.API.Models;
using ELMS.API.Repository;

namespace ELMS.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public UserLeaveBalanceDTO GetLeaveBalance(string user)
        {
            UserLeaveBalanceDTO userLeaveBalanceDTO = null;
            try
            {
                var userId = _context.Users.FirstOrDefault(x => x.Username == user).UserId;
                List<UserLeave> userLeaves = _context.UserLeaves.Where(x => x.UserId == userId).ToList();
                if(userId != null)
                {
                    userLeaveBalanceDTO = new UserLeaveBalanceDTO()
                    {
                        TotalVacationLeave = 15,
                        TotalSickLeave = 15,
                        TotalAnnualLeave = 30,
                        UsedVacationLeave = userLeaves.Where(x => x.LeaveType == "Vacation").Sum(x=>x.LeaveCount),
                        UsedSickLeave = userLeaves.Where(x => x.LeaveType == "Sick").Sum(x => x.LeaveCount)
                    };

                    userLeaveBalanceDTO.RemainingVacationLeave = userLeaveBalanceDTO.TotalVacationLeave - userLeaveBalanceDTO.UsedVacationLeave;
                    userLeaveBalanceDTO.RemainingSickLeave = userLeaveBalanceDTO.TotalSickLeave - userLeaveBalanceDTO.UsedSickLeave;
                    userLeaveBalanceDTO.BalanceAnnualLeave = userLeaveBalanceDTO.RemainingVacationLeave + userLeaveBalanceDTO.RemainingSickLeave;
                }
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "Error Occured at LeaveRepository - GetLeaveBalance");
            }
            return userLeaveBalanceDTO;
        }

        public User? UserByUserId(int userId)
        {
           var user = _context.Users.Find(userId);

            return user;
        }
    }
}
