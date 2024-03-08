using Aplication.Dtos.Response;
using Aplication.Dtos.Request;
using Aplication.Interfaces;
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
        public ActionResult<List<EmpresaDto>> GetTodoEmpresa()
        {
            List<EmpresaDto> empresaDto = _empresaService.ObtenerTodo();
            return Ok(empresaDto);
        }

        [HttpGet("{id}")]
        public ActionResult<EmpresaDto> GetPorIdEmpresa(int id)
        {
            EmpresaDto empresaDto = _empresaService.ObtenerPorId(id);
            return Ok(empresaDto);
        }

        [HttpPost]
        public ActionResult<int> PostCrearEmpresa([FromBody]EmpresaParametroDto empresaParametroDto)
        {
            int id = _empresaService.Crear(empresaParametroDto);
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

