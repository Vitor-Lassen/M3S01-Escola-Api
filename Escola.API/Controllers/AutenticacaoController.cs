using Escola.API.DTO;
using Escola.API.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Escola.API.Controllers
{
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {

        private readonly IAutenticacaoServices _autenticacaoServices;
        public AutenticacaoController(IAutenticacaoServices autenticacaoServices)
        {
             _autenticacaoServices =   autenticacaoServices;
        }
        [HttpPost("/login")]
        public ActionResult Logar(LoginDTO loginDTO)
        {
            return Ok(new { token = _autenticacaoServices.Autenticar(loginDTO)});
        }
    }
}
