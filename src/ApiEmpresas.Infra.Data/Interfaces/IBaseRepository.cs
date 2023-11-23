namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface genérica para operações de repositório
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Inserir(TEntity obj);
        void Alterar(TEntity obj);
        void Excluir(TEntity obj);

        List<TEntity> Consultar();
        TEntity ObterPorId(Guid id);
    }
}
