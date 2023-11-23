using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    /// <summary>
    /// Modelo de dados para a rqeuisição de login
    /// </summary>
    public class LoginPostRequest
    {
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        [Required(ErrorMessage = "Informe o email de acesso")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha de acesso")]
        public string Senha { get; set; }
    }
}
