using CalcApp.Server.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CalcApp.Server.Extentions
{
    public static class UserExtentions
    {
        private static IServiceCollection AddAuth(this IServiceCollection servicesCollection, IConfiguration configuration)
        {
            var authentivationSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
            servicesCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authentivationSettings.SecretKey))
                    };
                }
             );
            return servicesCollection;
        }
    }
}
