using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IEmpleadoService
	{
		Task<List<EmpleadoDto>> Get();
		Task<EmpleadoDto> GetById(int id);
        Task<int> Create(EmpleadoParametroDto empleadoParametroDto);
		void Update(EmpleadoParametroDto empleadoParametroDto);
		void Delete(int id);
		PaginacionDto<EmpleadoDto> ObtenerEmpleadoPaginado(FiltroEmpleadoParametroDto filtroEmpleadoParametroDto);
	}
}

