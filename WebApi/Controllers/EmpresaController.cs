using Application.Dtos.Response;
using Application.Dtos.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/empresas")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost("paginado")]
        public ActionResult<PaginacionDto<EmpresaDto>> GetEmpresaPaginados([FromBody] FiltroEmpresaParametroDto filtroEmpresaParametroDto)
        {
            PaginacionDto<EmpresaDto> empresaPaginados  = _empresaService.ObtenerEmpresaPaginado(filtroEmpresaParametroDto);
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
        public async Task<ActionResult<int>> PostCrearEmpresa([FromBody]EmpresaParametroDto empresaParametroDto)
        {
            int id = await _empresaService.Crear(empresaParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public ActionResult PutModificarEmpresa(int id, [FromBody] EmpresaParametroDto empresaParametroDto)
        {
            empresaParametroDto.Id = id;
            _empresaService.Modificar(empresaParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEliminarEmpresa(int id)
        {
            _empresaService.Eliminar(id);
            return Ok();
        }     
    }
}

