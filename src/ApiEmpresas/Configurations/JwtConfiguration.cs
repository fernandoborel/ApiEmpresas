using ApiEmpresas.Services.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// Classe para configurar o JWT
    /// </summary>
    public class JwtConfiguration
    {
        /// <summary>
        /// Configurar o JWT - JSON WEB TOKEN
        /// </summary>
        public static void AddJwt(WebApplicationBuilder builder)
        {
            var settings = builder.Configuration.GetSection("JwtSettings");
            builder.Services.Configure<JwtSettings>(settings);

            var appSettings = settings.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            builder.Services.AddAuthentication(
                 auth =>
                 {
                     auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                     auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 })
                .AddJwtBearer(auth =>
                {
                    auth.RequireHttpsMetadata = false;
                    auth.SaveToken = true;
                    auth.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false, //emissor
                        ValidateAudience = false //destinatário
                    };
                });

            builder.Services.AddTransient(map => new JwtService(appSettings));
        }
    }
}
