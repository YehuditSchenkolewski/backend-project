using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dot_net_userInfo.Models;
using dot_net_userInfo.Models.LoginModels;

namespace dot_net_userInfo.Handlers
{
    public interface IJWTAuthenticationManager
    {
        LoginResponseModel? Authenticate(User user);
    }

    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {

        private readonly string tokenKey;

        public JWTAuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }

        public LoginResponseModel? Authenticate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email ?? "")
                }),
                Expires = DateTime.UtcNow.AddDays(1),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new LoginResponseModel(tokenHandler.WriteToken(token), user);
        }
    }
}

