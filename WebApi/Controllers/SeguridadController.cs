using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/seguridad")]
    public class SeguridadController : Controller
    {
        private readonly ILoginService _loginService;

        public SeguridadController(
            ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<EmpleadoDto>> Login([FromBody]UsuarioParametroDto usuarioParametroDto)
        {
           EmpleadoDto empleadoDto = await _loginService.Login(usuarioParametroDto);
           return empleadoDto; 
        }

        [HttpGet("token")]
        public ActionResult<string> Token()
        {
            var empleado = new EmpleadoDto
            {
                Id = 1,
                Nombre = "Test"
            };
            var token = _loginService.GenerateJwtToken(empleado);
            return token;
        }
    }
}

