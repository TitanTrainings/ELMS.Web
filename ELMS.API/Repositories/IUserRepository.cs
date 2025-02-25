using ELMS.API.DTO;
using ELMS.API.Models;

namespace ELMS.API.Repositories
{
    public interface IUserRepository
    {
        public UserLeaveBalanceDTO GetLeaveBalance(int userId);
        public User? UserByUserId(int userId);
    }
}
