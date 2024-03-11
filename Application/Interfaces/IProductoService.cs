using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IProductoService
	{
		Task<List<ProductoDto>> ObtenerTodo();
		Task<ProductoDto> ObtenerPorId(int id);
		Task<int> Crear(ProductoParametroDto productoParametroDto);
		void Modificar(ProductoParametroDto productoParametroDto);
		void Eliminar(int id);
        PaginacionDto<ProductoDto> ObtenerProductosPaginados(FiltroProductoParametroDto filtroProductoParametroDto);
    } 
}

