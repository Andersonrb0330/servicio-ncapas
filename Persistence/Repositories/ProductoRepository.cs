using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IEcommerceContext _ecommerceContext;

        public ProductoRepository(
            IEcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public async Task<List<Producto>> Get()
        {
            List<Producto> productos =  await _ecommerceContext.Productos
                                       .Include(p => p.TipoProducto)
                                       .ToListAsync();
            return productos;
        }

        public async Task<Producto> GetById(int id)
        {
            Producto producto = await  _ecommerceContext.Productos
                                .Include(p => p.TipoProducto)
                                .FirstOrDefaultAsync(p => p.Id == id);
            return producto;
        }

        public async Task Create(Producto producto)
        {
           await _ecommerceContext.Productos.AddAsync(producto);
        }

        public void Delete(Producto producto)
        {
            _ecommerceContext.Productos.Remove(producto);
        }

        public async Task<List<Producto>> GetPaginado(IQueryable<Producto> queryable, int limite, int excluir)
        {
            return queryable
                    .OrderBy(p => p.Id)
                    .Skip(excluir)
                    .Take(limite)
                    .ToList();
        }

        public async Task<IQueryable<Producto>> GetQueryable()
        {
            IQueryable<Producto> producto = _ecommerceContext.Productos.AsQueryable();
            return producto;
        }
    }
}

