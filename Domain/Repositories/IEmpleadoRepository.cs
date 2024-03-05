using Domain.Entity;

namespace Domain.Repositories
{
    public interface IEmpleadoRepository
	{
		bool ExisteEmpleado(int id);
		List<Empleado> Get();
		Empleado GetById(int id);
		void Create(Empleado empleado);
		void Delete(Empleado empleado);
    }
}

