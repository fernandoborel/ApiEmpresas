namespace ApiEmpresas.Services.Responses
{
    /// <summary>
    /// Modelagem da resposta de cadastro de empresa
    /// </summary>
    public class EmpresaResponse
    {
        public Guid IdEmpresa { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
    }
}
