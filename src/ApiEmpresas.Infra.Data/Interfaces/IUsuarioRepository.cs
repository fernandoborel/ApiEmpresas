using ApiEmpresas.Infra.Data.Entities;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositório para operações de Usuário
    /// </summary>
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        /// <summary>
        /// Consultar 1 usuário pelo email
        /// </summary>
        Usuario Obter(string email);

        /// <summary>
        /// Consultar 1 usuário pelo email e senha
        /// </summary>
        Usuario Obter(string email, string senha);
    }
}
