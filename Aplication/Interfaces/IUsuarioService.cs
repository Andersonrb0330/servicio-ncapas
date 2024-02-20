using Aplication.Dtos.Response;

namespace Aplication.Interfaces
{
    public interface IUsuarioService
	{
		List<UsuarioDto> ObtenerTodo();

        UsuarioDto ObtenerPorId(int id);
	}
}

