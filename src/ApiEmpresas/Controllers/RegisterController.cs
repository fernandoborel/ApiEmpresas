using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Services.Requests;
using ApiEmpresas.Services.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        //atributo
        private readonly IUnitOfWork _unitOfWork;

        //construtor para injeção de dependência
        public RegisterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post(RegisterPostRequest request)
        {
            try
            {
                //verificar se o usuário já existe no banco de dados
                if(_unitOfWork.UsuarioRepository.Obter(request.Email) != null)
                    return StatusCode(422, new { message = "Usuário já cadastrado" });

                var usuario = new Usuario
                {
                    IdUsuario = Guid.NewGuid(),
                    Nome = request.Nome,
                    Email = request.Email,
                    Senha = Criptografia.GetMd5(request.Senha),
                    DataInclusao = DateTime.Now
                };

                _unitOfWork.UsuarioRepository.Inserir(usuario);

                return StatusCode(201, new { message = "Usuário cadastrado com sucesso" });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
