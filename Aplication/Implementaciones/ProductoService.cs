using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain;
using Persistence.Context;

namespace Aplication.Implementaciones
{
    public class ProductoService : IProductoService
	{
        private readonly IEcommerceContext _ecommerceContext;
        private readonly IMapper _mapper;

		public ProductoService(IEcommerceContext ecommerceContext, IMapper mapper)
		{
            _ecommerceContext = ecommerceContext;
            _mapper = mapper;
		}


        public ProductoDto ObtenerPorId(int id)
        {
            Producto producto = _ecommerceContext.Productos.FirstOrDefault(p => p.Id == id);

            ProductoDto productoDto = _mapper.Map<ProductoDto>(id);

            return productoDto;
        }

        public List<ProductoDto> ObtenerTodo()
        {
            List<Producto> productos = _ecommerceContext.Productos.ToList();
            List<ProductoDto> productoDto = _mapper.Map<List<ProductoDto>>(productos);

            return productoDto;
        }
    }
}

