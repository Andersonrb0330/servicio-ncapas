using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/empleado")]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService; 
        }

        [HttpGet]
        public ActionResult<List<EmpleadoDto>> Get()
        {
            List<EmpleadoDto> empleadoDto = _empleadoService.Get();
            return Ok(empleadoDto);
        }

        [HttpGet("{id}")]
        public ActionResult<EmpleadoDto> GetById(int id)
        {
            EmpleadoDto empleadoDto = _empleadoService.GetById(id);
            return Ok(empleadoDto);
        }

        [HttpPost]
        public ActionResult<EmpleadoDto> Create(EmpleadoParametroDto empleadoParametroDto)
        {
            int id = _empleadoService.Create(empleadoParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public ActionResult<EmpleadoDto> Update(int id, [FromBody] EmpleadoParametroDto empleadoParametroDto)
        {
            empleadoParametroDto.Id = id;
            _empleadoService.Update(empleadoParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<EmpleadoDto> Delete(int id)
        {
            _empleadoService.Delete(id);
            return Ok();
        }
    }
}

