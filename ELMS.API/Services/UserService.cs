using ELMS.API.DTO;
using ELMS.API.Repositories;
using ELMS.API.Repository;

namespace ELMS.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository repository, ILogger<UserService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public UserLeaveBalanceDTO GetLeaveBalance(string user)
        {
            UserLeaveBalanceDTO userLeaveBalanceDTO = new UserLeaveBalanceDTO();
            try
            {
                userLeaveBalanceDTO = _repository.GetLeaveBalance(user);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error Occured at UserService- GetLeaveBalance");
            }
            return userLeaveBalanceDTO;
        }
    }
}
