using Aplication.Dtos.Response;

namespace Aplication.Interfaces
{
    public interface ITipoProductoService
    {
		List<TipoProductoDto> ObtenerTodos();

		TipoProductoDto ObtenerPorId(int id);
	}
}

