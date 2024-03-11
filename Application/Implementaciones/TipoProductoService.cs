using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;
using FluentValidation;

namespace Application.Implementaciones
{
    public class TipoProductoService : ITipoProductoService
    {
        private readonly ITipoProductoRepository _tipoProductoRepository;
        private readonly IValidator<TipoProductoParametroDto> _validarTipoProducto;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

		public TipoProductoService(
            ITipoProductoRepository tipoProductoRepository,
            IValidator<TipoProductoParametroDto> validator,
            IUnitOfWork unitOfWork, 
            IMapper mapper)
		{
            _tipoProductoRepository = tipoProductoRepository;
            _validarTipoProducto = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TipoProductoDto>> ObtenerTodos()
        {
            List<TipoProducto> tipoProductos = await _tipoProductoRepository.Get();
            List<TipoProductoDto> tipoProductoDto = _mapper.Map<List<TipoProductoDto>>(tipoProductos);
            return tipoProductoDto;
        }

        public async Task<TipoProductoDto> ObtenerPorId(int id)
        {
            TipoProducto tipoProducto = await _tipoProductoRepository.GetById(id);
            TipoProductoDto tipoProductoDto = _mapper.Map<TipoProductoDto>(tipoProducto);
            return tipoProductoDto;
        }

        public async Task<int> Crear(TipoProductoParametroDto tipoProductoParametroDto)
        {
             var validationResult = _validarTipoProducto.Validate(tipoProductoParametroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            TipoProducto tipoProducto = new TipoProducto
            {
               Nombre = tipoProductoParametroDto.Nombre,
            };
            await _tipoProductoRepository.Create(tipoProducto);
            await _unitOfWork.SaveChangesAsync();
            return tipoProducto.Id;
        }

        public async void Modificar(TipoProductoParametroDto tipoProductoParametroDto)
        {
            TipoProducto tipoProducto = await _tipoProductoRepository.GetById(tipoProductoParametroDto.Id);
            if (tipoProducto == null)
            {
                throw new Exception($"NO existe el Tipo Producto con este Id: {tipoProductoParametroDto.Id}");
            }
            tipoProducto.Nombre = tipoProductoParametroDto.Nombre;

            await _unitOfWork.SaveChangesAsync();
        }

        public async void Eliminar(int id)
        {
            TipoProducto tipoProducto = await _tipoProductoRepository.GetById(id);
            if (tipoProducto == null)
            {
                throw new Exception($"NO existe el Tipo Producto con este Id: {id}");
            }
            _tipoProductoRepository.Delete(tipoProducto);
            await _unitOfWork.SaveChangesAsync();
        }

        public PaginacionDto<TipoProductoDto> ObtenerTipoProductosPaginados(FiltroTipoProductoParametroDto filtroTipoProductoParametroDto)
        {
            IQueryable<TipoProducto> consulta = _tipoProductoRepository.GetQueryable();
            if (!string.IsNullOrWhiteSpace(filtroTipoProductoParametroDto.Nombre))
            {
                consulta = consulta.Where(p => p.Nombre.Contains(filtroTipoProductoParametroDto.Nombre));
            }

            int totalTipoProductos = consulta.Count();
            // Obtener el totoal de paginas Math.Ceiling 
            int totalPages = (int)Math.Ceiling((double)totalTipoProductos / filtroTipoProductoParametroDto.Limite);
            var excluirElementos = filtroTipoProductoParametroDto.Limite * filtroTipoProductoParametroDto.Pagina;
            var tipoProductosPaginados = _tipoProductoRepository.GetPaginado(consulta, filtroTipoProductoParametroDto.Limite, excluirElementos);
            var tipoProductosDto = _mapper.Map<List<TipoProductoDto>>(tipoProductosPaginados);
            var paginacionDto = new PaginacionDto<TipoProductoDto>
            {
                TotalItems = totalTipoProductos,
                PaginaActual = filtroTipoProductoParametroDto.Pagina + 1,
                TotalPaginas = totalPages,
                Items = tipoProductosDto
            };
            return paginacionDto;
        }
    }
}

