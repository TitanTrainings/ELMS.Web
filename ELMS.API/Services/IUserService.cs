using ELMS.API.DTO;
using ELMS.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELMS.API.Services
{
    public interface IUserService
    {
        public UserLeaveBalanceDTO GetLeaveBalance(int userId);

        public User? UserByUserId(int userId);
    }
}
