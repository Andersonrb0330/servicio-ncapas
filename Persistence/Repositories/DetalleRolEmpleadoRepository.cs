using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class DetalleRolEmpleadoRepository : IDetalleRolEmpleadoRepository
	{
        private readonly IEcommerceContext _ecommerceContext;

		public DetalleRolEmpleadoRepository(
            IEcommerceContext ecommerceContext)
		{
            _ecommerceContext = ecommerceContext;
		}

        public async Task<List<DetalleRolEmpleado>> Get()
        {
            List<DetalleRolEmpleado> detalleRolEmpleados = await _ecommerceContext.DetalleRolEmpleados
                   .Include(d => d.Rol)
                   .Include(d => d.Empleado)
                   .ToListAsync();
            return detalleRolEmpleados;
        }

        public async Task<DetalleRolEmpleado> GetById(int id)
        {
            DetalleRolEmpleado detalleRolEmpleado = await _ecommerceContext.DetalleRolEmpleados
                .Include(d => d.Rol)
                .Include(d => d.Empleado)
                .FirstOrDefaultAsync(d => d.Id == id);
            return detalleRolEmpleado;
        }

        public async Task Create(DetalleRolEmpleado detalleRolEmpleado)
        {
           await _ecommerceContext.DetalleRolEmpleados.AddAsync(detalleRolEmpleado);
        }

        public void Delete(DetalleRolEmpleado detalleRolEmpleado)
        {
            _ecommerceContext.DetalleRolEmpleados.Remove(detalleRolEmpleado);
        }

        public async Task<bool> VerificarEmpleadoRol(int idEmpleado, int idRol)
        {
            bool existeEmpleadoRol = await _ecommerceContext.DetalleRolEmpleados
                .AnyAsync(u => u.IdEmpleado == idEmpleado && u.IdRol == idRol);
            return existeEmpleadoRol;
        }
    }
}

