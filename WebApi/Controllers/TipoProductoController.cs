using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/tipo-productos")]
    public class TipoProductoController : Controller
    {
        private readonly ITipoProductoService _tipoProductoService;

        public TipoProductoController(ITipoProductoService tipoProductoService)
        {
            _tipoProductoService = tipoProductoService;
        }

        [HttpPost("paginado")]
        public ActionResult<PaginacionDto<TipoProductoDto>> GetProductosPaginados([FromBody] FiltroTipoProductoParametroDto filtroTipoProductoParametroDto)
        {
            PaginacionDto<TipoProductoDto> tipoProductosPaginados = _tipoProductoService.ObtenerTipoProductosPaginados(filtroTipoProductoParametroDto);
            return Ok(tipoProductosPaginados);
        }

        [HttpGet("{id}")]
        public ActionResult<TipoProductoDto> GetPorId(int id)
        {
            TipoProductoDto tipo = _tipoProductoService.ObtenerPorId(id);
            return Ok(tipo);
        }

        [HttpGet]
        public ActionResult<List<TipoProductoDto>> GetObtenerTodos()
        {
            List<TipoProductoDto> tipoProductoDtos = _tipoProductoService.ObtenerTodos();
            return Ok(tipoProductoDtos);
        }

        [HttpPost]
        public ActionResult<int> PostCrear([FromBody]TipoProductoParametroDto tipoProductoParametroDto)
        {
            int id = _tipoProductoService.Crear(tipoProductoParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public ActionResult<TipoProductoDto> PutModificar(int id, [FromBody] TipoProductoParametroDto tipoProductoParametroDto)
        {
            tipoProductoParametroDto.Id = id;
            _tipoProductoService.Modificar(tipoProductoParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<TipoProductoDto> Delete(int id)
        {
            _tipoProductoService.Eliminar(id);
            return Ok();
        }
    }
}

