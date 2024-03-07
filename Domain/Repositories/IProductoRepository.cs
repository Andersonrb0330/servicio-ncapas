using Domain.Entity;

namespace Domain.Repositories
{
    public interface IProductoRepository
	{
		List<Producto> Get();
		Producto GetById(int id);
		void Create(Producto producto);
		void Delete(Producto producto);
        List<Producto> GetPaginado(IQueryable<Producto> queryable, int limite, int excluir);
		IQueryable<Producto> GetQueryable();
    }
}

