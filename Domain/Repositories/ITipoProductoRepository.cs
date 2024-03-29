﻿using Domain.Entity;

namespace Domain.Repositories
{
    public interface ITipoProductoRepository 
	{
		Task<List<TipoProducto>> Get();
		Task<TipoProducto> GetById(int id);
		Task Create(TipoProducto tipoProducto);
		void Delete(TipoProducto tipoProducto);
		Task<bool> VerificarTipoProducto(int id);
		Task<List<TipoProducto>> GetPaginado(IQueryable<TipoProducto> queryable, int limite, int excluir);
		Task<IQueryable<TipoProducto>> GetQueryable();
	}
}

