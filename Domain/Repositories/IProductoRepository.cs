using Domain.Entity;

namespace Domain.Repositories
{
    public interface IProductoRepository
	{
		List<Producto> Get();
		Producto GetById(int id);
		void Create(Producto producto);
		void Delete(Producto producto);
	}
}

