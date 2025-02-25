using ELMS.API.Models;

namespace ELMS.API.Services
{
    public interface IJWTTokenService
    {
        string GenerateJwtToken(User user);
    }
}
