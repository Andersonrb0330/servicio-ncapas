using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/tipo-productos")]
    public class TipoProductoController : Controller
    {
        private readonly ITipoProductoService _tipoProductoService;

        public TipoProductoController(
            ITipoProductoService tipoProductoService)
        {
            _tipoProductoService = tipoProductoService;
        }

        [HttpPost("paginado")]
        public async Task<ActionResult<PaginacionDto<TipoProductoDto>>> GetProductosPaginados([FromBody] FiltroTipoProductoParametroDto filtroTipoProductoParametroDto)
        {
            PaginacionDto<TipoProductoDto> tipoProductosPaginados = await _tipoProductoService.ObtenerTipoProductosPaginados(filtroTipoProductoParametroDto);
            return Ok(tipoProductosPaginados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoProductoDto>> GetPorId(int id)
        {
            TipoProductoDto tipo = await _tipoProductoService.ObtenerPorId(id);
            return Ok(tipo);
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoProductoDto>>> GetObtenerTodos()
        {
            List<TipoProductoDto> tipoProductoDtos = await  _tipoProductoService.ObtenerTodos();
            return Ok(tipoProductoDtos);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCrear([FromBody]TipoProductoParametroDto tipoProductoParametroDto)
        {
            int id = await _tipoProductoService.Crear(tipoProductoParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task< ActionResult> PutModificar(int id, [FromBody] TipoProductoParametroDto tipoProductoParametroDto)
        {
            tipoProductoParametroDto.Id = id;
            await _tipoProductoService.Modificar(tipoProductoParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task< ActionResult> Delete(int id)
        {
            await _tipoProductoService.Eliminar(id);
            return Ok();
        }
    }
}

