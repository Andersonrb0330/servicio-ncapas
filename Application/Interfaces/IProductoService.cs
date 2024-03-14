using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IProductoService
	{
		Task<List<ProductoDto>> ObtenerTodo();
		Task<ProductoDto> ObtenerPorId(int id);
		Task<int> Crear(ProductoParametroDto productoParametroDto);
		Task Modificar(ProductoParametroDto productoParametroDto);
		Task Eliminar(int id);
        Task<PaginacionDto<ProductoDto>> ObtenerProductosPaginados(FiltroProductoParametroDto filtroProductoParametroDto);
    } 
}

