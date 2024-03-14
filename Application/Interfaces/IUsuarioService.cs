using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IUsuarioService
	{
        Task<List<UsuarioDto>> ObtenerTodo();
        Task<UsuarioDto> ObtenerPorId(int id);
        Task<int> Crear(UsuarioParametroDto usuarioParametroDto);
        Task Modificar(UsuarioParametroDto usuarioParametroDto);
        Task Eliminar(int id);
        Task<PaginacionDto<UsuarioDto>> ObtenerUsuarioPaginado(FiltroUsuarioParametroDto filtroUsuarioParametroDto);
    }
}

