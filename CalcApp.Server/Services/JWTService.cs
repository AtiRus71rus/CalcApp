using CalcApp.Server.Models;
using CalcApp.Server.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CalcApp.Server.Services
{
    public class JWTService(IOptions<JwtSettings> options)
    {
        //генерация JWT-токена для аутентификации
        public string GenerateToken(UserModel userModel)
        {
            var claims = new List<Claim>
            {
                new Claim("name", userModel.Name),
                new Claim("login", userModel.Login),
                new Claim("password", userModel.Password)
            };
            JwtSecurityToken token = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(options.Value.Expires),
                claims: claims,
                signingCredentials:
                    new SigningCredentials(
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(options.Value.SecretKey)),
                        SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
