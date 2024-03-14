using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/pais")]
    public class PaisController : Controller
    {
        private readonly IPaisService _paisService;

        public PaisController(
             IPaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet]
        public ActionResult<List<PaisDto>> Get()
        {
            List<PaisDto> paisDtos = _paisService.Get();
            return Ok(paisDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<PaisDto> GetById(int id)
        {
            PaisDto paisDto = _paisService.GetById(id);
            return Ok(paisDto);
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody]  PaisParametroDto paisParametroDto)
        { 
            int id = _paisService.Create(paisParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public ActionResult<PaisDto> Update(int id, [FromBody] PaisParametroDto paisParametroDto)
        {
            paisParametroDto.Id = id;
            _paisService.Update(paisParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<PaisDto> Delete(int id)
        {
            _paisService.Delete(id);
            return Ok();
        }
    }
}

