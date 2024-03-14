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
        private readonly ISeguridadService _seguridadService;

        public SeguridadController(
            ISeguridadService seguridadService)
        {
            _seguridadService = seguridadService;
        }

        [HttpPost]
        public async Task<ActionResult<SeguridadEmpleadoDto>> Login([FromBody]UsuarioParametroDto usuarioParametroDto)
        {
            SeguridadEmpleadoDto empleadoDto = await _seguridadService.Login(usuarioParametroDto);
            return empleadoDto; 
        }
    }
}

