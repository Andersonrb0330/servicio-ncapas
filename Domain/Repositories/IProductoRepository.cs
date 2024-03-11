using Domain.Entity;

namespace Domain.Repositories
{
    public interface IProductoRepository
	{
		Task<List<Producto>> Get();
		Task<Producto> GetById(int id);
		Task Create(Producto producto);
		void Delete(Producto producto);
        List<Producto> GetPaginado(IQueryable<Producto> queryable, int limite, int excluir);
		IQueryable<Producto> GetQueryable();
    }
}

