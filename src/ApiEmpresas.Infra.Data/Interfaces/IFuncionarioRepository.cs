using ApiEmpresas.Infra.Data.Entities;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositório para operações de Funcionário
    /// </summary>
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        /// <summary>
        /// Método para consultar um funcionário pelo CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        Funcionario ObterPorCpf(string cpf);
        
        /// <summary>
        /// Método para consultar um funcionário pela matrícula
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        Funcionario ObterPorMatricula(string matricula);

        /// <summary>
        /// Método para consultar um ou mais funcionários pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        List<Funcionario> ObterPorNome(string nome);
    }
}
