using Application.Dtos.Response;
using Application.Dtos.Request;

namespace Application.Interfaces
{
    public interface IEmpresaService
	{
		Task<List<EmpresaDto>> ObtenerTodo();
		Task<EmpresaDto> ObtenerPorId(int id);
		Task<int> Crear(EmpresaParametroDto empresaParametroDto);
		Task Modificar(EmpresaParametroDto empresaParametroDto);
		Task Eliminar(int id);
		Task<PaginacionDto<EmpresaDto>> ObtenerEmpresaPaginado(FiltroEmpresaParametroDto filtroEmpresaParametroDto);
	}
} 

