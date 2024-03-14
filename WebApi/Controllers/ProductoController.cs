﻿using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/productos")]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(
            IProductoService productoService
            )
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
        public async Task<ActionResult<List<ProductoDto>>> GetObtenerTodo()
        {
            List<ProductoDto> productosDto = await _productoService.ObtenerTodo();
            return productosDto;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetObtenerPorId(int id)
        { 
            ProductoDto productoDto = await _productoService.ObtenerPorId(id);
            return productoDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCrear([FromBody] ProductoParametroDto productoParametroDto)
        {
            int id = await _productoService.Crear(productoParametroDto);
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

