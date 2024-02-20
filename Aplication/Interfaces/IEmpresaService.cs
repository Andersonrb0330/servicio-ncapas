using Aplication.Dtos;

namespace Aplication.Interfaces
{
    public interface IEmpresaService
	{
		List<EmpresaDto> ObtenerTodo();

		EmpresaDto ObtenerPorId(int id);
	}
}

