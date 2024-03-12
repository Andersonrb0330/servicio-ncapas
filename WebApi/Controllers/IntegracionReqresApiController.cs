using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces.ExternalServices;
using Shared.Models.Reqres;
using Shared.Parameters.ReqresApiServiceClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/reqres")]
    public class IntegracionReqresApiController : Controller
    {
        private readonly IReqresApiService _reqresApiService;

        public IntegracionReqresApiController(
            IReqresApiService reqresApiService)
        {
            _reqresApiService = reqresApiService;
        }

        [HttpGet("usuario")]
        public async Task<ActionResult<List<UsuarioModel>>> GetUsuarios(int pagina, int totalElementos)
        {
            List<UsuarioModel> usuario = await _reqresApiService.GetUsuarios(pagina, totalElementos);
            return usuario;
        }

        [HttpPost("user")]
        public async Task<UserModel> PostUser([FromBody] UserParameterDto userParameterDto)
        {
            UserModel user = await _reqresApiService.SaveUser(userParameterDto);
            return user;
        }
    }
}

