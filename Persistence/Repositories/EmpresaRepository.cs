using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IEcommerceContext _ecommerceContext;

        public EmpresaRepository(
            IEcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public async Task<bool> VerificarEmpresa(int id)
        {
            bool existeEmpresa = _ecommerceContext.Empresas
                .Any(e => e.Id == id);
            return existeEmpresa;
        }

        public async Task<List<Empresa>> Get()
        {
            List<Empresa> empresa = await _ecommerceContext.Empresas
                .ToListAsync();
            return empresa;    
        }

        public async Task<Empresa> GetById(int id)
        {
            Empresa empresa = await _ecommerceContext.Empresas.FirstOrDefaultAsync(e => e.Id == id);
            return empresa;
        }

        public async Task Create(Empresa empresa)
        {
           await  _ecommerceContext.Empresas.AddAsync(empresa);
        }

        public void Delete(Empresa empresa)
        {
            _ecommerceContext.Empresas.Remove(empresa);
        }

        public async Task< List<Empresa>> GetPaginado(IQueryable<Empresa> queryble, int limite, int excluir)
        {
            return queryble.OrderBy(p => p.Id)
                           .Skip(excluir)
                           .Take(limite)
                           .ToList();
        }

        public async Task< IQueryable<Empresa>> GetQueryable()
        {
           IQueryable<Empresa> empresas  = _ecommerceContext.Empresas.AsQueryable();
            return empresas;
        }
    }
}

