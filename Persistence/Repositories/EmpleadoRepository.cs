using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
	{
		private readonly IEcommerceContext _ecommerceContext;

		public EmpleadoRepository(
            IEcommerceContext ecommerceContext)
		{
			_ecommerceContext = ecommerceContext;
		}

        public async Task<bool> ExisteEmpleado(int id)
        {
			bool existeEmpleado = await _ecommerceContext.Empleados.AnyAsync(e => e.Id == id);
			return existeEmpleado;
        }

        public async Task<List<Empleado>> Get()
        {
            List<Empleado> empleado = await  _ecommerceContext.Empleados
                .Include(e => e.Empresa)
                .ToListAsync();
            return empleado;
        }

        public async Task<Empleado> GetById(int id)
        {
            Empleado empleado = await _ecommerceContext.Empleados
                 .Include(e => e.Empresa)
                .FirstOrDefaultAsync(e => e.Id == id);
            return empleado;
        }

        public async Task<Empleado> GetEmpleadoConDetalleRolById(int id)
        {
            Empleado empleado = await _ecommerceContext.Empleados
                .Include(e => e.DetalleRolEmpleado)
                .FirstOrDefaultAsync(e => e.Id == id);
            return empleado;
        }

        public async Task Create(Empleado empleado)
        {
           await _ecommerceContext.Empleados.AddAsync(empleado);
        }
         
        public void Delete(Empleado empleado)
        {
            _ecommerceContext.Empleados.Remove(empleado);
        }

        public async Task< List<Empleado>> GetPaginado(IQueryable<Empleado> queryable, int limite, int excluir)
        {
            return  queryable
                    .OrderBy(p => p.Id)
                    .Skip(excluir)
                    .Take(limite)
                    .ToList();
        }

        public IQueryable<Empleado> GetQueryable()
        {
            IQueryable<Empleado> empleado = _ecommerceContext.Empleados.AsQueryable();
            return empleado;
        }
    }
}

