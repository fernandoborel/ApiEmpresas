using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests;

/// <summary>
/// Classe para requisição de atualização de empresa
/// </summary>
public class EmpresaPutRequest
{
    [Required(ErrorMessage = "Informe o Id")]
    public Guid IdEmpresa { get; set; }

    [Required(ErrorMessage = "Informe o nome fantasia")]  
    public string? NomeFantasia { get; set; }

    [Required(ErrorMessage = "Informe a razão social")]
    public string? RazaoSocial { get; set; }

    [Required(ErrorMessage = "Informe o CNPJ")]
    public string? Cnpj { get; set; }
}
