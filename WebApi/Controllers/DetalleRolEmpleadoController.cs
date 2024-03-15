using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/detalle-rol-empleado")]
    public class DetalleRolEmpleadoController : Controller
    {
        private readonly IDetalleRolEmpleadoService _detalleRolEmpleadoService;

        public DetalleRolEmpleadoController(
            IDetalleRolEmpleadoService detalleRolEmpleadoService)
        {
            _detalleRolEmpleadoService = detalleRolEmpleadoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetalleRolEmpleadoDto>>> Get ()
        {
            List<DetalleRolEmpleadoDto> detalleRolEmpleadoDtos = await _detalleRolEmpleadoService.Get();
            return Ok(detalleRolEmpleadoDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleRolEmpleadoDto>> GetById(int id)
        {
            DetalleRolEmpleadoDto detalleRolEmpleadoDto = await _detalleRolEmpleadoService.GetById(id);
            return Ok(detalleRolEmpleadoDto);
        }

        [HttpPost]
        public async Task<ActionResult<DetalleRolEmpleadoDto>> Create([FromBody] DetalleRolEmpleadoParametroDto detalleRolEmpleadoParametroDto)
        {
            int id = await _detalleRolEmpleadoService.Create(detalleRolEmpleadoParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task <ActionResult> Update(int id, [FromBody] DetalleRolEmpleadoParametroDto detalleRolEmpleadoParametroDto)
        {
            detalleRolEmpleadoParametroDto.Id = id;
            await _detalleRolEmpleadoService.Update(detalleRolEmpleadoParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            await _detalleRolEmpleadoService.Delete(id);
            return Ok();
        }
    }
}

