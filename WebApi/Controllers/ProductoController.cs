using Aplication.Dtos.Response;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/producto")]
    public class ProductoController : Controller
    {

        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService) {
            _productoService = productoService;
        }

        [HttpGet]
        public ActionResult<List<ProductoDto>> GetTodoProducto() {

           List<ProductoDto> productoDto = _productoService.ObtenerTodo();

            return productoDto;

        }

        [HttpGet("{id}")]
        public ActionResult<ProductoDto> GetPorIdUsuario(int id) {

            ProductoDto productoDto = _productoService.ObtenerPorId(id);

            return productoDto;

        }



    }
}

