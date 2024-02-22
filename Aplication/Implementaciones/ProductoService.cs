using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
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

        public int Crear(ProductoParametroDto productoParametroDto)
        {
            Producto producto = new Producto
            {
                Nombre = productoParametroDto.Nombre,
                Descripcion = productoParametroDto.Descripcion,
                Estado = productoParametroDto.Estado,
                Precio = productoParametroDto.Precio,
                Stock  = productoParametroDto.Stock ,
                IdTipoProducto = productoParametroDto.IdTipoProducto
            };

            _ecommerceContext.Productos.Add(producto);
            _ecommerceContext.SaveChanges();
            return producto.Id;
        }

        public void Eliminar(int id)
        {
            Producto producto = _ecommerceContext.Productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                throw new Exception($"NO existe Producto con este ID: {id}");
            }

            _ecommerceContext.Productos.Remove(producto);
            _ecommerceContext.SaveChanges();
        }

        public void Modificar(ProductoParametroDto productoParametroDto)
        {
            Producto producto = _ecommerceContext.Productos.FirstOrDefault(p => p.Id == productoParametroDto.Id);
            if (producto == null)
            {
                throw new Exception($"NO existe Producto con este ID: {productoParametroDto. Id}");
            }

            producto.Nombre = productoParametroDto.Nombre;
            producto.Descripcion = productoParametroDto.Descripcion;
            producto.Estado = productoParametroDto.Estado;
            producto.Precio = productoParametroDto.Precio;
            producto.Stock  = productoParametroDto.Stock;
            producto.IdTipoProducto = productoParametroDto.IdTipoProducto;
                                            
            _ecommerceContext.SaveChanges();
        }

        public ProductoDto ObtenerPorId(int id)
        {
            Producto producto = _ecommerceContext.Productos
                .Include(p => p.TipoProducto)
                .FirstOrDefault(p => p.Id == id);
            ProductoDto productoDto = _mapper.Map<ProductoDto>(producto);
            return productoDto;
        }

        public List<ProductoDto> ObtenerTodo()
        {
            List<Producto> productos = _ecommerceContext.Productos
                .Include(p => p.TipoProducto)
                .ToList();
            List<ProductoDto> productoDto = _mapper.Map<List<ProductoDto>>(productos);
            return productoDto;
        }
    }
}

