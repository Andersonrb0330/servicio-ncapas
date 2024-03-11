using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("paginado")]
        public ActionResult<PaginacionDto<UsuarioDto>> GetUsuarioPaginado([FromBody] FiltroUsuarioParametroDto filtroUsuarioParametroDto)
        {
            PaginacionDto<UsuarioDto> paginadoUsuario= _usuarioService.ObtenerUsuarioPaginado(filtroUsuarioParametroDto);
            return paginadoUsuario;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDto>>> GetTodoUsuario()
        {
            List<UsuarioDto> usuarioDto = await _usuarioService.ObtenerTodo();
            return Ok(usuarioDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetPorIdUsuario(int id)
        {
            UsuarioDto usuarioDto = await _usuarioService.ObtenerPorId(id);
            return Ok(usuarioDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCrear([FromBody] UsuarioParametroDto usuarioParametroDto)
        {
            int id = await _usuarioService.Crear(usuarioParametroDto);
            return id;
        }

        [HttpPut("{id}")]
        public ActionResult<UsuarioDto> PutModificar(int id, [FromBody] UsuarioParametroDto usuarioParametroDto)
        {
            usuarioParametroDto.Id = id;
            _usuarioService.Modificar(usuarioParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<UsuarioDto> Delete(int id)
        {
            _usuarioService.Eliminar(id);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<bool>> PostLogin(UsuarioParametroDto usuarioParametroDto)
        {
            bool logeo = await _usuarioService.Login(usuarioParametroDto);
            return logeo;
        }

        [HttpPost("login/info")]
        public async Task<ActionResult<EmpleadoDto>> PostLoginInfo(UsuarioParametroDto usuarioParametroDto)
        {
            EmpleadoDto empleadoDto = await  _usuarioService.LoginInfo(usuarioParametroDto);
            return Ok(empleadoDto);
        }
    }
}

