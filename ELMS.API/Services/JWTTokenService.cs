namespace ELMS.API.Services
{
    public class JWTTokenService : IJWTTokenService
    {
        public string GenerateJwtToken(string usernname, string password, string role)
        {
            //write here the logic to generate the token based on the username and password and role.
            //assign the username , password and role in the claim of the jwt token.

            return string.Empty;
        }
    }
}
