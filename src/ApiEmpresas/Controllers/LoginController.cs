using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Services.Authorization;
using ApiEmpresas.Services.Requests;
using ApiEmpresas.Services.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //atributo
        private readonly JwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork;

        //construtor para a injeção de dependência
        public LoginController(JwtService jwtService, IUnitOfWork unitOfWork)
        {
            _jwtService = jwtService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post(LoginPostRequest request)
        {
            try
            {
                //obter o usuário no banco de dados
                var usuario = _unitOfWork.UsuarioRepository
                    .Obter(request.Email, Criptografia.GetMd5(request.Senha));

                //verificar se o usuário foi encontrado
                if(usuario != null)
                {
                    return StatusCode(200, new
                    {
                        message = "Autenticação realizada com sucesso",
                        usuario = usuario.Email,
                        token = _jwtService.GenerateToken(usuario.Email)
                    });
                }
                else
                {
                    return StatusCode(401, new
                    {
                        message = "Usuário ou senha inválidos"
                    });
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
