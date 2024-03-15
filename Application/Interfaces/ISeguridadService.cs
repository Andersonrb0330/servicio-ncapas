using Application.Dtos.Request;
using Application.Dtos.Response;
using Domain.Entity;

namespace Application.Interfaces
{
	public interface ISeguridadService
	{
        Task<SeguridadEmpleadoDto> Login(UsuarioParametroDto usuarioParametroDto);
        string GenerateJwtToken(Empleado empleado);
    }
}

