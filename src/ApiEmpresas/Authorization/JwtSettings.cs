namespace ApiEmpresas.Services.Authorization
{
    /// <summary>
    /// Classe para armazenar as informações do token
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// chave secreta antifalsificação
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Tempo de expiração em horas
        /// </summary>
        public int ExpirationInHours { get; set; }
    }
}
