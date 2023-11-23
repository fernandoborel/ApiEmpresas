using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Services.Responses;
using AutoMapper;

namespace ApiEmpresas.Services.Mappings
{
    /// <summary>
    /// Mapeamento de objetos ENTITY para RESPONSE (OUTPUT DA API)
    /// </summary>
    public class EntityToResponseMap : Profile
    {
        //construtor para mapear os objetos
        public EntityToResponseMap()
        {
            #region Empresa

            CreateMap<Empresa, EmpresaResponse>();

            #endregion

            #region Funcionários

            CreateMap<Funcionario, FuncionarioResponse>();

            #endregion
        }
    }
}
