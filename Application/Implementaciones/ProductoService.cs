using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;
using FluentValidation;

namespace Application.Implementaciones
{
    public class ProductoService : IProductoService
	{
        private readonly IProductoRepository _productoRepository;
        private readonly ITipoProductoRepository _tipoProductoRepository;
        private readonly IValidator<ProductoParametroDto> _validarProducto;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoService(
            IProductoRepository productoRepository,
            ITipoProductoRepository tipoProductoRepository,
            IValidator<ProductoParametroDto> validator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
		{
            _productoRepository = productoRepository;
            _tipoProductoRepository = tipoProductoRepository;
            _validarProducto = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
		}

        public async Task<List<ProductoDto>> ObtenerTodo()
        {
            List<Producto> productos = await  _productoRepository.Get();
            List<ProductoDto> productoDto = _mapper.Map<List<ProductoDto>>(productos);
            return productoDto;
        }

        public async Task <ProductoDto> ObtenerPorId(int id)
        {
            Producto producto =await _productoRepository.GetById(id);
            ProductoDto productoDto = _mapper.Map<ProductoDto>(producto);
            return productoDto;
        }

        public async Task<int> Crear(ProductoParametroDto productoParametroDto)
        {
            var validationResult = _validarProducto.Validate(productoParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            bool existeTipoProducto =  await _tipoProductoRepository.VerificarTipoProducto(productoParametroDto.IdTipoProducto);
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

            await _productoRepository.Create(producto);
            await _unitOfWork.SaveChangesAsync();
            return producto.Id;
        }

        public async Task Modificar(ProductoParametroDto productoParametroDto)
        {
            Producto producto = await _productoRepository.GetById(productoParametroDto.Id);
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

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            Producto producto = await _productoRepository.GetById(id);
            if (producto == null)
            {
                throw new Exception($"NO existe Producto con este ID: {id}");
            }
            _productoRepository.Delete(producto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PaginacionDto<ProductoDto>> ObtenerProductosPaginados(FiltroProductoParametroDto filtroProductoParametroDto)
        {
            IQueryable<Producto> consulta = await _productoRepository.GetQueryable();
            if (!string.IsNullOrWhiteSpace(filtroProductoParametroDto.Nombre))
            {
                consulta = consulta.Where(p => p.Nombre.Contains(filtroProductoParametroDto.Nombre));
            }
            if (!string.IsNullOrWhiteSpace(filtroProductoParametroDto.Descripcion))
            {
                consulta = consulta.Where(p => p.Descripcion.Contains(filtroProductoParametroDto.Descripcion));
            }
            if (filtroProductoParametroDto.Estado.HasValue)
            {
                consulta = consulta.Where(p => p.Estado == filtroProductoParametroDto.Estado);
            }
              
            int totalProductos = consulta.Count();
            // Obtener el totoal de paginas Math.Ceiling 
            int totalPages = (int)Math.Ceiling((double)totalProductos / filtroProductoParametroDto.Limite);
            var excluirElementos  = filtroProductoParametroDto.Limite * filtroProductoParametroDto.Pagina;
            var productosPaginados = await _productoRepository.GetPaginado(consulta, filtroProductoParametroDto.Limite, excluirElementos);
            var productosDto = _mapper.Map<List<ProductoDto>>(productosPaginados);
            var paginacionDto = new PaginacionDto<ProductoDto>
            {
                TotalItems = totalProductos,
                PaginaActual = filtroProductoParametroDto.Pagina + 1,
                TotalPaginas = totalPages,
                Items = productosDto
            };
            return paginacionDto;
        }
    }
}

