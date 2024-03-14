using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> VerificarTipoProducto(int id)
        {
            bool existeTipoProducto = await _ecommerceContext.TipoProductos
                                      .AnyAsync(t => t.Id == id);
            return existeTipoProducto;
        }

        public async Task<List<TipoProducto>> Get()
        {
            List<TipoProducto> tipoProductos = await _ecommerceContext.TipoProductos.ToListAsync();
            return tipoProductos;
        }

        public async Task<TipoProducto> GetById(int id)
        {
            TipoProducto tipoProducto = await _ecommerceContext.TipoProductos.FirstOrDefaultAsync(tp => tp.Id == id);
            return tipoProducto;
        }

        public async Task Create(TipoProducto tipoProducto)
        {
            await _ecommerceContext.TipoProductos.AddAsync(tipoProducto);
        }

        public void Delete(TipoProducto tipoProducto)
        {
            _ecommerceContext.TipoProductos.Remove(tipoProducto);
        }

        public async Task<List<TipoProducto>> GetPaginado(IQueryable<TipoProducto> queryable, int limite, int excluir)
        {
            return queryable
                    .OrderBy(p => p.Id)
                    .Skip(excluir)
                    .Take(limite)
                    .ToList();
        }

        public async Task<IQueryable<TipoProducto>> GetQueryable()
        {
            IQueryable<TipoProducto> tipoProducto = _ecommerceContext.TipoProductos.AsQueryable();
            return tipoProducto;
        }
    }
}

