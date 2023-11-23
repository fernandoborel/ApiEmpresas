using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    /// <summary>
    /// Modelo da requisição de cadastro de usuário
    /// </summary>
    public class RegisterPostRequest
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "O Email é inválido")]
        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "A Senha deve ter no mínimo {1} caracteres")]
        [MaxLength(12, ErrorMessage = "A Senha deve ter no máximo {1} caracteres")]
        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string Senha { get; set; }
    }
}
