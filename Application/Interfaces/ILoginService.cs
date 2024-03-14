using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
	public interface ILoginService
	{
        Task<EmpleadoDto> Login(UsuarioParametroDto usuarioParametroDto);
        string GenerateJwtToken(EmpleadoDto empleadoDto);
    }
}

