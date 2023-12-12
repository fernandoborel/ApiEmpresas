using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Messages.Services;
using ApiEmpresas.Services.Requests;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordRecoverController : ControllerBase
    {
        //atributos
        private readonly IUnitOfWork _unitOfWork;
        private readonly MailService _mailService;

        public PasswordRecoverController(IUnitOfWork unitOfWork, MailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult Post(PasswordRecoverPostRequest request)
        {
            try
            {
                //buscar o usuário pelo e-mail
                var usuario = _unitOfWork.UsuarioRepository.Obter(request.Email);

                //verificar se o usuário existe
                if (usuario != null)
                {
                    var novaSenha = new Faker().Internet.Password;

                    return StatusCode(200, new { message = "Recuperação de senha realizada com sucesso, favor verificar seu e-mail!" });
                }
                else
                {
                    return StatusCode(422, new { message = "O e-mail informado não foi encontrado!"});
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private void EnviarEmailDeRecuperacaoDeSenha(Usuario usuario, string novaSenha)
        {
            var subject = "Recuperação de senha de usuário";

            var body = $@"
                     <div style='text-align: center; margin: 40px; padding: 60px; border: 2px solid #ccc; font-size: 16pt;'>
                     <br/><br/>
                     Olá <strong>{usuario.Nome}</strong>,
                     <br/><br/>    
                     O sistema gerou uma nova senha para que você possa acessar sua conta.<br/>
                     Por favor utilize a senha: <strong>{novaSenha}</strong>
                     <br/><br/>
                     Não esqueça de, ao acessar o sistema, atualizar esta senha para outra
                     de sua preferência.
                     <br/><br/>              
                     Att,<br/>   
                     Equipe de Suporte
                     </div> 
            ";

            _mailService.SendMail(usuario.Email, subject, body);
        }
    }
}
