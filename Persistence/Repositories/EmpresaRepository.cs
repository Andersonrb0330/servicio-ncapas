using Domain.Entity;
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IEcommerceContext _ecommerceContext;

        public EmpresaRepository(IEcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public bool VerificarEmpresa(int id)
        {
            bool existeEmpresa = _ecommerceContext.Empresas
                .Any(e => e.Id == id);
            return existeEmpresa;
        }

        public List<Empresa> Get()
        {
            List<Empresa> empresa = _ecommerceContext.Empresas
                .ToList();
            return empresa;    
        }

        public Empresa GetById(int id)
        {
            Empresa empresa = _ecommerceContext.Empresas.FirstOrDefault(e => e.Id == id);
            return empresa;
        }

        public void Create(Empresa empresa)
        {
            _ecommerceContext.Empresas.Add(empresa);
        }

        public void Delete(Empresa empresa)
        {
            _ecommerceContext.Empresas.Remove(empresa);
        }

        public List<Empresa> GetPaginado(IQueryable<Empresa> queryble, int limite, int excluir)
        {
            return queryble.OrderBy(p => p.Id)
                           .Skip(excluir)
                           .Take(limite)
                           .ToList();
        }

        public IQueryable<Empresa> GetQueryable()
        {
           IQueryable<Empresa> empresas  = _ecommerceContext.Empresas.AsQueryable();
            return empresas;
        }
    }
}

