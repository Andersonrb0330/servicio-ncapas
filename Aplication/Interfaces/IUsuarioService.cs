using Aplication.Dtos;

namespace Aplication.Interfaces
{
    public interface IUsuarioService
	{
		List<UsuarioDto> ObtenerTodo();

        UsuarioDto ObtenerPorId(int id);
	}
}

