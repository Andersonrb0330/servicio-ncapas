using Application.Dtos.Response;
using Application.Dtos.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/empresas")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(
            IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost("paginado")]
        public async Task<ActionResult<PaginacionDto<EmpresaDto>>> GetEmpresaPaginados([FromBody] FiltroEmpresaParametroDto filtroEmpresaParametroDto)
        {
            PaginacionDto<EmpresaDto> empresaPaginados  = await _empresaService.ObtenerEmpresaPaginado(filtroEmpresaParametroDto);
            return empresaPaginados;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmpresaDto>>> GetTodoEmpresa()
        {
            List<EmpresaDto> empresaDto = await _empresaService.ObtenerTodo();
            return Ok(empresaDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaDto>> GetPorIdEmpresa(int id)
        {
            EmpresaDto empresaDto = await _empresaService.ObtenerPorId(id);
            return Ok(empresaDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCrearEmpresa([FromBody] EmpresaParametroDto empresaParametroDto)
        {
            int id = await _empresaService.Crear(empresaParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutModificarEmpresa(int id, [FromBody] EmpresaParametroDto empresaParametroDto)
        {
            empresaParametroDto.Id = id;
            await _empresaService.Modificar(empresaParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEliminarEmpresa(int id)
        {
            await _empresaService.Eliminar(id);
            return Ok();
        }     
    }
}

