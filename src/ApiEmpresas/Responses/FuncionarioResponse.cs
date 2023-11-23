namespace ApiEmpresas.Services.Responses
{
    /// <summary>
    /// Modelagem da resposta de cadastro de funcionário
    /// </summary>
    public class FuncionarioResponse
    {
        public Guid IdFuncionario { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Matricula { get; set; }
        public DateTime? DataAdmissao { get; set; }

        #region Relacionamento

        public EmpresaResponse Empresa { get; set;} 

        #endregion
    }
}
