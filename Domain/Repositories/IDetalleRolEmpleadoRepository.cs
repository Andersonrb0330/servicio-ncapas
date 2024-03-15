using Domain.Entity;

namespace Domain.Repositories
{
    public interface IDetalleRolEmpleadoRepository
	{
		Task<List<DetalleRolEmpleado>> Get();
		Task<DetalleRolEmpleado> GetById(int id);
		Task Create(DetalleRolEmpleado detalleRolEmpleado);
		void Delete(DetalleRolEmpleado detalleRolEmpleado);
        Task<bool> VerificarEmpleadoRol(int idEmpleado, int idRol);
    }
}

