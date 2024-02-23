using Aplication.Dtos.Request;
using Aplication.Dtos.Response;

namespace Aplication.Interfaces
{
    public interface IUsuarioService
	{
		List<UsuarioDto> ObtenerTodo();

        UsuarioDto ObtenerPorId(int id);

		int Crear(UsuarioParametroDto usuarioParametroDto);

		void Modificar(UsuarioParametroDto usuarioParametroDto);

		void Eliminar(int id);

		bool Login(UsuarioParametroDto usuarioParametroDto);

		EmpleadoDto LoginInfo(UsuarioParametroDto usuarioParametroDto);

	
	}
}

