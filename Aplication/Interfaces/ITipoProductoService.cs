using Aplication.Dtos.Request;
using Aplication.Dtos.Response;

namespace Aplication.Interfaces
{
    public interface ITipoProductoService
    {
		List<TipoProductoDto> ObtenerTodos();

		TipoProductoDto ObtenerPorId(int id);

		int Crear(TipoProductoParametroDto tipoProductoParametroDto);

		void Modificar(TipoProductoParametroDto tipoProductoParametroDto);

		void Eliminar(int id);
	}
}

