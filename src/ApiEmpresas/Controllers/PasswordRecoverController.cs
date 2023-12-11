using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Services.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordRecoverController : ControllerBase
    {
        //atributo
        private readonly IUnitOfWork _unitOfWork;

        [HttpPost]
        public IActionResult Post(PasswordRecoverPostRequest request)
        {
            return Ok();
        }
    }
}
