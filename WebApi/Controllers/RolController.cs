using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/rol")]
    public class RolController : Controller
    {
        private readonly IRolService _rolService;

        public RolController(
            IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RolDto>>> Get()
        {
            List<RolDto> Roles = await _rolService.Get();
            return Roles;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolDto>> GetById(int id)
        {
            RolDto rolDto = await _rolService.GetById(id);
            return rolDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] RolParametroDto rolParametroDto)
        {
            int id = await _rolService.Crete(rolParametroDto);
            return id;
        }

        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody]  RolParametroDto rolParametroDto)
        {
            rolParametroDto.Id = id;
            await _rolService.Update(rolParametroDto);
        }

        [HttpDelete("{Id}")]
        public async Task Delete(int id)
        {
            await _rolService.Delete(id);
        }
    }
}

