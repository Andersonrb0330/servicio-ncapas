using Aplication.Dtos.Response;

namespace Aplication.Interfaces
{
    public interface IProductoService
	{
		List<ProductoDto> ObtenerTodo();

		ProductoDto ObtenerPorId(int id);
	}
}

