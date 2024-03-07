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

        public List<Producto> Get()
        {
            List<Producto> productos = _ecommerceContext.Productos
                                       .Include(p => p.TipoProducto)
                                       .ToList();
            return productos;
        }

        public Producto GetById(int id)
        {
            Producto producto = _ecommerceContext.Productos
                                .Include(p => p.TipoProducto)
                                .FirstOrDefault(p => p.Id == id);
            return producto;
        }

        public void Create(Producto producto)
        {
            _ecommerceContext.Productos.Add(producto);
        }

        public void Delete(Producto producto)
        {
            _ecommerceContext.Productos.Remove(producto);
        }

        public List<Producto> GetPaginado(IQueryable<Producto> queryable, int limite, int excluir)
        {
            return queryable
                    .OrderBy(p => p.Id)
                    .Skip(excluir)
                    .Take(limite)
                    .ToList();
        }

        public IQueryable<Producto> GetQueryable()
        {
            IQueryable<Producto> producto = _ecommerceContext.Productos.AsQueryable();
            return producto;
        }
    }
}

