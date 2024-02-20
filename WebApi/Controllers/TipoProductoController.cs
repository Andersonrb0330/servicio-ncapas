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

        public TipoProductoController(ITipoProductoService tipoProductoService) {

            _tipoProductoService = tipoProductoService;
        }

        [HttpGet("{id}")]

        public IActionResult GetPorId(int id)
        {
            TipoProductoDto tipo = _tipoProductoService.ObtenerPorId(id);
            return Ok(tipo);
        }

        [HttpGet]
        public IActionResult GetObtenerTodos()
        {
            List<TipoProductoDto> tipoProductoDtos = _tipoProductoService.ObtenerTodos();
            return Ok(tipoProductoDtos);
        }
    }
}

