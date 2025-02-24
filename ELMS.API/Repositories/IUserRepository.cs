using ELMS.API.DTO;

namespace ELMS.API.Repositories
{
    public interface IUserRepository
    {
        public UserLeaveBalanceDTO GetLeaveBalance(string user);
    }
}
