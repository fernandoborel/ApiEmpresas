using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiEmpresas.Services.Authorization
{
    /// <summary>
    /// Classe para gerar o token do usuário
    /// </summary>
    public class JwtService
    {
        //atributo
        private readonly JwtSettings _jwtSettings;

        //Construtor para injetar a dependência
        public JwtService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        /// <summary>
        /// Método para gerar o token
        /// </summary>
        public string GenerateToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var tokenDescritor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.Now.AddHours(_jwtSettings.ExpirationInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescritor);

            return tokenHandler.WriteToken(token);
        }
    }
}
