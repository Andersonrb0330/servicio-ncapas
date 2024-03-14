using Domain.Entity;

namespace Domain.Repositories
{
    public interface IProductoRepository
	{
		Task<List<Producto>> Get();
		Task<Producto> GetById(int id);
		Task Create(Producto producto);
		void Delete(Producto producto);
        Task<List<Producto>> GetPaginado(IQueryable<Producto> queryable, int limite, int excluir);
		Task<IQueryable<Producto>> GetQueryable();
    }
}

