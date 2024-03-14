using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IEmpleadoService
	{
		Task<List<EmpleadoDto>> Get();
		Task<EmpleadoDto> GetById(int id);
        Task<int> Create(EmpleadoParametroDto empleadoParametroDto);
		Task Update(EmpleadoParametroDto empleadoParametroDto);
		Task Delete(int id);
		Task<PaginacionDto<EmpleadoDto>> ObtenerEmpleadoPaginado(FiltroEmpleadoParametroDto filtroEmpleadoParametroDto);
	}
}

