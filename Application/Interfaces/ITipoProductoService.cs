using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface ITipoProductoService
    {
		Task<List<TipoProductoDto>> ObtenerTodos();
		Task<TipoProductoDto> ObtenerPorId(int id);
		Task<int> Crear(TipoProductoParametroDto tipoProductoParametroDto);
		Task Modificar(TipoProductoParametroDto tipoProductoParametroDto);
		Task Eliminar(int id);
        Task<PaginacionDto<TipoProductoDto>> ObtenerTipoProductosPaginados(FiltroTipoProductoParametroDto filtroTipoProductoParametroDto);
    }
}

