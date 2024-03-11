using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IUsuarioService
	{
		Task<List<UsuarioDto>> ObtenerTodo();
        Task<UsuarioDto> ObtenerPorId(int id);
		Task<int> Crear(UsuarioParametroDto usuarioParametroDto);
		void Modificar(UsuarioParametroDto usuarioParametroDto);
		void Eliminar(int id);
		Task<bool> Login(UsuarioParametroDto usuarioParametroDto);
		Task<EmpleadoDto> LoginInfo(UsuarioParametroDto usuarioParametroDto);
		PaginacionDto<UsuarioDto> ObtenerUsuarioPaginado(FiltroUsuarioParametroDto filtroUsuarioParametroDto);
	}
}

