using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    /// <summary>
    /// Modelagem da rqeuisição de cadastro de empresa
    /// </summary>
    public class EmpresaPostRequest
    {
        [Required(ErrorMessage = "Informe o nome fantasia.")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe a razão social.")]
        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ.")]
        public string? Cnpj { get; set; }
    }
}
