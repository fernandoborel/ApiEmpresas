namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de unidade de trabalho do Entity framework
    /// </summary>
    public interface IUnitOfWork
    {
        #region Métodos para controle de transação

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion

        #region Métodos para acesso aos repositórios

        public IEmpresaRepository EmpresaRepository { get; }
        public IFuncionarioRepository FuncionarioRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }

        #endregion
    }
}
