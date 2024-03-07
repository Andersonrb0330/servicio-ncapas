using Aplication.Dtos.Request;
using Aplication.Dtos.Response;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;
using Persistence.Repositories;

namespace Aplication.Implementaciones
{
    public class TipoProductoService : ITipoProductoService
    {
        private readonly ITipoProductoRepository _tipoProductoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

		public TipoProductoService(
            ITipoProductoRepository tipoProductoRepository,
            IUnitOfWork unitOfWork, 
            IMapper mapper)
		{
            _tipoProductoRepository = tipoProductoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<TipoProductoDto> ObtenerTodos()
        {
            List<TipoProducto> tipoProductos = _tipoProductoRepository.Get();
            List<TipoProductoDto> tipoProductoDto = _mapper.Map<List<TipoProductoDto>>(tipoProductos);
            return tipoProductoDto;
        }

        public TipoProductoDto ObtenerPorId(int id)
        {
            TipoProducto tipoProducto = _tipoProductoRepository.GetById(id);
            TipoProductoDto tipoProductoDto = _mapper.Map<TipoProductoDto>(tipoProducto);
            return tipoProductoDto;
        }

        public int Crear(TipoProductoParametroDto tipoProductoParametroDto)
        {
            TipoProducto tipoProducto = new TipoProducto
            {
               Nombre = tipoProductoParametroDto.Nombre,
            };
            _tipoProductoRepository.Create(tipoProducto);
            _unitOfWork.SaveChanges();
            return tipoProducto.Id;
        }

        public void Modificar(TipoProductoParametroDto tipoProductoParametroDto)
        {
            TipoProducto tipoProducto = _tipoProductoRepository.GetById(tipoProductoParametroDto.Id);
            if (tipoProducto == null)
            {
                throw new Exception($"NO existe el Tipo Producto con este Id: {tipoProductoParametroDto.Id}");
            }
            tipoProducto.Nombre = tipoProductoParametroDto.Nombre;

            _unitOfWork.SaveChanges();
        }

        public void Eliminar(int id)
        {
            TipoProducto tipoProducto = _tipoProductoRepository.GetById(id);
            if (tipoProducto == null)
            {
                throw new Exception($"NO existe el Tipo Producto con este Id: {id}");
            }
            _tipoProductoRepository.Delete(tipoProducto);
            _unitOfWork.SaveChanges();
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

