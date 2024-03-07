using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
	{
		private readonly IEcommerceContext _ecommerceContext;

		public EmpleadoRepository(IEcommerceContext ecommerceContext)
		{
			_ecommerceContext = ecommerceContext;
		}

        public bool ExisteEmpleado(int id)
        {
			bool existeEmpleado = _ecommerceContext.Empleados.Any(e => e.Id == id);
			return existeEmpleado;
        }

        public List<Empleado> Get()
        {
            List<Empleado> empleado = _ecommerceContext.Empleados
                .Include(e => e.Empresa)
                .ToList();
            return empleado;
        }

        public Empleado GetById(int id)
        {
            Empleado empleado = _ecommerceContext.Empleados
                .Include(e => e.Empresa)
                .FirstOrDefault(e => e.Id == id);
            return empleado;
        }

        public void Create(Empleado empleado)
        {
            _ecommerceContext.Empleados.Add(empleado);
        }

        public void Delete(Empleado empleado)
        {
            _ecommerceContext.Empleados.Remove(empleado);
        }

        public List<Empleado> GetPaginado(IQueryable<Empleado> queryable, int limite, int excluir)
        {
            return queryable
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

