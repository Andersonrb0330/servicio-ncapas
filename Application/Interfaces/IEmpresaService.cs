using Application.Dtos.Response;
using Application.Dtos.Request;

namespace Application.Interfaces
{
    public interface IEmpresaService
	{
		Task<List<EmpresaDto>> ObtenerTodo();
		Task<EmpresaDto> ObtenerPorId(int id);
		Task<int> Crear(EmpresaParametroDto empresaParametroDto);
		void Modificar(EmpresaParametroDto empresaParametroDto);
		void Eliminar(int id);
		PaginacionDto<EmpresaDto> ObtenerEmpresaPaginado(FiltroEmpresaParametroDto filtroEmpresaParametroDto);
	}
} 

