using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IDetalleRolEmpleadoService
	{
		Task<List<DetalleRolEmpleadoDto>> Get();
		Task<DetalleRolEmpleadoDto> GetById (int id);
		Task<int> Create(DetalleRolEmpleadoParametroDto  detalleRolEmpleadoParametroDto);
		Task Update(DetalleRolEmpleadoParametroDto detalleRolEmpleadoParametroDto);
		Task Delete(int id);
	}
}

