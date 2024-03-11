using Domain.Entity;

namespace Domain.Repositories
{
    public interface IEmpleadoRepository
	{
        Task<bool> ExisteEmpleado(int id);
		Task<List<Empleado>> Get();
		Task<Empleado> GetById(int id);
		Task Create(Empleado empleado);
		void Delete(Empleado empleado);
		List<Empleado> GetPaginado (IQueryable<Empleado> queryable, int limite, int excluir);
		IQueryable<Empleado> GetQueryable();
    }
}

