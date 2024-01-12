using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Services.Requests;
using ApiEmpresas.Services.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresas.Services.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class EmpresasController : ControllerBase
{
    //atributo
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    //construtor para injeção de dependência
    public EmpresasController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    
    [HttpPost]
    public IActionResult Post(EmpresaPostRequest request)
    {
        try
        {
            //verificar se o cnpj já existe
            if (_unitOfWork.EmpresaRepository.ObterPorCnpj(request.Cnpj) != null)
                //HTTP 422 => entidade não processada
                return StatusCode(422, new { message = "O CNPJ informado já está cadastrado!"});

            var empresa = _mapper.Map<Empresa>(request);
            empresa.IdEmpresa = Guid.NewGuid();

            //gravar no banco de dados
            _unitOfWork.EmpresaRepository.Inserir(empresa);

            var response = _mapper.Map<EmpresaResponse>(empresa);

            //HTTP 201 => criado
            return StatusCode(201, response);
        }
        catch (Exception e)
        {
            //HTTP 500 => erro interno do servidor
            return StatusCode(500, e.Message);
        }
    }

    
    [HttpPut]
    public IActionResult Put(EmpresaPutRequest request)
    {
        try
        {
            //pesquisar a empresa pelo Id
            var empresa = _unitOfWork.EmpresaRepository.ObterPorId(request.IdEmpresa);

            //verificar se a empresa não foi encontrada
            if(empresa == null)
                //HTTP 422 => Entidade não processada
                return StatusCode(422, new { message = "Empresa não encontrada!"});

            //verificar se o cnpj já existe em outra empresa
            var registro = _unitOfWork.EmpresaRepository.ObterPorCnpj(request.Cnpj);
            if (registro != null && registro.IdEmpresa != empresa.IdEmpresa)
                //HTTP 422 => Entidade não processada
                return StatusCode(422, new { message = "O CNPJ informado já está cadastrado para outra empresa!"});

            //atualizar os dados da empresa
            _mapper.Map(request, empresa);

            //alterar no banco de dados
            _unitOfWork.EmpresaRepository.Alterar(empresa);

            var response = _mapper.Map<EmpresaResponse>(empresa);

            //HTTP 200 => ok
            return StatusCode(200, response);
        }
        catch (Exception e)
        {
            //HTTP 500 => erro interno do servidor
            return StatusCode(500, e.Message);
        }
    }

    
    [HttpDelete("{Id}")]
    public IActionResult Delete(Guid Id)
    {
        try
        {
            //pesquisar a empresa pelo Id
            var empresa = _unitOfWork.EmpresaRepository.ObterPorId(Id);

            //verificar se a empresa não foi encontrada
            if(empresa == null)
                //HTTP 422 => Entidade não processada
                return StatusCode(422, new { message = "Empresa não encontrada!"});

            //excluir a empresa
            _unitOfWork.EmpresaRepository.Excluir(empresa);

            var response = _mapper.Map<EmpresaResponse>(empresa);

            //HTTP 200 => ok
            return StatusCode(200, response);
        }
        catch (Exception e)
        {
            //HTTP 500 => erro interno do servidor
            return StatusCode(500, e.Message);
        }
    }

    
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var empresas = _unitOfWork.EmpresaRepository.Consultar();
            var lista = _mapper.Map<List<EmpresaResponse>>(empresas);

            if (lista.Count > 0)
                //HTTP 200 => ok
                return StatusCode(200, lista);
            else
                //HTTP 204 => sem conteúdo
                return StatusCode(204);
        }
        catch (Exception e)
        {
            //HTTP 500 => erro interno do servidor
            return StatusCode(500, e.Message);
        }
    }


    [HttpGet("{Id}")]
    public IActionResult GetById(Guid Id)
    {
        try
        {
            var empresa = _unitOfWork.EmpresaRepository.ObterPorId(Id);

            //verificar se a empresa não foi encontrada
            if(empresa != null)
            {
                var response = _mapper.Map<EmpresaResponse>(empresa);

                //HTTP 200 => ok
                return StatusCode(200, response);
            }
            else
            {
                //HTTP 204 => sem conteúdo
                return StatusCode(204);
            }
        }
        catch (Exception e)
        {
            //HTTP 500 => erro interno do servidor
            return StatusCode(500, e.Message);
        }
    }
}
