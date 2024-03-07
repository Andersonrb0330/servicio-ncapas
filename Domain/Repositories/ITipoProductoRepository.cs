using Domain.Entity;

namespace Domain.Repositories
{
    public interface ITipoProductoRepository 
	{
		List<TipoProducto> Get();
		TipoProducto GetById(int id);
		void Create(TipoProducto tipoProducto);
		void Delete(TipoProducto tipoProducto);
		bool VerificarTipoProducto(int id);
		List<TipoProducto> GetPaginado(IQueryable<TipoProducto> queryable, int limite, int excluir);
		IQueryable<TipoProducto> GetQueryable();
	}
}

