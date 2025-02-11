namespace ELMS.API.Services
{
    public interface IJWTTokenService
    {
        string GenerateJwtToken(string usernname, string password, string role);
    }
}
