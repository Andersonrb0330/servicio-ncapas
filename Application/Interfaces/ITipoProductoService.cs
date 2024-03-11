using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface ITipoProductoService
    {
		Task<List<TipoProductoDto>> ObtenerTodos();
		Task<TipoProductoDto> ObtenerPorId(int id);
		Task<int> Crear(TipoProductoParametroDto tipoProductoParametroDto);
		void Modificar(TipoProductoParametroDto tipoProductoParametroDto);
		void Eliminar(int id);
        PaginacionDto<TipoProductoDto> ObtenerTipoProductosPaginados(FiltroTipoProductoParametroDto filtroTipoProductoParametroDto);
    }
}

