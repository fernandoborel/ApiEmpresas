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
public class FuncionariosController : ControllerBase
{
    //atributos
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    //construtor para injeção de dependência
    public FuncionariosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Post(FuncionarioPostRequest request)
    {
        try
        {
            //verifica se existe um funcionário com o mesmo CPF
            if(_unitOfWork.FuncionarioRepository.ObterPorCpf(request.Cpf) != null)
            {
                return StatusCode(422, new { message = "Já existe um funcionário com este CPF" });
            }

            //verifica se existe um funcionário com a mesma matrícula
            if(_unitOfWork.FuncionarioRepository.ObterPorMatricula(request.Matricula) != null)
            {
                return StatusCode(422, new { message = "Já existe um funcionário com esta matrícula" });
            }

            //verifica se a empresa existe
            var empresa = _unitOfWork.EmpresaRepository.ObterPorId(request.IdEmpresa);
            if (empresa == null)
                return StatusCode(422, new { message = "Empresa não encontrada" });

            //mapeia o request
            var funcionario = _mapper.Map<Funcionario>(request);
            funcionario.IdFuncionario = Guid.NewGuid();

            //salva o funcionário no banco
            _unitOfWork.FuncionarioRepository.Inserir(funcionario);

            //devolve o request para response
            var response = _mapper.Map<FuncionarioResponse>(funcionario);
            response.Empresa = _mapper.Map<EmpresaResponse>(empresa);

            return StatusCode(201, response);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    public IActionResult Put(FuncionarioPutRequest request)
    {
        try
        {
            var funcionario = _unitOfWork.FuncionarioRepository.ObterPorId(request.IdFuncionario);
            //valida se o funcionário existe
            if(funcionario == null)
                return StatusCode(422, new { message = "Funcionário não encontrado" });

            //verifica o cpf do funcionário
            var registroCpf = _unitOfWork.FuncionarioRepository.ObterPorCpf(request.Cpf);
            if(registroCpf != null && registroCpf.IdFuncionario != funcionario.IdFuncionario)
                return StatusCode(422, new { message = "Já existe um funcionário com este CPF" });

            //verifica a matricula do funcionário
            var registroMatricula = _unitOfWork.FuncionarioRepository.ObterPorMatricula(request.Matricula);
            if(registroMatricula != null && registroMatricula.IdFuncionario != funcionario.IdFuncionario)
                return StatusCode(422, new { message = "Já existe um funcionário com esta matrícula" });
        
            //verifica se a empresa existe
            var empresa = _unitOfWork.EmpresaRepository.ObterPorId(request.IdEmpresa);
            if (empresa == null)
                return StatusCode(422, new { message = "Empresa não encontrada" });

            //mapeia o request
            funcionario = _mapper.Map<Funcionario>(request);

            //salva o funcionário no banco
            _unitOfWork.FuncionarioRepository.Alterar(funcionario);

            //devolve o request para response
            var response = _mapper.Map<FuncionarioResponse>(funcionario);
            response.Empresa = _mapper.Map<EmpresaResponse>(empresa);

            return StatusCode(200, response);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }

    }

    [HttpDelete("{idFuncionario}")]
    public IActionResult Delete(Guid idFuncionario)
    {
        try
        {
            var funcionario = _unitOfWork.FuncionarioRepository.ObterPorId(idFuncionario);
            //valida se o funcionário existe
            if(funcionario == null)
                return StatusCode(422, new { message = "Funcionário não encontrado" });

            //dados da empresa
            var empresa = _unitOfWork.EmpresaRepository.ObterPorId(funcionario.IdEmpresa);

            //remove o funcionário do banco
            _unitOfWork.FuncionarioRepository.Excluir(funcionario);

            //devolve o request para response
            var response = _mapper.Map<FuncionarioResponse>(funcionario);
            response.Empresa = _mapper.Map<EmpresaResponse>(empresa);

            return StatusCode(200, new { message = "Funcionário removido com sucesso" });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var funcionarios = _unitOfWork.FuncionarioRepository.Consultar();
            var lista = _mapper.Map<List<FuncionarioResponse>>(funcionarios);

            if(lista.Count > 0)
                return StatusCode(200, lista);
            else
                return StatusCode(404, new { message = "Nenhum funcionário encontrado" });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{idFuncionario}")]
    public IActionResult GetById(Guid idFuncionario)
    {
        try
        {
            var funcionario = _unitOfWork.FuncionarioRepository.ObterPorId(idFuncionario);
            if (funcionario != null)
            {
                var response = _mapper.Map<FuncionarioResponse>(funcionario);
                return StatusCode(200, response);
            }
            else
                return StatusCode(204);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
