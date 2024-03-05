using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;

namespace Aplication.Implementaciones
{
    public class ProductoService : IProductoService
	{
        private readonly IProductoRepository _productoRepository;
        private readonly ITipoProductoRepository _tipoProductoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

		public ProductoService(
            IProductoRepository productoRepository,
            ITipoProductoRepository tipoProductoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
		{
            _productoRepository = productoRepository;
            _tipoProductoRepository = tipoProductoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
		}

        public List<ProductoDto> ObtenerTodo()
        {
            List<Producto> productos = _productoRepository.Get();
            List<ProductoDto> productoDto = _mapper.Map<List<ProductoDto>>(productos);
            return productoDto;
        }

        public ProductoDto ObtenerPorId(int id)
        {
            Producto producto = _productoRepository.GetById(id);
            ProductoDto productoDto = _mapper.Map<ProductoDto>(producto);
            return productoDto;
        }

        public int Crear(ProductoParametroDto productoParametroDto)
        {
            bool existeTipoProducto = _tipoProductoRepository.VerificarTipoProducto(productoParametroDto.IdTipoProducto);
            if (existeTipoProducto == false)
            {
                throw new Exception($"El ID {productoParametroDto.IdTipoProducto} del Tipo Producto no existe");
            }

            Producto producto = new Producto
            {
                Nombre = productoParametroDto.Nombre,
                Descripcion = productoParametroDto.Descripcion,
                Estado = productoParametroDto.Estado,
                Precio = productoParametroDto.Precio,
                Stock  = productoParametroDto.Stock ,
                IdTipoProducto = productoParametroDto.IdTipoProducto
            };

            _productoRepository.Create(producto);
            _unitOfWork.SaveChanges();
            return producto.Id;
        }

        public void Modificar(ProductoParametroDto productoParametroDto)
        {
            Producto producto = _productoRepository.GetById(productoParametroDto.Id);
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

            _unitOfWork.SaveChanges();
        }

        public void Eliminar(int id)
        {
            Producto producto = _productoRepository.GetById(id);
            if (producto == null)
            {
                throw new Exception($"NO existe Producto con este ID: {id}");
            }
            _productoRepository.Delete(producto);
            _unitOfWork.SaveChanges();
        }
    }
}

