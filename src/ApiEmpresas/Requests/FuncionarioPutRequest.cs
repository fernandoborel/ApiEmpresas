using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    /// <summary>
    /// Modelagem da requisição de atualização de funcionário
    /// </summary>
    public class FuncionarioPutRequest
    {
        [Required(ErrorMessage = "O id do funcionário é obrigatório")]
        public Guid IdFuncionario { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O CPF do funcionário é obrigatório")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "A matrícula do funcionário é obrigatória")]
        public string? Matricula { get; set; }

        [Required(ErrorMessage = "A data de admissão do funcionário é obrigatória")]
        public DateTime? DataAdmissao { get; set; }

        [Required(ErrorMessage = "A empresa do funcionário é obrigatória")]
        public Guid IdEmpresa { get; set; }
    }
}
