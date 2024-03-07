using Domain.Entity;
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class TipoProductoRepository : ITipoProductoRepository
	{
        private readonly IEcommerceContext _ecommerceContext;

		public TipoProductoRepository(
            IEcommerceContext ecommerceContext)
		{
            _ecommerceContext = ecommerceContext;
		}

        public bool VerificarTipoProducto(int id)
        {
            bool existeTipoProducto = _ecommerceContext.TipoProductos
                                      .Any(t => t.Id == id);
            return existeTipoProducto;
        }

        public List<TipoProducto> Get()
        {
            List<TipoProducto> tipoProductos = _ecommerceContext.TipoProductos.ToList();
            return tipoProductos;
        }

        public TipoProducto GetById(int id)
        {
            TipoProducto tipoProducto = _ecommerceContext.TipoProductos.FirstOrDefault(tp => tp.Id == id);
            return tipoProducto;
        }

        public void Create(TipoProducto tipoProducto)
        {
            _ecommerceContext.TipoProductos.Add(tipoProducto);
        }

        public void Delete(TipoProducto tipoProducto)
        {
            _ecommerceContext.TipoProductos.Remove(tipoProducto);
        }

        public List<TipoProducto> GetPaginado(IQueryable<TipoProducto> queryable, int limite, int excluir)
        {
            return queryable
                    .OrderBy(p => p.Id)
                    .Skip(excluir)
                    .Take(limite)
                    .ToList();
        }

        public IQueryable<TipoProducto> GetQueryable()
        {
            IQueryable<TipoProducto> tipoProducto = _ecommerceContext.TipoProductos.AsQueryable();
            return tipoProducto;
        }
    }
}

