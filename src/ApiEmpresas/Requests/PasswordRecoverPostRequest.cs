using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    public class PasswordRecoverPostRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "Por favor informe um e-mail válido!")]
        public string Email { get; set; }
    }
}
