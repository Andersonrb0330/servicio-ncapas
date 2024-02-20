using Aplication.Dtos.Response;
using Aplication.Dtos.Request;

namespace Aplication.Interfaces
{
    public interface IEmpresaService
	{
		List<EmpresaDto> ObtenerTodo();

		EmpresaDto ObtenerPorId(int id);

		int Crear(EmpresaParametroDto empresaParametroDto);

		void Modificar(EmpresaParametroDto empresaParametroDto);

		void Eliminar(int id);
	}
} 

