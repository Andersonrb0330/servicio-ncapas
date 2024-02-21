using Aplication.Dtos.Request;
using Aplication.Dtos.Response;

namespace Aplication.Interfaces
{
    public interface IProductoService
	{
		List<ProductoDto> ObtenerTodo();

		ProductoDto ObtenerPorId(int id);

		int Crear(ProductoParametroDto productoParametroDto);

		void Modificar(ProductoParametroDto productoParametroDto);

		void Eliminar(int id);
	} 
}

