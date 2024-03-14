using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
	public interface ISeguridadService
	{
        Task<SeguridadEmpleadoDto> Login(UsuarioParametroDto usuarioParametroDto);
        string GenerateJwtToken(EmpleadoDto empleadoDto);
    }
}

