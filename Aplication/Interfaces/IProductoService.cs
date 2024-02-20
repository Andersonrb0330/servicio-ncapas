using System;
using Aplication.Dtos;

namespace Aplication.Interfaces
{
	public interface IProductoService
	{
		List<ProductoDto> ObtenerTodo();

		ProductoDto ObtenerPorId(int id);
	}
}

