using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace InficareTask.TokenAuthentication
{
    public interface ITokenManager
    {
        bool Authenticate(string username, string password);
        string NewToken();
    }
}