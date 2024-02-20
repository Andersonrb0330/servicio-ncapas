using Aplication.Dtos;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService) {

            _usuarioService = usuarioService;

        }

        [HttpGet]
        public IActionResult GetTodoUsuario() {

            List<UsuarioDto> usuarioDto = _usuarioService.ObtenerTodo();

            return Ok(usuarioDto);

        }

        [HttpGet("{id}")]
        public IActionResult GetPorIdUsuario(int id) {

            UsuarioDto usuarioDto = _usuarioService.ObtenerPorId(id);

            return Ok(usuarioDto);
        }


    }
}

