using ELMS.API.DTO;
using ELMS.API.Models;

namespace ELMS.API.Services
{
    public interface IAuthService
    {
        User AuthenticateUser(string username, string password);
    }
}
