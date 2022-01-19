using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InficareTask.TokenAuthentication
{
    public class TokenManager : ITokenManager
    {
        private readonly JWT _jwt;
        private UserInitializer _users;
        private JwtSecurityTokenHandler tokenHandler;
        public TokenManager(IOptions<JWT> jwt, UserInitializer users)
        {
            tokenHandler = new JwtSecurityTokenHandler();
            _jwt = jwt.Value;
            _users = users;
        }
        public bool Authenticate(string username, string password)
        {
            var users =_users.GetUsers();
            if (!string.IsNullOrWhiteSpace(username) &&
                !string.IsNullOrWhiteSpace(password) &&
                users.Any(x=>x.Username.ToLower() == username.ToLower() && x.Password.ToLower() ==password.ToLower()))
                return true;
            else
                return false;
        }
        public string NewToken()
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }

}