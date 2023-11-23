using ApiEmpresas.Infra.Data.Entities;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositório para operações de Empresa
    /// </summary>
    public interface IEmpresaRepository : IBaseRepository<Empresa>
    {
        /// <summary>
        /// Método para consultar uma empresa pelo CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        Empresa ObterPorCnpj(string cnpj);
    }
}
