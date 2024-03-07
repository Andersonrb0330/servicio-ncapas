using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/productos")]
    public class ProductoController : Controller
    {
        
        private readonly IProductoService _productoService;
       
        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpPost("paginado")]
        public ActionResult<PaginacionDto<ProductoDto>> GetProductosPaginados([FromBody] FiltroProductoParametroDto filtroProductoParametroDto)
        {
            PaginacionDto<ProductoDto> productosPaginados = _productoService.ObtenerProductosPaginados(filtroProductoParametroDto);
            return Ok(productosPaginados);
        }

        [HttpGet]
        public ActionResult<List<ProductoDto>> GetObtenerTodo()
        {
            List<ProductoDto> productosDto = _productoService.ObtenerTodo();
            return productosDto;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductoDto> GetObtenerPorId(int id)
        {
            ProductoDto productoDto = _productoService.ObtenerPorId(id);
            return productoDto;
        }

        [HttpPost]
        public ActionResult<int> PostCrear([FromBody] ProductoParametroDto productoParametroDto)
        {
            int id = _productoService.Crear(productoParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductoDto> PutModificar(int id, [FromBody] ProductoParametroDto productoParametroDto)
        {
            productoParametroDto.Id = id;
            _productoService.Modificar(productoParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductoDto> Delete(int id)
        {
            _productoService.Eliminar(id);
            return Ok();
        }
    }
}

