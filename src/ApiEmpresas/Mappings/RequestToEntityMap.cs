using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Services.Requests;
using AutoMapper;

namespace ApiEmpresas.Services.Mappings
{
    /// <summary>
    /// Mapeamento de objetos REQUEST para ENTITY (INPUT DA API)
    /// </summary>
    public class RequestToEntityMap : Profile
    {
        //construtor para mapear os objetos
        public RequestToEntityMap()
        {
            #region Empresa 

            CreateMap<EmpresaPostRequest, Empresa>();
            CreateMap<EmpresaPutRequest, Empresa>();

            #endregion

            #region Funcionários

            CreateMap<FuncionarioPostRequest, Funcionario>();
            CreateMap<FuncionarioPutRequest, Funcionario>();

            #endregion

        }
    }
}
